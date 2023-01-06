using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Text.Json;

namespace WebSocketServer.SocketServices
{
    internal class ChatSocket: WebSocketBehavior
    {
        private PeriodicTimer _timer = new PeriodicTimer(TimeSpan.FromSeconds(5));
        private string[] _authors = 
           {
              "Anup Mahato",
              "Bot 1",
              "Bot 2",
              "Possibly Anup",
              "Hacker Babu",
              "Hacker Don",
              "Hacker Lul",
              "GigMonster",
            };
        private string[] _messages =
            {
                "hello !!!",
                "okkkkk 😎",
                "kewl kewl",
                "real time message",
                "I'm not a bot",
                "I'm not a bot. But I'm program generated",
                "this is a random chat selected from a list of chats",
                "I like functional programming",
                "OOPs is awesome",
                "OOPs is boring",
                "RUST IS BEST",
            };
        protected override async void OnOpen()
        {
            var openMessage = "connection open with id " + ID;
            Send(openMessage);

            while(await _timer.WaitForNextTickAsync())
            {
                var getData = GenerateRandomUserChatInBytes();
                Send(getData);
            }
        }

        protected override void OnClose(CloseEventArgs e)
        {
            Send("conection closed");
        }

        public byte[] GenerateRandomUserChatInBytes()
        {
            int randomAuthorIndex = new Random().Next(0, _authors.Length);
            int randomMessageIndex = new Random().Next(0, _messages.Length);
            var sendData = new
            {
                username = _authors[randomAuthorIndex],
                message = _messages[randomMessageIndex]
            };
            var serializeDataInBytes = JsonSerializer.SerializeToUtf8Bytes(sendData);
            return serializeDataInBytes;
        }
    }
}
