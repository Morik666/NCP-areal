using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    public class Label
    {
        public String name { get; set; }

        public double alpha { get; set; }

        public double beta { get; set; }

        public double psi { get; set; }

        public override string ToString()
        {
            return name + '|' + alpha + '|' + beta + '|' + psi + '|';
        }
    }
}
