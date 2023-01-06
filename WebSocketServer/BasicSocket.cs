using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebSocketServer
{
    internal class BasicSocket
    {

        public void Start()
        {
            var wssv = new WebSocketSharp.Server.WebSocketServer("ws://localhost:8080");
            wssv.AddWebSocketService<Echo>("/Echo");
            wssv.Start();
            Console.WriteLine("Server started. Press Enter to stop it.");
            Console.ReadLine();
            wssv.Stop();
        }

    }

    public class Echo : WebSocketBehavior
    {

        protected override void OnOpen()
        {
            var openMessage = "connection open with id " + ID;
            Send(openMessage);
        }
        protected override void OnMessage(MessageEventArgs e)
        {
            Send(e.Data);
        }
    }
}
