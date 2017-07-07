using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banderas.Model
{
   public  class Geo
    {
        private string north;

        public string North
        {
            get { return north; }
            set { north = value; }
        }
        private string south;

        public string South
        {
            get { return south; }
            set { south = value; }
        }
        private string west;

        public string West
        {
            get { return west; }
            set { west = value; }
        }

        private string east;

        public string East
        {
            get { return east; }
            set { east = value; }
        }
    }
}
