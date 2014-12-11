namespace Holiday.MessageTemplates
{
    static public class MessageTemplateRepository
    {
        static public MessageTemplate GetSubmission()
        {
            return new MessageTemplate
                {
                    Subject = "Cerere de concediu",
                    BodyTemplate = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}."
                };
        }

        static public MessageTemplate GetApproval()
        {
            return new MessageTemplate
            {
                Subject = "Cerere de concediu aprobata",
                BodyTemplate = "Subsemnatul {ManagerName} aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}."
            };
        }

        static public MessageTemplate GetRejection()
        {
            return new MessageTemplate
            {
                Subject = "Cerere de concediu rejectata",
                BodyTemplate = "Subsemnatul {ManagerName} nu aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}."
            };
        }
    }
}