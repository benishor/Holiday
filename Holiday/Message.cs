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
            const string submissionMessageSubject = "Cerere de concediu";
            const string submissionMessageBody = "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.";

            return new Message
            {
                from = employee.Email,
                to = manager.Email,
                subject = submissionMessageSubject,
                body = string.Format(submissionMessageBody, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string approvalMessageSubject = "Cerere de concediu aprobata";
            const string approvalMessageBody = "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                from = manager.Email,
                to = Employee.HR().Email,
                subject = approvalMessageSubject,
                body = string.Format(approvalMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        public static Message RejectionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string rejectionMessageSubject = "Cerere de concediu rejectata";
            const string rejectionMessageBody = "Subsemnatul {0} nu aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                from = manager.Email,
                to = employee.Email,
                subject = rejectionMessageSubject,
                body = string.Format(rejectionMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(from, to, subject, body);
        }
    }

}