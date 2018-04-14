using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class WpfLanguageFactory : LanguageFactory
    {
        WpfLanguageFactory wpfFactory = new WpfLanguageFactory();
        
        public List<String> listOfComponents = new List<string>();
        public override string GetLanguageName()
        {
            return "WPF";
        }

        public override string[] GetAvalibleComponents()
        {
            return new string[]
            {
                "Label",
                "ComboBox",
                "TextBox",
                "Slider"
            };
        }

        public override string GenerateUI()
        {
            String UI = "";
            foreach(string component in listOfComponents)
            {
                if (component.Contains("Label"))
                {
                    UI += "<Label x: Name = /\"componentList\"HorizontalAlignment = \"Right\" Margin = \"0,15,15,15\" Width = \"170\" />" + "\n";
                }
                else if (component.Contains("ComboBox"))
                {
                    UI += "<Button x:Name=\"generateButton\" Content=\"Generate UI\" HorizontalAlignment=\"Left\" Margin=\"15,0,0,15\" VerticalAlignment=\"Bottom\" Width=\"100\" Click=\"generateButton_Click\"/>" + "\n";
                }
                else if (component.Contains("TextBox"))
                {
                    UI += "<Slider HorizontalAlignment=\"Left\" Margin=\"388,160,0,0\" VerticalAlignment=\"Top\" Height=\"50\" Width=\"97\"/>" + "\n";
                }
                else if (component.Contains("Slider"))
                {
                    UI += "<ScrollBar HorizontalAlignment=\"Left\" Height=\"82\" Margin=\"155,137,0,0\" VerticalAlignment=\"Top\"/>" + "\n";
                }
            }
            return UI;
        }
    }
}
