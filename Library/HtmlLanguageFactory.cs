using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class HtmlLanguageFactory : LanguageFactory
    {
        public override void AddComponent(string s)
        {
            throw new NotImplementedException();
        }

        public override string GenerateUI()
        {
            throw new NotImplementedException();
        }

        public override string[] GetAvalibleComponents()
        {
            throw new NotImplementedException();
        }

        public override string GetLanguageName()
        {
            return "HTML";
        }

        public override void RemoveComponent()
        {
            throw new NotImplementedException();
        }
    }
}
