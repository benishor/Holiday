using System;

namespace Holiday
{
    public class Message
    {
        public string From;
        public string To;
        public string CC;

        private readonly MessageTemplate template;

        public Message(MessageTemplate template)
        {
            this.template = template;
        }

        public void SetEmployee(Employee employee)
        {
            template.SetEmployeeName(employee.Name);
        }

        public void SetManager(Employee manager)
        {
            template.SetManagerName(manager.Name);
        }

        public void SetStart(DateTime start)
        {
            template.SetStartDate(start);
        }

        public void SetEnd(DateTime end)
        {
            template.SetEndDate(end);
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(From, To, CC, template.Subject, template.Render());
        }

    }
}