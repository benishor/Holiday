using System.Collections.Generic;

namespace Holiday
{
    public class Template
    {
        public const string submissionMessageSubject = "Cerere de concediu";
        public const string submissionMessageBody = "Subsemnatul {EmployeeName}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {Start} - {End}.";

        public const string approvalMessageSubject = "Cerere de concediu aprobata";
        public const string approvalMessageBody = "Subsemnatul {ManagerName} aprob cererea de concediu de odihna pe perioada {Start} - {End} pentru {EmployeeName}.";

        public string Subject = "";

        public string Body
        {
            get
            {
                string result = BodyTemplate;

                foreach (var parameter in parameters)
                {
                    result = result.Replace("{"+ parameter.Key + "}", parameter.Value);
                }
                return result;
            }
        }

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();
        public string BodyTemplate = "";

        public void SetParameter(string name, string value)
        {
            parameters[name] = value;
        }

        public string GetParameter(string name)
        {
            return parameters[name];
        }
    }
}