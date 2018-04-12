using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private LanguageFactory[] factories = 
            {
                new HtmlLanguageFactory(),
                new WpfLanguageFactory()
            };

        private string[] languages;
        private string[] currentComponents;

        private LanguageFactory currentFactory;
        public MainWindow()
        {
            InitializeComponent();

            string[] languages = new string[factories.Length];
            for(int x = 0; x < factories.Length; x++)
            {
                languages[x] = factories[x].GetLanguageName();
            }
        }

        private void languageSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            // Define the new factory
            string language = languages[languageComboBox.SelectedIndex];
            switch(language)
            {
                case "HTML":
                    currentFactory = new HtmlLanguageFactory();
                    break;
                case "WPF":
                    currentFactory = new WpfLanguageFactory();
                    break;
            }

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
        }

        private void addComponentButton_Click(object sender, RoutedEventArgs e)
        {
            currentFactory.AddComponent(currentComponents[componentComboBox.SelectedIndex]);
        }

        private void removeComponentButton_Click(object sender, RoutedEventArgs e)
        {
            currentFactory.RemoveComponent();
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            string generatedUI = currentFactory.GenerateUI();

            // Open new text box and display
        }
    }
}
