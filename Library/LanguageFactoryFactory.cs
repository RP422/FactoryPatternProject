using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class LanguageFactoryFactory
    {
        public static LanguageFactory[] CreateAvailableLanguages()
        {
            return new LanguageFactory[] // To add a new language to this window, the only change you would 
            {                            //   need to make is adding a reference to an instance of it here.
                new WpfLanguageFactory(),
                new HtmlLanguageFactory()
            };
        }
    }
}
