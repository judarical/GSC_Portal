using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using JSC_Portal.Models;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Http.Features;
using Microsoft.AspNet.Mvc.Localization;
using JSC_Portal.Resources;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JSC_Portal.Controllers
{
    public class HomeController : Controller
    {
        // private readonly IHtmlLocalizer<ComponentResources> _localizer;

        /*public HomeController(IHtmlLocalizer<ComponentResources> localizer)
        {
            this._localizer = localizer;
        }*/

        // GET: /<controller>/
        public IActionResult Index()
        {
            var testManager = new TestModelManager();

            return View(testManager.GetAll);
        }

        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();
            return View("~/Views/Shared/Error.cshtml", feature?.Error);
        }
    }
}
