namespace Holiday
{
    public class RejectionMessageTemplate: Template
    {
        public const string rejectionMessageSubject = "Cerere de concediu rejectata";
        public const string rejectionMessageBody = "Subsemnatul {ManagerName} nu aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public RejectionMessageTemplate(string employeeName, string managerName, string start, string end)
        {
            Subject = rejectionMessageSubject;
            BodyTemplate = rejectionMessageBody;
            SetParameter("EmployeeName", employeeName);
            SetParameter("ManagerName", managerName);
            SetParameter("Start", start);
            SetParameter("End", end);

        }
    }
}