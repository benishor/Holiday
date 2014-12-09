using System;

namespace Holiday
{
    public class Message
    {
        private string from;
        private string to;
        private string cc;

        private readonly MessageTemplate t;

        public Message(MessageTemplate template)
        {
            t = template;
        }

        public void SetFrom(string from)
        {
            this.from = from;
        }

        public void SetTo(string to)
        {
            this.to = to;
        }

        public void SetCC(string cc)
        {
            this.cc = cc;
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
            ChannelLocator.Channel.Send(from, to, cc, t.Subject, t.Render());
        }

    }
}