using WebSocketSharp;
using WebSocketSharp.Server;
using WebSocketServer.SocketServices;

var wssv = new WebSocketSharp.Server.WebSocketServer("ws://localhost:8080");
wssv.AddWebSocketService<ChatSocket>("/Chat");
wssv.Start();
Console.WriteLine("Server started. Press Enter to stop it.");
Console.ReadLine();
wssv.Stop();
