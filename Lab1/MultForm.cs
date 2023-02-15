using System;
using System.Web;
using System.Web.Services.Description;

namespace Lab1
{
    public class MultForm : IHttpHandler
    {
        const string Get = "GET";
        const string Post = "POST";
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            switch (request.HttpMethod)
            {
                case Get:
                    response.AddHeader("Content-Type", "text/html");
                    response.WriteFile("multformpage.html");
                    response.StatusCode = 200;
                    break;
                case Post:
                    int mult = 0;
                    response.AddHeader("Content-Type", "text/plain");
                    var PostParamA = request.Form["ParmA"];
                    var PostParamB = request.Form["ParmB"];
                    try
                    {
                        var x = int.Parse(request.Form["x"]);
                        var y = int.Parse(request.Form["y"]);
                        mult = x * y;
                    }
                    catch (Exception ex)
                    {
                        response.StatusCode = 400;
                        response.Write("Couldn't parse params. It shoul be digits");
                        response.End();
                    }
                    response.Write($"Sum = {mult}");
                    response.StatusCode = 200;
                    response.End();
                    break;
                default: break;
            }
        }
        #endregion
    }
}
