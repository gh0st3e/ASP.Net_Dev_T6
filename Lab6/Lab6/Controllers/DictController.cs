using System;
using System.Web.Mvc;
using PhoneDictionary;

namespace Lab6.Controllers
{
    public class DictController : Controller
    {
        IRepository<Phone> phoneRepository;

        public DictController(IRepository<Phone> rep)
        {
            phoneRepository = rep;
        }

        public ActionResult Index()
        {
            return View(phoneRepository.GetAllPhones());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Phone phone)
        {
            phoneRepository.Add(phone);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            int ID;
            if (Int32.TryParse(id, out ID))
            {
                var phone = phoneRepository.Get(ID);
                if (phone == null)
                {
                    return HttpNotFound();
                }
                return View(phone);
            }
            else
                return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Update(Phone phone)
        {
            phoneRepository.Update(phone);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public ActionResult Delete(string id)
        {
            int ID;
            if (Int32.TryParse(id, out ID))
            {
                var phone = phoneRepository.Get(ID);
                if (phone == null)
                {
                    return HttpNotFound();
                }
                return View(phone);
            }
            else
                return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteSave(string id)
        {
            int ID;
            if (Int32.TryParse(id, out ID))
            {
                phoneRepository.Remove(phoneRepository.Get(ID));
                return RedirectToAction("Index");
            }
            else
                return HttpNotFound();
        }

        /*
        protected override void Dispose(bool disposing)
        {
            phoneRepository.Dispose();
            base.Dispose(disposing);
        }
        */
    }
}