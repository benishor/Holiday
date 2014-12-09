namespace Holiday.MessageTemplates
{
    public class SubmissionMessageTemplate : MessageTemplate
    {
        private const string submissionMessageSubject = "Cerere de concediu";
        private const string submissionMessageBody = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}.";

        public SubmissionMessageTemplate() 
            : base(submissionMessageBody, submissionMessageSubject)
        {
        }
    }
}