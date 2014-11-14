using System;

namespace Holiday
{
    public class Message
    {
        private string from;
        private string to;
        private string subject;
        private string body;

        private const string SubmissionMessageSubject = "Cerere de concediu";
        private const string SubmissionMessageBody = "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.";

        public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            return new Message
            {
                from = employee.Email,
                to = manager.Email,
                subject = SubmissionMessageSubject,
                body = string.Format(SubmissionMessageBody, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        private const string ApprovalMessageSubject = "Cerere de concediu aprobata";
        private const string ApprovalMessageBody = "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";

        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            return new Message
            {
                from = manager.Email,
                to = "hr",
                subject = ApprovalMessageSubject,
                body = string.Format(ApprovalMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }


        public void Send()
        {
            ChannelLocator.Channel.Send(from, to, subject, body);
        }
    }

}