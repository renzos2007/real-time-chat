using System.Net.WebSockets;
using System.Text;
using DotNetEnv;

namespace Service
{
    class ChatService
    {
        private ClientWebSocket? webSocket;
        private CancellationTokenSource? cts;

        public async Task Connect()
        {
            Env.Load();
            string baseUrl = Environment.GetEnvironmentVariable("BASE_WEBSOCKET") ?? "ws://jsonplaceholder.typicode/api/";

            webSocket = new ClientWebSocket();
            cts = new CancellationTokenSource();

            var uri = new Uri($"{baseUrl}chat");
            var cookies = Config.Http.GetCookies();
            foreach (System.Net.Cookie cookie in cookies)
            {
                webSocket.Options.Cookies ??= new System.Net.CookieContainer();
                cookie.Domain = uri.Host;
                webSocket.Options.Cookies.Add(cookie);
            }

            try
            {
                await webSocket.ConnectAsync(uri, CancellationToken.None);
                Console.WriteLine("Connected to chat.");
                Console.WriteLine("You can send chats when you press enter and disconnect when you send the message '/exit'");
                await Task.Delay(1500);

                _ = Task.Run(() => StartReceiving(cts.Token));

                await StartSending();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Connection failed: {ex}");
            }
        }

        private async Task StartReceiving(CancellationToken token)
        {
            var buffer = new byte[4096];

            try
            {
                while (webSocket?.State == WebSocketState.Open && !token.IsCancellationRequested)
                {
                    var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("\nServer closed the connection.");
                        await Disconnect();
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    // Do not overwrite the current input line
                    Console.WriteLine($"\r{message}");
                    Console.Write("> ");
                }
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Console.WriteLine($"\nReceive error: {ex.Message}");
            }
        }

        private async Task StartSending()
        {
            while (webSocket?.State == WebSocketState.Open)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (input == null || input == "/exit")
                {
                    await Disconnect();
                    break;
                }

                if (string.IsNullOrWhiteSpace(input)) continue;

                byte[] bytes = Encoding.UTF8.GetBytes(input);
                await webSocket.SendAsync(
                    new ArraySegment<byte>(bytes),
                    WebSocketMessageType.Text,
                    endOfMessage: true,
                    CancellationToken.None
                );
            }
        }

        public async Task Disconnect()
        {
            if (webSocket is null) return;

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
            Console.WriteLine("Disconnected from chat.");
        }
    }
}