using Ninject.Modules;
using PhoneDictionary;
using System.Web;
using Ninject.Web.Common;

namespace Lab6.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            //Bind<IRepository<Phone>>().To<MSSQL_DB.PhoneRepository>(); //--для каждого требования внедрения 

            //.InTransientScope()(по умолчанию)

            //Bind<IRepository<Phone>>().To<JSON_DB.PhoneRepository>().InSingletonScope(); 
            //Объект класса будет создан раз и будет использоваться повторно.

            Bind<IRepository<Phone>>().To<MSSQL_DB.PhoneRepository>().InThreadScope(); //Один объект на поток.

            //Bind<IRepository<Phone>>().To<JSON_DB.PhoneRepository>().InRequestScope(); //Один объект будет на каждый web-запрос
        }
    }
}