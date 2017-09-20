using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class StepsController : Controller
    {
        readonly TestContext db;

        public StepsController(TestContext testContext)
        {
            this.db = testContext;
        }

        [HttpGet]
        public async Task<IEnumerable<TestStep>> Get()
        {
            return await db.Steps.ToListAsync();
        }
    }
}
