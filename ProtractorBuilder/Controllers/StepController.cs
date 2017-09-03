using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProtractorBuilder.Protractor.Common;
using ProtractorBuilder.Protractor.DbContext;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class StepController : Controller
    {
		[HttpGet]
		public async Task<IEnumerable<TestStep>> Get()
		{
			using (var db = new TestContext())
			{
                return await db.Steps.ToListAsync();
			}
		}
    }
}
