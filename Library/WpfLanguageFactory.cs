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

        public override List<String> GetAvalibleComponents()
        {
            String[] comps = wpfFactory.components.ToArray();
            String com = "";
            foreach(String comp in comps)
            {
                if (comp.Contains("Label"))
                {
                    com = "< Label x: Name = /\"componentList\"HorizontalAlignment = \"Right\" Margin = \"0,15,15,15\" Width = \"170\" />";
                    listOfComponents.Add(com);
                }
                else if (comp.Contains("ComboBox"))
                {
                    com = "<Button x:Name=\"generateButton\" Content=\"Generate UI\" HorizontalAlignment=\"Left\" Margin=\"15,0,0,15\" VerticalAlignment=\"Bottom\" Width=\"100\" Click=\"generateButton_Click\"/>";
                    listOfComponents.Add(com);
                }
                else if(comp.Contains("TextBox"))
                {
                    com = "<Slider HorizontalAlignment=\"Left\" Margin=\"388,160,0,0\" VerticalAlignment=\"Top\" Height=\"50\" Width=\"97\"/>";
                    listOfComponents.Add(com);
                }
                else if (comp.Contains("Slider"))
                {
                    com = "<ScrollBar HorizontalAlignment=\"Left\" Height=\"82\" Margin=\"155,137,0,0\" VerticalAlignment=\"Top\"/>";
                    listOfComponents.Add(com);
                }
            }
            return listOfComponents;
        }

        public override string GenerateUI()
        {
            String UI = "";
            foreach(string component in listOfComponents)
            {   
                UI += components + "\n";
            }
            return UI;
        }
    }
}
