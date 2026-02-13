using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Project_v2
{
    internal class Ree
    {
        public string bah { get; set; }
        public string wah { get; set; }

        public override string ToString()
        {
            return $"{bah}";
        }
    }
    internal class Dingus : Ree
    {

    }
}
