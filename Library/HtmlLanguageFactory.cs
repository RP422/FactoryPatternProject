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
            throw new NotImplementedException();
        }

        public override string GenerateUI()
        {
            throw new NotImplementedException();
        }
    }
}
