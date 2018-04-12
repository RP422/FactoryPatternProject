using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class LanguageFactory
    {
        public abstract string GetLanguageName();
        public abstract string[] GetAvalibleComponents();

        public abstract void AddComponent(string s);
        public abstract void RemoveComponent();

        public abstract string GenerateUI();
    }
}
