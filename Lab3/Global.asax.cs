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
            // �������� ����� � URI �������
            string method = Request.HttpMethod;
            string uri = Request.Url.AbsoluteUri;

            // ���������, �������������� �� ������ �������
            bool isSupported = CheckIfRouteIsSupported(method, uri);

            // ���� ������� �� ��������������, ������� ��������� �� ������
            if (!isSupported)
            {
                Response.Clear();
                Response.StatusCode = 404;
                Response.Write($"{method}: {uri} �� ��������������");
                Response.End();
            }
        }

        bool CheckIfRouteIsSupported(string method, string uri)
        {
            // ����� ����� ����������� �������� �������������� ���������
            // ��������, ����� ���������, ���� �� ��������������� ���������� � ����� ��������
            // ��� ������ ���������, ���� �� ������ ������� � ������ �������������� ���������

            return true; // ���������� true, ���� ������� ��������������
        }

    }
}
