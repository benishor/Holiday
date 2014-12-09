namespace Holiday
{
    public class SubmissionMessageTemplate : MessageTemplate
    {
        public const string submissionMessageSubject = "Cerere de concediu";
        public const string submissionMessageBody = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}.";

        public SubmissionMessageTemplate() 
            : base(submissionMessageBody)
        {
            Subject = submissionMessageSubject;
        }
    }
}