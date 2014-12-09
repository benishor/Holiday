namespace Holiday
{
    public class RejectionMessageTemplate: Template
    {
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