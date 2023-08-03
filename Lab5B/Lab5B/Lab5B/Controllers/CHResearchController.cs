using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Lab5B.Controllers
{
    public class CHResearchController : Controller
    {
        static int queue = 0;
        public ActionResult Index()
        {
            return Content("GET:CHResearch/Index");
        }

        [OutputCache(Duration = 5), HttpGet]
        public ActionResult AD()
        {
            queue++;
            string t = DateTime.Now.ToLongTimeString();
            return Content($"GET:/AD:{t} \n {queue}");
        }

        [OutputCache(Duration = 7, VaryByParam = "x;y"), HttpPost]
        public ActionResult AP(string x, string y)
        {
            string t = DateTime.Now.ToLongTimeString(); 
            return Content($"POST:/AP:{t}:{x}:{y}");
        }
    }
}