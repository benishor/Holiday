using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        private Message lastSentMessage;

        public Message GetLastSentMail()
        {
            return lastSentMessage;
        }

        public void Send(Message message)
        {
            lastSentMessage = message;
        }
    }
}