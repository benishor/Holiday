using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        private Message lastMessage;

        public Message GetLastMessage()
        {
            return lastMessage;
        }

        public void Send(Message message)
        {
            lastMessage = message;
        }
    }
}