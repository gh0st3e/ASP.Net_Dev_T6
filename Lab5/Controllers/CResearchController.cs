using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class CResearchController : Controller
    {
        // GET: CResearch
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("post","get")]
        //[Route("CResearch")]
        //[Route("CResearch/C01")]
        public ActionResult C01()
        {
            string outStr = ""; 
            outStr += "<h1>"+ Request.HttpMethod.ToString() + "</h1>";
            outStr += "<h1>" +Request.Url.AbsolutePath + "</h1>";
            outStr += "<h1>" +Request.Headers.ToString() + "</h1>";
            outStr += "<h1>" + Request.QueryString["param"] + "</h1>";
            Request.InputStream.Position = 0;
            var input = new StreamReader(Request.InputStream).ReadToEnd();
            outStr += "<h1>" +input.ToString()+"</h1";
            return Content(outStr);
        }

        [AcceptVerbs("post", "get")]
        //[Route("CResearch/C02")]
        public ActionResult C02()
        {
            string outStr = "";
            outStr += "<h1>" + Response.StatusCode+ "</h1>";
            outStr += "<h1>" + Request.Headers.ToString() + "</h1>";
            Request.InputStream.Position = 0;
            var input = new StreamReader(Request.InputStream).ReadToEnd();
            outStr += "<h1>" + input.ToString() + "</h1";
            return Content(outStr);
        }
    }
}