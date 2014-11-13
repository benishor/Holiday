namespace Holiday
{
    public class Message
    {
        public string From;
        public string To;

        public void Send()
        {
            ChannelLocator.Channel.Send(this);
        }
    }
}