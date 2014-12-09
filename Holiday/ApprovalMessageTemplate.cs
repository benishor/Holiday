namespace Holiday
{
    public class ApprovalMessageTemplate : Template
    {
        public const string approvalMessageSubject = "Cerere de concediu aprobata";
        public const string approvalMessageBody = "Subsemnatul {ManagerName} aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public ApprovalMessageTemplate(string employeeName, string managerName, string start, string end)
        {
            Subject = approvalMessageSubject;
            BodyTemplate = approvalMessageBody;
            SetParameter("EmployeeName", employeeName);
            SetParameter("ManagerName", managerName);
            SetParameter("Start", start);
            SetParameter("End", end);
        }
    }
}