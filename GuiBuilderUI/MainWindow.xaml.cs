using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GuiBuilderUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LanguageFactory[] allFactories = // To add a new language to this window, the only change you would 
        {                                        //   need to make is adding a reference to an instance of it here.
            new WpfLanguageFactory(),
            new HtmlLanguageFactory()
        };

        private LanguageFactory currentFactory;

        private string[] languages;
        private string[] currentComponents;

        public MainWindow()
        {
            InitializeComponent();

            languages = new string[allFactories.Length];
            
            for(int x = 0; x < allFactories.Length; x++)
            {
                languages[x] = allFactories[x].GetLanguageName();
                languageComboBox.Items.Add(languages[x]);
            }

            // Default to the first language in the array
            languageComboBox.SelectedIndex = 0;
            SwitchLanguage(0);
        }

        private void SwitchLanguage(int factoryIndex)
        {
            // Define the new factory
            // Note: LanguageFactory objects have some "memory" of what components were added to them. 
            //   Defining a new factory like this "clears" that memory.
            currentFactory = (LanguageFactory)Activator.CreateInstance(allFactories[factoryIndex].GetType());

            // Switch out the warning
            warningLabel.Content = currentFactory.GetWarning();

            // Replace the components list with the new one
            currentComponents = currentFactory.GetAvalibleComponents();
            while (!componentComboBox.Items.IsEmpty)
            {
                componentComboBox.Items.RemoveAt(0);
            }
            for (int x = 0; x < currentComponents.Length; x++)
            {
                componentComboBox.Items.Add(currentComponents[x]);
            }

            // Clear out the list of components
            componentList.Content = "";

            // Reset the selected index
            componentComboBox.SelectedIndex = 0;
        }

        private void languageSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchLanguage(languageComboBox.SelectedIndex);
        }

        private void addComponentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int xCoord = Int32.Parse(xBox.Text);
                int yCoord = Int32.Parse(yBox.Text);
                int height = Int32.Parse(heightBox.Text);
                int width = Int32.Parse(widthBox.Text);

                currentFactory.AddComponent(currentComponents[componentComboBox.SelectedIndex], xCoord, yCoord, height, width);
                componentList.Content += "\n" + currentComponents[componentComboBox.SelectedIndex];
            }
            catch(Exception ex)
            {

            }
        }

        private void removeComponentButton_Click(object sender, RoutedEventArgs e)
        {
            currentFactory.RemoveComponent();
            string content = componentList.Content.ToString();
            int lastLineBreak = content.LastIndexOf('\n');

            if(lastLineBreak != -1)
            {
                content = content.Substring(0, lastLineBreak);
            }
            else
            {
                content = "";
            }

            componentList.Content = content;
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            string generatedUI = currentFactory.GenerateUI();

            CodeDisplayWindow newWindow = new CodeDisplayWindow();

            newWindow.CodeLabel.Content = generatedUI;
            newWindow.Show();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
