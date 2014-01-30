using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementSpeller
{
    class Element
    {
        private int num;
        private string symbol;
        private string name;

        public Element(int num, string symbol, string name)
        {
            this.num = num;
            this.symbol = symbol;
            this.name = name;
        }

        public override string ToString()
        {
            return (Padding(this.num.ToString().Length) + this.num.ToString() + ": " + this.symbol + Padding(this.symbol.Length) + "- " + this.name);
        }

        private string Padding(int i)
        {
            string padding = "";
            int j = 4 - i;
            for (int k = 0; k < j; k++)
            {
                padding += " ";
            }
            return padding;
        }

        public string Symbol
        {
            get { return symbol; }
        }
    }
}
