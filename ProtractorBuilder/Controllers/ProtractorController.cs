using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProtractorBuilder.Protractor.Common;
using ProtractorBuilder.Protractor.Converter;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class ProtractorController : Controller
    {
        const string configName = "protractor_auto_config";
        readonly ProtractorConfiguration configuration;

        readonly TestContext db;

        public ProtractorController(TestContext testContext)
        {
            this.db = testContext;
        }

        public ProtractorController(IOptions<ProtractorConfiguration> configurationAccessor)
        {
            configuration = configurationAccessor.Value;
        }

        [HttpPost]
        public async Task<string> Post(bool headerless)
        {
            await WriteAllSuites();

            var protractorPath = configuration.ProtractorPath;
            var path = Path.Combine(protractorPath, configName);
            var pathwithext = Path.ChangeExtension(path, "js");

            if (headerless)
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo("protractor", pathwithext)
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                //return pathwithext;

                process.Start();

                string result = process.StandardOutput.ReadToEnd();

                process.WaitForExit();

                return result;
            }
            else
            {
                var process = new Process()
                {
                    StartInfo = new ProcessStartInfo("protractor", pathwithext)
                    {
                        RedirectStandardOutput = false,
                        UseShellExecute = true,
                        CreateNoWindow = false
                    }
                };

                process.Start();

                process.WaitForExit();

                return string.Empty;
            }
        }

        async Task WriteAllSuites()
        {
            var suites = await db.Suites
                                .Include(s => s.Cases)
                                .ThenInclude(c => c.Steps)
                                .ToListAsync();

            var fileNames = new List<string>();
            suites.ForEach(async s =>
            {
                var fileName = string.Format("{0}.js", s.Name);
                using (var writer = new StreamWriter(string.Format("{0}/{1}", configuration.ProtractorPath, fileName)))
                {
                    await writer.WriteAsync(SuiteConverter.ToProtractorSuite(s));
                }
                fileNames.Add(fileName);
            });

            using (var configWriter = new StreamWriter(string.Format("{0}/{1}.js", configuration.ProtractorPath, configName)))
            {
                await configWriter.WriteAsync(string.Format(@"require('babel-core/register');
exports.config = {{
  seleniumAddress: '{0}',", configuration.SeleniumAddress));
                await configWriter.WriteAsync(string.Format("specs: ['{0}'],", string.Join("','", fileNames.Distinct())));
                await configWriter.WriteAsync(@"capabilities: {
    browserName: 'chrome'
  }
};");
            }
        }
    }
}
