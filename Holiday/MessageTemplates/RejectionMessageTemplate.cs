namespace Holiday.MessageTemplates
{
    public class RejectionMessageTemplate: MessageTemplate
    {
        private const string subject = "Cerere de concediu rejectata";
        private const string body = "Subsemnatul {ManagerName} nu aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public RejectionMessageTemplate()
            : base(subject, body)
        {
        }
    }
}