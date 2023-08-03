using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDictionary
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllPhones();
        T Get(int ID);
        T Add(T item);
        bool Remove(T item);
        T Update(T item);
    }

}
