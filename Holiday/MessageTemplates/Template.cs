using System.Collections.Generic;

namespace Holiday.MessageTemplates
{
    public class Template
    {
        private readonly string template = "";

        private readonly Dictionary<string, string> parameters = new Dictionary<string, string>();

        public Template(string template)
        {
            this.template = template;
        }

        public void SetParameter(string name, string value)
        {
            parameters[name] = value;
        }

        public string GetParameter(string name)
        {
            return parameters[name];
        }

        public string Render()
        {
            string result = template;

            foreach (var parameter in parameters)
            {
                result = result.Replace("{"+ parameter.Key + "}", parameter.Value);
            }
            return result;
        }
    }
}