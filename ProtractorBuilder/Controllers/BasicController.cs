using System;
using Microsoft.AspNetCore.Mvc;
using ProtractorBuilder.Protractor.Common;

namespace ProtractorBuilder.Controllers
{
    [Route("api/[controller]")]
	public class BasicController : Controller
	{
		[HttpGet]
		public string[] GetActions()
		{
            return Enum.GetNames(typeof(ActionSequence));
		}

		[HttpGet]
		public string[] GetLocators()
		{
			return Enum.GetNames(typeof(Locator));
		}
	}
}
