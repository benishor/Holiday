using System;

namespace Holiday
{
    public class Message
    {
        private string from;
        private string to;
        private string subject;
        private string body;

        public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string SubmissionMessageSubject = "Cerere de concediu";
            const string SubmissionMessageBody = "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.";

            return new Message
            {
                from = employee.Email,
                to = manager.Email,
                subject = SubmissionMessageSubject,
                body = string.Format(SubmissionMessageBody, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string ApprovalMessageSubject = "Cerere de concediu aprobata";
            const string ApprovalMessageBody = "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                from = manager.Email,
                to = Employee.HR().Email,
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