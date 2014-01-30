using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementSpeller
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Element> elements = InitialiseElements();

            Console.WriteLine("Type a word to search the periodic table.\nType :q to quit.\n");
            Console.Write(" > ");

            string input;
            while ((input = Console.ReadLine()) != ":q")
            {
                Stack<Solution> stack = new Stack<Solution>();
                stack.Push(new Solution(input));

                Solution s;
                Solution s1;
                String nextSymbol;
                Element newElem;
                List<Element> newElems;
                String newString;
                int numOfResults = 0;

                while (stack.Count != 0)
                {
                    s = stack.Pop();
                    if (s.IsComplete())
                    {
                        s.PrintSolution();
                        numOfResults++;
                    }
                    else
                    {
                        int min = Math.Min(3, s.MaxLength());
                        for (int i = 1; i <= min; i++)
                        {
                            nextSymbol = s.GetNextSymbol(i);
                            if ((newElem = elements.Find(x => x.Symbol.ToLower()==nextSymbol)) != null)
                            {
                                newElems = new List<Element>();
                                foreach (Element elem in s.elems)
                                {
                                    newElems.Add(elem);
                                }
                                newElems.Add(newElem);
                                newString = s.stringToParse.Substring(i);
                                s1 = new Solution(newString, newElems);
                                stack.Push(s1);
                            }
                        }
                    }
                }
                if (numOfResults == 0)
                {
                    Console.WriteLine("\n Sorry, not possible!\n");
                }
                Console.Write(" > ");
            }
        }

        private static List<Element> InitialiseElements()
        {
            List<Element> elements = new List<Element>();

            StreamReader file = new StreamReader("periodictable.csv");
            Element e;
            string line;
            string[] splitline;

            while ((line = file.ReadLine()) != null)
            {
                splitline = line.Split(',');
                e = new Element(int.Parse(splitline[0]), splitline[2], splitline[1]);
                elements.Add(e);
            }
            return elements;
        }
    }
}
