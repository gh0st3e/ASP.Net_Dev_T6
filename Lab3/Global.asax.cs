using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // Получаем метод и URI запроса
            string method = Request.HttpMethod;
            string uri = Request.Url.AbsoluteUri;

            // Проверяем, поддерживается ли данный маршрут
            bool isSupported = CheckIfRouteIsSupported(method, uri);

            // Если маршрут не поддерживается, выводим сообщение об ошибке
            if (!isSupported)
            {
                Response.Clear();
                Response.StatusCode = 404;
                Response.Write($"{method}: {uri} не поддерживается");
                Response.End();
            }
        }

        bool CheckIfRouteIsSupported(string method, string uri)
        {
            // Здесь можно реализовать проверку поддерживаемых маршрутов
            // Например, можно проверить, есть ли соответствующий контроллер и метод действия
            // или просто проверить, есть ли данный маршрут в списке поддерживаемых маршрутов

            return true; // Возвращаем true, если маршрут поддерживается
        }

    }
}
