using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class DictController : Controller
    {
        ContactsRepo contactsRepo = new ContactsRepo();

        public ActionResult Index()
        {
            return View(contactsRepo.GetAll());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult AddSave(Contact contact)
        {
            contactsRepo.Add(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            var phone = contactsRepo.Get(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateSave(Contact contact)
        {
            contactsRepo.Update(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var phone = contactsRepo.Get(id);
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(string id)
        {
            contactsRepo.Delete(contactsRepo.Get(id));
            return RedirectToAction("Index");
        }

        protected override void HandleUnknownAction(string actionName)
        {
            // Get the requested URI
            string uri = HttpContext.Request.Url.AbsoluteUri;

            // Get the HTTP method used for the request
            string method = HttpContext.Request.HttpMethod;

            // Construct the error message
            string errorMessage = $"{method}: {uri} not supported.";

            // Return the error message as a plain text response
            Response.ContentType = "text/plain";
            Response.Write(errorMessage);
            Response.StatusCode = 404;
        }
    }
}