using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace Inspinia.Controllers
{
    public class DashboardsController : Controller
    {
        public ActionResult Default() => View();
        public IActionResult Index1() => View();
        public IActionResult Index2() => PartialView();
        public IActionResult Index3() => View();

        public ActionResult API() => PartialView();
        public ActionResult CardTemperature()
        {
            return PartialView("_CardTemperature");
        }

        public IActionResult Operation()
        {
            return PartialView("Operation");
        }

        public ActionResult Assets(string ClassName )
        {
            ViewBag.ClassName = ClassName;
            return PartialView("Assets");
        }



    }


    
}