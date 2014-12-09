namespace Holiday
{
    public class SubmissionMessageTemplate : Template
    {
        public SubmissionMessageTemplate(string employeeName, string start, string end)
        {
            Subject = submissionMessageSubject;
            BodyTemplate = submissionMessageBody;
            SetParameter("EmployeeName", employeeName);
            SetParameter("Start", start);
            SetParameter("End", end);
        }
    }
}