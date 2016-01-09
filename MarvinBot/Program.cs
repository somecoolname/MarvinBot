using System;
using System.Net;
using Newtonsoft.Json;
using SlackService.Events;
using SlackService.Models;
using WebSocket4Net;
using static System.Console;

namespace MarvinBot
{
    class Program
    {
        private static WebSocket webSocket;
        static void Main(string[] args)
        {
            WriteLine("Getting WebSocket connection String.");
            var connectionString = GetWebSocketConnectionString();

            WriteLine("Connecting to WebSocket Url");
            webSocket = new WebSocket(connectionString);
            webSocket.Open();
            webSocket.MessageReceived += WebSocket_MessageReceived;

            while (true)
            {


            }
        }

        private static string GetWebSocketConnectionString()
        {
            string response;
            using (var webClient = new WebClient())
            {
                //uses the marvin bot apikey
                response =
                    webClient.DownloadString("https://slack.com/api/rtm.start?token=xoxb-18091593092-Zfbf6UOoVNAsT0FrXLu259eG");
            }

            var rtmStartResponse = JsonConvert.DeserializeObject<RtmStartResponse>(response);
            return rtmStartResponse.url;
        }

        private static void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            var baseEvent = JsonConvert.DeserializeObject<BaseEvent>(e.Message);
            WriteLine($"Message received of type {baseEvent.Type}");

            if (baseEvent.Type == "message")
            {
                var messageEvent = JsonConvert.DeserializeObject<MessageEvent>(e.Message);

                WriteLine(messageEvent.Text);

                var messageCommand = new MessageCommand
                {
                    channel = messageEvent.Channel,
                    text = $"I'm in parrot mode: {messageEvent.Text}"
                };

                webSocket.Send(JsonConvert.SerializeObject(messageCommand));
            }

        }
    }
}
