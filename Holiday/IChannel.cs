namespace Holiday
{
    public interface IChannel
    {
    	// CR: I like this refactoring since our last discussion. It feels much more natural.
        void Send(Message message);
    }
}