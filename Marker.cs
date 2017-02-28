using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog
{
    public class Marker
    {
        public int position { get; set; }

        public int label { get; set; }

        public double splitting { get; set; }

        public int check = 1;

        public override string ToString()
        {
            return "" + position + '|' + label + '|' + splitting + '|' + check + '|';
        }

        public string[] ToRow()
        {
            if (check == 1) return new string[] { position.ToString(), label.ToString(), "True", splitting.ToString() };
            else  return new string[] { position.ToString(), label.ToString(), "True", splitting.ToString() };
        }

    }
}
