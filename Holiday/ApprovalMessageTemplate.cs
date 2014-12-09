namespace Holiday
{
    public class ApprovalMessageTemplate : MessageTemplate
    {
        public const string approvalMessageSubject = "Cerere de concediu aprobata";
        public const string approvalMessageBody = "Subsemnatul {ManagerName} aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public ApprovalMessageTemplate()
            : base(approvalMessageBody, approvalMessageSubject)
        {
        }
    }
}