using System;

namespace Holiday
{
    public class Message
    {
        public string From;
        public string To;
        public string CC;

        private readonly MessageTemplate t;

        public Message(MessageTemplate template)
        {
            t = template;
        }

        public void SetEmployee(Employee employee)
        {
            t.SetEmployeeName(employee.Name);
        }

        public void SetManager(Employee manager)
        {
            t.SetManagerName(manager.Name);
        }

        public void SetStart(DateTime start)
        {
            t.SetStartDate(start);
        }

        public void SetEnd(DateTime end)
        {
            t.SetEndDate(end);
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(From, To, CC, t.Subject, t.Render());
        }

    }
}