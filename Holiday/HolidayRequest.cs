using System;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly string employee;
        private readonly string manager;
        private readonly DateTime start;
        private readonly DateTime end;

        const string submitMessageTemplate = "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.";
        const string approveMessageTemplate = "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";


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
            var message = CreateSubmissionMessage();
            message.Send();
        }

        public void Approve()
        {
            var message = CreateApprovalMessage();
            message.Send();
        }

        private Message CreateSubmissionMessage()
        {
            var body = string.Format(submitMessageTemplate, employee, start.ToShortDateString(), end.ToShortDateString());
            return CreateMessage(employee, manager, "New holiday request", body);
        }

        private Message CreateApprovalMessage()
        {
            var body = string.Format(approveMessageTemplate, manager, start.ToShortDateString(), end.ToShortDateString(),
                employee);
            return CreateMessage(manager, "hr", "Holiday request approved", body);
        }

        private static Message CreateMessage(string from, string to, string subject, string body)
        {
            Message message = new Message {From = from, To = to, Subject = subject, Body = body};
            return message;
        }
    }
}