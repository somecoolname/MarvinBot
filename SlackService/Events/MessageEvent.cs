namespace SlackService.Events
{
    public class MessageEvent : BaseEvent
    {
         public string Text { get; set; }
    }
}