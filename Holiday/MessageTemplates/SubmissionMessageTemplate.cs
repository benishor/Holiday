namespace Holiday.MessageTemplates
{
    public class SubmissionMessageTemplate : MessageTemplate
    {
        private const string subject = "Cerere de concediu";
        private const string body = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}.";

        public SubmissionMessageTemplate() 
            : base(subject, body)
        {
        }
    }
}