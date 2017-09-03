using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
    public class BasicController : Controller
    {
        [HttpGet("action")]
        public IEnumerable<object> GetActions()
        {
            return from ActionSequence a in Enum.GetValues(typeof(ActionSequence))
                         select new { Id = (int)a, Name = a.ToString() };
        }

        [HttpGet("locator")]
        public IEnumerable<object> GetLocators()
        {
			return from Locator r in Enum.GetValues(typeof(Locator))
				   select new { Id = (int)r, Name = r.ToString() };
        }
    }
}
