using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class LanguageFactory
    {
        protected Stack<string> components = new Stack<string>();
        
        public abstract string GetLanguageName();
        public abstract string[] GetAvalibleComponents();

        public void AddComponent(string s)
        {
            components.Push(s);
        }
        public void RemoveComponent()
        {
            components.Pop();
        }

        public abstract string GenerateUI();
    }
}
