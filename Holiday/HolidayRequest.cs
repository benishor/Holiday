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
            SendMessage(employee, manager);
        }

        public void Approve()
        {
            SendMessage(manager, "hr");
        }

        private static void SendMessage(string from, string to)
        {
            Message message = new Message {From = @from, To = to};
            message.Send();
        }
    }
}