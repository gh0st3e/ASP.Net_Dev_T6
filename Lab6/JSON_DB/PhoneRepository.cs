using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using PhoneDictionary;

namespace JSON_DB
{
    public sealed class PhoneRepository : IRepository<Phone>
    {
        static public List<Phone> Phones { get; set; } = new List<Phone>();

        public void SaveModel()
        {
            string json = JsonSerializer.Serialize<List<Phone>>(Phones);
            string path = Path.GetDirectoryName("PhonesDB.json");
            File.WriteAllText(@"D:\Study\PIS\Lab6\JSON_DB\PhonesDB.json", json);
        }

        public void LoadModel()
        {
            Phones = JsonSerializer.Deserialize<List<Phone>>(File.ReadAllText(@"D:\Study\PIS\Lab6\JSON_DB\PhonesDB.json"));
        }

        public Phone Add(Phone item)
        {
            if (item != null)
            {
                int lastId = Phones.Max(i => i.Id);
                item.Id = lastId + 1;
                var checkExistPhone = Get(item.Id);
                if (checkExistPhone == null)
                {
                    Phones.Add(item);
                    SaveModel();
                    return item;
                }
            }
            return null;
        }

        public void Dispose()
        {
        }

        public IEnumerable<Phone> GetAllPhones()
        {
            LoadModel();
            Phones.OrderBy(n => n.Name);
            return Phones;
        }

        public bool Remove(Phone item)
        {
            var phone = Get(item.Id);
            if (phone != null && item != null)
            {
                Phones.Remove(item);
                SaveModel();
                return true;
            }
            return false;
        }

        public Phone Update(Phone item)
        {
            if (item != null)
            {
                var phone = Get(item.Id);
                if (phone != null)
                {
                    Phones.Remove((Phone)phone);
                    phone.Name = item.Name;
                    phone.Phone_Number = item.Phone_Number;
                    Phones.Add(phone);
                    SaveModel();
                    return phone;
                }
            }
            return null;
        }

        public Phone Get(int ID)
        {
            return Phones.FirstOrDefault(t => t.Id == ID);
        }
    }
}
