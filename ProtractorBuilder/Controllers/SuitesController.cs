using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;
using ProtractorBuilder.Protractor.Converter;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class SuitesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<TestSuite>> Get()
        {
            using (var db = new TestContext())
            {
                return await db.Suites.ToListAsync();
            }
        }

		[HttpGet("{id}")]
		public async Task<TestSuite> Get(string id)
		{
			using (var db = new TestContext())
			{
				return await db.Suites
									.Include(s => s.BeforeAll)
									.Include(s => s.Cases)
									.ThenInclude(c => c.Steps)
									.SingleAsync(s => s.Id == id);
			}
		}

        [HttpGet("export/{id}")]
        public async Task<string> Export(string id)
        {
            using (var db = new TestContext())
            {
                var suite = await db.Suites
                                    .Include(s => s.BeforeAll)
                                    .Include(s => s.Cases)
                                    .ThenInclude(c => c.Steps)
                                    .SingleAsync(s => s.Id == id);

                if (suite == null)
                {
                    return "Suite is not found";
                }

                return SuiteConverter.ToProtractorSuite(suite);
            }
        }

        [HttpPost]
        public string Post([FromBody]TestSuite value)
        {
            var result = string.Empty;
            using (var db = new TestContext())
            {
                value.Id = Guid.NewGuid().ToString("N");

                var caseIds = value.Cases.Select(c => c.Id);
                value.Cases = new List<TestCase>();

                foreach (var caseId in caseIds)
                {
                    value.Cases.Add(db.Cases.Find(caseId));
                }

                foreach (var step in value.BeforeAll)
                {
                    step.Id = string.Format("_{0}", Guid.NewGuid().ToString("N")); // step Id may be used for variable in the test case, add an underscore to make is a valid variable name
                    db.Steps.Add(step);
                }

                db.Suites.Add(value);

                var count = db.SaveChanges();

                result = value.Id;
            }

            return result;
        }
    }
}
