namespace Holiday
{
    public class ApprovalMessageTemplate : Template
    {
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