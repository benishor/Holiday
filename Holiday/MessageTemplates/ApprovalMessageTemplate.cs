namespace Holiday.MessageTemplates
{
    public class ApprovalMessageTemplate : MessageTemplate
    {
        private const string subject = "Cerere de concediu aprobata";
        private const string body = "Subsemnatul {ManagerName} aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public ApprovalMessageTemplate()
            : base(subject, body)
        {
        }
    }
}