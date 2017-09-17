using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class CasesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<TestCase>> Get()
        {
            using (var db = new TestContext())
            {
                return await db.Cases.ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<TestCase> Get(string id)
        {
            using (var db = new TestContext())
            {
                return await db.Cases
                               .Include(c => c.Steps)
                               .ThenInclude(s => s.ResultFrom)
                               .SingleAsync(c => c.Id == id)
                               .ConfigureAwait(false);
            }
        }

        [HttpPost]
        public string Post([FromBody]TestCase value)
        {
            using (var db = new TestContext())
            {
                foreach (var step in value.Steps)
                {
                    step.Id = string.Format("_{0}", Guid.NewGuid().ToString("N")); // step Id may be used for variable in the test case, add an underscore to make is a valid variable name

                    if (step.ResultFrom != null && !string.IsNullOrWhiteSpace(step.ResultFrom.Name))
                    {
                        var resultFrom = value.Steps.Find(s => s.Name == step.ResultFrom.Name);
                        step.ResultFrom = resultFrom;
                    }

                    db.Steps.Add(step);
                }

                value.Id = Guid.NewGuid().ToString("N");
                db.Cases.Add(value);

                var count = db.SaveChanges();

                return value.Id;
            }
        }

        [HttpPut]
        public async Task<string> Put([FromBody]TestCase value)
        {
            using (var db = new TestContext())
            {
                var testCase = db.Cases.Find(value.Id);

                if (testCase != null)
                {
                    testCase = await db.Cases
                                       .Include(c => c.Steps)
                                       .SingleAsync(c => c.Id == value.Id)
                                       .ConfigureAwait(false);

                    if (testCase.Steps != null)
                    {
                        foreach (var step in testCase.Steps)
                        {
                            db.Steps.Remove(step);
                        }

                        testCase.Steps.RemoveAll(s => true);
                    }

                    foreach (var step in value.Steps)
                    {
                        step.Id = string.Format("_{0}", Guid.NewGuid().ToString("N")); // step Id may be used for variable in the test case, add an underscore to make is a valid variable name

                        if (step.ResultFrom != null && !string.IsNullOrWhiteSpace(step.ResultFrom.Name))
                        {
                            var resultFrom = value.Steps.Find(s => s.Name == step.ResultFrom.Name);
                            step.ResultFrom = resultFrom;
                        }
                        testCase.Steps.Add(step);
                        db.Steps.Add(step);
                    }

                    testCase.Name = value.Name;
                    testCase.Order = value.Order;
                    testCase.Enabled = value.Enabled;

                    db.SaveChanges();

                    return testCase.Id;
                }
                else
                {
                    return Post(value);
                }
            }
        }
    }
}
