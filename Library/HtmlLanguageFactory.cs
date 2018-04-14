using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class HtmlLanguageFactory : LanguageFactory
    {
        public override string GetLanguageName()
        {
            return "HTML";
        }

        public override string[] GetAvalibleComponents()
        {
            return new string[]
            {
                "Label",
                "Button"
            };
        }

        public override string GenerateUI()
        {
            string htmlPrefix = "<DOCTYPE! HTML>\n<body>\n";
            string htmlPostfix = "</body>";
            string generatedUI = "";

            string[] usedComponents = components.ToArray();

            foreach (string component in usedComponents)
            {
                switch (component)
                {
                    case "Label":
                        generatedUI += "\t<p>Label</p>\n";
                        break;
                    case "Button":
                        generatedUI += "\t<button type=\"button\">Button</button>\n";
                        break;
                }
            }

            return htmlPrefix + generatedUI + htmlPostfix;
        }
    }
}
