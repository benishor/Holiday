namespace Holiday
{
    public interface IChannel
    {
        void Send(Message message);
    }
}