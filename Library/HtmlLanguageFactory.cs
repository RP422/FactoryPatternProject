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
        public override string GetWarning()
        {
            return "Any values placed in the X Coordinate\nand Y Coordinate text boxes will be ignored";
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

            string generatedHtml = "";
            string generatedCss = "";

            int labelID = 0;
            int buttonID = 0;

            string componentID = "";

            Component[] usedComponents = components.ToArray();
            for(int x = usedComponents.Length - 1; x >= 0; x--)
            {
                switch (usedComponents[x].type)
                {
                    case "Label":
                        componentID = "label" + ++labelID;
                        generatedHtml += "\t<p id=\"" + componentID + "\">Label</p>\n";
                        break;
                    case "Button":
                        componentID = "button" + ++buttonID;
                        generatedHtml += "\t<button id=\"" + componentID + "\" type=\"button\">Button</button>\n";
                        break;
                }

                generatedCss += "\n\n#" + componentID + " {\n\theight: " + usedComponents[x].height + "px;\n\twidth: " + usedComponents[x].width + "px;\n}";
            }


            return "HTML:\n\n" + htmlPrefix + generatedHtml + htmlPostfix + "\n\nCSS:" + generatedCss;
        }
    }
}
