using System.Collections.Generic;

namespace Holiday
{
    public class Template
    {
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