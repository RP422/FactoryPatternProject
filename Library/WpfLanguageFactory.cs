using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class WpfLanguageFactory : LanguageFactory
    {
        public override string GetLanguageName()
        {
            return "WPF";
        }

        public override string GetWarning()
        {
            return "";
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
            string wpfPrefix = "<Window x:Class=\"GuiBuilderUI.MainWindow\"\n" +
                               "\txmlns = \"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"\n" +
                               "\txmlns: x = \"http://schemas.microsoft.com/winfx/2006/xaml\"\n" +
                               "\txmlns: d = \"http://schemas.microsoft.com/expression/blend/2008\"\n" +
                               "\txmlns: mc = \"http://schemas.openxmlformats.org/markup-compatibility/2006\"\n" +
                               "\txmlns: local = \"clr-namespace:GuiBuilderUI\"\n" +
                               "\tmc: Ignorable = \"d\"\n" +
                               "\tTitle = \"My Application\">\n\n" +
                               "\t< Grid Margin = \"0\" Background = \"#FFFFDD00\">\n";
            string wpfPostfix = "\t</ Grid >\n</ Window >";

            String UI = "";
            Component[] usedComponents = components.ToArray();
            
            int labelCount = 0;
            int comboBoxCount = 0;
            int textBoxCount = 0;
            int sliderCount = 0;

            for(int x = usedComponents.Length - 1; x >= 0; x--)
            {
                switch(usedComponents[x].type)
                {
                    case "Label":
                        UI += "\t\t<Label x: Name = /\"label" + ++labelCount + "\"HorizontalAlignment = \"Right\" " + 
                            "Margin = \"" + usedComponents[x].yCoordinate + "," + usedComponents[x].xCoordinate + ",0,0\"" +
                            "Height = \"" + usedComponents[x].height + "\" Width = \"" + usedComponents[x].width + "\"/>\n";
                        break;
                    case "ComboBox":
                        UI += "\t\t<ComboBox x:Name=\"comboBox" + ++comboBoxCount + " \"HorizontalAlignment = \"Right\" VerticalAlignment=\"Bottom\" " +
                            "Margin=\"" + usedComponents[x].yCoordinate + "," + usedComponents[x].xCoordinate + ",0,0\"" +
                            "Height = \"" + usedComponents[x].height + "\" Width = \"" + usedComponents[x].width + "\"/>\n";
                        break;
                    case "TextBox":
                        UI += "\t\t<TextBox x: Name = \"textBox" + ++textBoxCount + "\" HorizontalAlignment = \"Left\" VerticalAlignment = \"Top\" " +
                            "Margin=\"" + usedComponents[x].yCoordinate + "," + usedComponents[x].xCoordinate + ",0,0\" TextWrapping = \"Wrap\"" +
                            "Height = \"" + usedComponents[x].height + "\" Width = \"" + usedComponents[x].width + "\"/>\n";
                        break;
                    case "Slider":
                        UI += "\t\t<Slider x:Name=\"slider" + ++sliderCount + "\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Top\" " +
                            "Margin=\"" + usedComponents[x].yCoordinate + "," + usedComponents[x].xCoordinate + ",0,0\"" +
                            "Height = \"" + usedComponents[x].height + "\" Width = \"" + usedComponents[x].width + "\"/>\n";
                        break;
                }
            }
            return wpfPrefix + UI + wpfPostfix;
        }
    }
}
