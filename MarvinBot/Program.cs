using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SlackService.Events;
using SlackService.Models;
using WebSocket4Net;

namespace MarvinBot
{
    class Program
    {
        private static WebSocket webSocket;
        static void Main(string[] args)
        {
            webSocket = new WebSocket("wss://ms396.slack-msgs.com/websocket/A31AfioHwVsSy-1WQrh3Vyy1Xbs6jLv9PTh1CKbgEXuFTJvKYJ6TbmoYH7NpepghfwYKislLy6Am7pHIdOb674T24JPN70aQxxvhAoxWWLcP1Mbs0UmlBYnRb-f-OAUT91Z_fZAa47X8kbhh8IZpLg==");
            webSocket.Open();
            webSocket.MessageReceived += WebSocket_MessageReceived;

            while (true)
            {


            }
        }

        private static void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.Message);
            var baseEvent = JsonConvert.DeserializeObject<BaseEvent>(e.Message);

            if (baseEvent.Type == "message")
            {
                var messageEvent = JsonConvert.DeserializeObject<MessageEvent>(e.Message);
                var messageCommand = new MessageCommand
                {
                    channel = messageEvent.Channel,
                    text = $"I'm in parrot mode: {messageEvent.Text}"
                };

                webSocket.Send(JsonConvert.SerializeObject(messageCommand));
            }

            //xoxb-18092234309-nDkSjH0vcTRvT7ikoszyIIj3
        }
    }
}
