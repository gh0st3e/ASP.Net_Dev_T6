using System;
using System.Web;

namespace Lab1
{
    public class User : IHttpHandler
    {
        const string Get = "GET";
        const string Post = "POST";
        const string Put = "PUT";
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
            response.AddHeader("Content-Type", "text/plain");
            response.Write($"Method = {request.HttpMethod}\n");

            switch (request.HttpMethod)
            {
                case Get:
                    var GetParamA = request["ParmA"];
                    var GetParamB = request["ParmB"];
                    response.Write($"GET-Http-XYZ\nParmA = {GetParamA}\nParmB = {GetParamB}");
                    break;
                case Post:
                    var PostParamA = request.Form["ParmA"];
                    var PostParamB = request.Form["ParmB"];
                    response.Write($"POST-Http-XYZ\nParmA = {PostParamA}\nParmB = {PostParamB}");
                    break;
                case Put:
                    var PutParamA = request["ParmA"];
                    var PutParmB = request.Form["ParmB"];
                    response.Write($"PUT-Http-XYZ\nParmA = {PutParamA}\nParmB = {PutParmB}");
                    break;
                default:
                    response.Write("Uknown HTTP Method");
                    break;

            }
            response.End();
        }

        #endregion
    }
}
