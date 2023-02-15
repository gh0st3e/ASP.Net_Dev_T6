using System;
using System.Web;

namespace Lab1
{
    public class Sum : IHttpHandler
    {
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
            int sum = 0;
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.AddHeader("Content-Type", "text/plain");

            var PostParamA = request.Form["ParmA"];
            var PostParamB = request.Form["ParmB"];

            try
            {
                int a = int.Parse(PostParamA);
                int b = int.Parse(PostParamB);
                sum = a + b;

            }
            catch(Exception ex)
            {
                response.StatusCode = 400;
                response.Write("Couldn't parse params. It shoul be number");
                response.End();
            }
            response.Write($"Sum = {sum}");
            response.StatusCode = 200;
            response.End();
        }

        #endregion
    }
}
