﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class WpfLanguageFactory : LanguageFactory
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
            return "WPF";
        }

        public override void RemoveComponent()
        {
            throw new NotImplementedException();
        }
    }
}
