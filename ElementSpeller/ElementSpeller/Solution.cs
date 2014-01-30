using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementSpeller
{
    class Solution
    {
        public string stringToParse;
        public List<Element> elems;

        public Solution(string str)
        {
            this.stringToParse = str.ToLower().Trim();
            this.elems = new List<Element>();
        }

        public Solution(string str, List<Element> elems)
        {
            this.stringToParse = str.ToLower();
            this.elems = elems;
        }

        public int MaxLength()
        {
            return stringToParse.Length;
        }

        public string GetNextSymbol(int lengthOfSym)
        {
            return stringToParse.Substring(0, lengthOfSym);
        }

        public bool IsComplete()
        {
            return stringToParse == "";
        }

        public void PrintSolution()
        {
            Console.Write("\n  ");
            foreach (Element elem in elems)
            {
                Console.Write(elem.Symbol);
            }
            Console.Write("\n");

            foreach (Element elem in elems)
            {
                Console.Write(elem + "\n");
            }
            Console.Write("\n");
        }
    }
}
