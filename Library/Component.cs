using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Component
    {
        public string type     { get; private set; }
        public int xCoordinate { get; private set; }
        public int yCoordinate { get; private set; }
        public int height      { get; private set; }
        public int width       { get; private set; }

        public Component(string type, int xCoordinate, int yCoordinate, int height, int width)
        {
            this.type = type;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.height = height;
            this.width = width;
        }
    }
}
