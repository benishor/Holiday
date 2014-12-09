namespace Holiday
{
    public class RejectionMessageTemplate: MessageTemplate
    {
        public const string rejectionMessageSubject = "Cerere de concediu rejectata";
        public const string rejectionMessageBody = "Subsemnatul {ManagerName} nu aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public RejectionMessageTemplate()
            : base(rejectionMessageBody)
        {
            Subject = rejectionMessageSubject;
        }
    }
}