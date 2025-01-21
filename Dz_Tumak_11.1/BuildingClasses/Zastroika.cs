using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Tumak_11._1.BuildingClasses
{
    public class Zastroika
    {
        public Building [] buildings = new Building[10];

        public Building this[int index]
        {
            get { return buildings[index]; }
            set { buildings[index] = value; }

        }
    }
    
}
