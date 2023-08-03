using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class MResearchController : Controller
    {
        // GET: MResearch
        public ActionResult Index()
        {
            return View();
        }

        //[Route("V2/MResearch/M01")]
        //[Route("V3/MResearch/X/M01")]
        //[Route("")]
        //[Route("MResearch")]
        //[Route("MResearch/M01")]
        //[Route("MResearch/M01/1")]
        public ActionResult M01() {
            return Content("M01");
        }

        //[Route("V2")]
        //[Route("V2/MResearch")]
        //[Route("V2/MResearch/M02")]
        //[Route("MResearch/M02")]
        //[Route("V3/MResearch/X/M02")]
        public ActionResult M02()
        {
            return Content("M02");
        }

        //[Route("V3")]
        //[Route("V3/MResearch/X/")]
        //[Route("V3/MResearch/X/M03")]
        public ActionResult M03()
        {
            return Content("M03");
        }

        [Route("Mresearch/MXX")]
        public ActionResult MXX()
        {
            return Content("MXX");
        }
    }
}