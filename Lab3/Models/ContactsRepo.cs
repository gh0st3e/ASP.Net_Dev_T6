using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;

namespace Lab3.Models
{
    sealed public class ContactsRepo : IRepository<Contact>
    {
        static public List<Contact> Contacts { get; set; } = new List<Contact>();

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Contacts);
            File.WriteAllText(@"D://Study/PIS/Lab3/Contacts.json", json);
        }

        public void Load()
        {
            string json = File.ReadAllText(@"D://Study/PIS/Lab3/Contacts.json");
            Contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
        }

        public IEnumerable<Contact> GetAll()
        {
            Load();
            Contacts.OrderBy(c => c.Name);
            return Contacts;
        }

        public Contact Get(string Name)
        {
            return Contacts.Find(c => c.Name == Name);
        }

        public void Add(Contact contact)
        {
            Contacts.Add(contact);
            Save();
        }

        public void Update(Contact contact)
        {
            Contact oldContact = Get(contact.Name);
            Contacts.Remove(oldContact);
            Contacts.Add(contact);
            Save();
        }

        public void Delete(Contact contact)
        {
            Contacts.Remove(contact);
            Save();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}