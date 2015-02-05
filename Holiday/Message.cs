using System;

namespace Holiday
{
    public class Message
    {
        public string From;
        public string To;
        public string CC;
        public string Subject;
        public string Body;

        public static Message SubmissionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string submissionMessageSubject = "Cerere de concediu";
            const string submissionMessageBody = "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.";

            return new Message
            {
                From = employee.Email,
                To = manager.Email,
                CC = Employee.HR().Email,
                Subject = submissionMessageSubject,
                Body = string.Format(submissionMessageBody, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }


        public static Message ApprovalMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string approvalMessageSubject = "Cerere de concediu aprobata";
            const string approvalMessageBody = "Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                From = manager.Email,
                To = Employee.HR().Email,
                CC = employee.Email,
                Subject = approvalMessageSubject,
                Body = string.Format(approvalMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        public static Message RejectionMessage(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            const string rejectionMessageSubject = "Cerere de concediu rejectata";
            const string rejectionMessageBody = "Subsemnatul {0} nu aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.";
            return new Message
            {
                From = manager.Email,
                To = employee.Email,
                CC = Employee.HR().Email,
                Subject = rejectionMessageSubject,
                Body = string.Format(rejectionMessageBody, manager.Name, employee.Name, start.ToShortDateString(), end.ToShortDateString())
            };
        }

        public void Send()
        {
            ChannelLocator.Channel.Send(this);
        }
    }

}