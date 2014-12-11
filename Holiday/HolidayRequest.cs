using System;
using Holiday.MessageTemplates;

namespace Holiday
{
    public class HolidayRequest
    {
        private readonly Employee employee;
        private readonly Employee manager;
        private readonly DateTime start;
        private readonly DateTime end;

        public HolidayRequest(Employee employee, Employee manager, DateTime start, DateTime end, string type)
        {
            this.employee = employee;
            this.manager = manager;
            this.start = start;
            this.end = end;
        }

        public void Submit()
        {
            var message = CreateMessage(MessageTemplateRepository.GetSubmission());

            message.From = employee.Email;
            message.To = manager.Email;
            message.CC = Employee.HR().Email;

            message.Send();
        }

        public void Approve()
        {
            var message = CreateMessage(MessageTemplateRepository.GetApproval());

            message.From = manager.Email;
            message.To = Employee.HR().Email;
            message.CC = employee.Email;

            message.Send();
        }

        public void Reject()
        {
            var message = CreateMessage(MessageTemplateRepository.GetRejection());

            message.From = manager.Email;
            message.To = employee.Email;
            message.CC = Employee.HR().Email;

            message.Send();
        }

        private Message CreateMessage(MessageTemplate template)
        {
            Message result = new Message();

            FillView(result);

            result.SetSubject(template.Subject);
            result.SetBodyTemplate(template.BodyTemplate);

            return result;
        }

        private void FillView(IHolidayRequestView result)
        {
            result.SetEmployee(employee);
            result.SetManager(manager);
            result.SetStart(start);
            result.SetEnd(end);
        }
    }
}