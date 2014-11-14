using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly string employee;
        private readonly string manager;

        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
        {
            this.employee = employee;
            this.manager = manager;
            Submit();
        }

        private void Submit()
        {
            SendMessage(employee, manager, "New holiday request");
        }

        public void Approve()
        {
            SendMessage(manager, "hr", "Holiday request approved");
        }

        private static void SendMessage(string from, string to, string subject)
        {
            Message message = new Message {From = from, To = to, Subject = subject};
            message.Send();
        }
    }
}