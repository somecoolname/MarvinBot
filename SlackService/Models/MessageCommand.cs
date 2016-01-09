using System.Diagnostics.CodeAnalysis;

namespace SlackService.Models
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class MessageCommand
    {
        public int id { get; set; }
        public string type => "message";
        public string channel { get; set; }
        public string text { get; set; }
        
        /*
        {
    "id": 1,
    "type": "message",
    "channel": "C024BE91L",
    "text": "Hello world"
}
        */
    }
}