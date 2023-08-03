using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PhoneDictionary;

namespace MSSQL_DB
{
    public sealed class PhoneRepository : IRepository<Phone>
    {
        PhoneDictionaryContext db = new PhoneDictionaryContext("ContactContext");

        public Phone Add(Phone item)
        {
            db.Phones.Add(item);
            db.SaveChanges();
            return item;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            var sortedPhones = db.Phones.Select(n => n).OrderBy(n => n.Name);
            return sortedPhones;
        }

        public bool Remove(Phone item)
        {
            if (item == null)
            {
                return false;
            }
            db.Entry(item).State = EntityState.Deleted;
            db.SaveChanges();
            return true;

        }

        public Phone Update(Phone item)
        {
            var phone = Get(item.Id);
            if(phone != null)
            {
                phone.Name = item.Name;
                phone.Phone_Number = item.Phone_Number;
                db.Phones.Attach(phone);
                db.Entry(phone).State = EntityState.Modified;
                db.SaveChanges();
                return phone;
            }
            return null;
        }

        public Phone Get(int ID)
        {
            return db.Phones.FirstOrDefault(t => t.Id == ID);
        }

    }
}
