using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class LanguageFactory
    {
        protected Stack<Component> components = new Stack<Component>();
        
        public abstract string GetLanguageName();
        public abstract string GetWarning();
        public abstract string[] GetAvalibleComponents();

        public void AddComponent(string type, int xCoordinate, int yCoordinate, int height, int width)
        {
            components.Push(new Library.Component(type, xCoordinate, yCoordinate, height, width));
        }
        public void RemoveComponent()
        {
            components.Pop();
        }

        public abstract string GenerateUI();
    }
}
