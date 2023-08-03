using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class DictController : Controller
    {
        ContactContext db = new ContactContext();
   
        public ActionResult Index()
        {
            return View(db.Contacts);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ActionName("Add")]
        public ActionResult AddSave(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            var phone = db.Contacts.Find(int.Parse(id));
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Update")]
        public ActionResult UpdateSave(Contact contact)
        {
            var existingContact = db.Contacts.Find(contact.Id);

            if (existingContact != null) { 
            
                existingContact.Name = contact.Name;
                existingContact.Phone = contact.Phone;
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var phone = db.Contacts.Find(int.Parse(id));
            if (phone == null)
            {
                return HttpNotFound();
            }
            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(string id)
        {
            db.Contacts.Remove(db.Contacts.Find(int.Parse(id)));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}