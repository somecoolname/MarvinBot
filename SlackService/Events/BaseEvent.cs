namespace SlackService.Events
{
    public class BaseEvent
    {
        public string Type { get; set; }
        public string Channel { get; set; }
        public string SubType { get; set; }
    }

    /*
    
    {
    "type": "message",
    "channel": "C2147483705",
    "user": "U2147483697",
    "text": "Hello world",
    "ts": "1355517523.000005"
}
    
    
    */
}