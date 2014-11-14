using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly string employee;
        private readonly string manager;
        private readonly DateTime start;
        private readonly DateTime end;

        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
        {
            this.employee = employee;
            this.manager = manager;
            this.start = start;
            this.end = end;
            Submit();
        }

        private void Submit()
        {
            var body =
                string.Format(
                    "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.",
                    employee, start.ToShortDateString(), end.ToShortDateString());
            SendMessage(employee, manager, "New holiday request", body);
        }

        public void Approve()
        {
            var body = 
                string.Format(
                    "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.",
                    manager, start.ToShortDateString(), end.ToShortDateString(), employee);

            SendMessage(manager, "hr", "Holiday request approved", body);
        }

        private static void SendMessage(string from, string to, string subject, string body)
        {
            Message message = new Message {From = from, To = to, Subject = subject, Body = body};
            message.Send();
        }
    }
}