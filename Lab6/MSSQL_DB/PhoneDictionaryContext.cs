using System.Data.Entity;
using PhoneDictionary;

namespace MSSQL_DB
{
    class PhoneDictionaryContext : DbContext
    {
        public PhoneDictionaryContext(string connString) : base($"name={connString}")
        {
        }

        public virtual DbSet<Phone> Phones { get; set; }
    }
}
