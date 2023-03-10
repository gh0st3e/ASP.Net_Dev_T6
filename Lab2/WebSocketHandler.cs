using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.WebSockets;

namespace Lab2
{
    public class WebSocketHandler : IHttpHandler
    {
        /// <summary>
        /// Вам потребуется настроить этот обработчик в файле Web.config вашего 
        /// веб-сайта и зарегистрировать его с помощью IIS, чтобы затем воспользоваться им.
        /// см. на этой странице: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region Члены IHttpHandler

        WebSocket socket;

        public bool IsReusable
        {
            // Верните значение false в том случае, если ваш управляемый обработчик не может быть повторно использован для другого запроса.
            // Обычно значение false соответствует случаю, когда некоторые данные о состоянии сохранены по запросу.
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;

            string msg = await Receive();
            await Send(msg);
            int i = 0;
            while (true)
            {
                // If socket is being closed on client side, we need to close it on server.
                // Nuance is that no matter what, connection will be closed only after about 1 minute. 
                if (socket.State != WebSocketState.Open)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "closed by me", CancellationToken.None);
                }
                while (socket.State == WebSocketState.Open)
                {
                    Thread.Sleep(2000);
                    await Send($"[{i++}]");
                }
            }
        }
        private async Task<String> Receive()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }
        private async Task Send(string message)
        {
            var sendBuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes($"Ответ: {message}"));
            await socket.SendAsync(sendBuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        #endregion
    }
}
