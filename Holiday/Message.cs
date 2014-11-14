namespace Holiday
{
    public class Message
    {
        public string From;
        public string To;
        public string Subject;

        public void Send()
        {
            ChannelLocator.Channel.Send(this);
        }
    }
}