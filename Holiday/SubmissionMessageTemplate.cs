namespace Holiday
{
    public class SubmissionMessageTemplate : Template
    {
        public const string submissionMessageSubject = "Cerere de concediu";
        public const string submissionMessageBody = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}.";

        public SubmissionMessageTemplate(string employeeName, string managerName, string start, string end)
        {
            Subject = submissionMessageSubject;
            BodyTemplate = submissionMessageBody;
            SetParameter("EmployeeName", employeeName);
            SetParameter("ManagerName", managerName);
            SetParameter("Start", start);
            SetParameter("End", end);
        }
    }
}