namespace Holiday
{
    public interface IChannel
    {
        void Send(string from, string to, string subject, string body);
    }
}