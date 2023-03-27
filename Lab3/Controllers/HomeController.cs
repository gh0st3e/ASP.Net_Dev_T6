using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        ContactsRepo contactsRepo = new ContactsRepo();

        public ActionResult Index()
        {
            return View(contactsRepo.GetAll());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}