namespace Holiday.MessageTemplates
{
    public class RejectionMessageTemplate: MessageTemplate
    {
        private const string rejectionMessageSubject = "Cerere de concediu rejectata";
        private const string rejectionMessageBody = "Subsemnatul {ManagerName} nu aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public RejectionMessageTemplate()
            : base(rejectionMessageBody, rejectionMessageSubject)
        {
        }
    }
}