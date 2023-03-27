using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    interface IRepository<T> : IDisposable where T : class
    {
       IEnumerable<T> GetAll();
       T Get(string Name);
       void Add(T item);
       void Update(T item);
       void Delete(T item);
    }
}
