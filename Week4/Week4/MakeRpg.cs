using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    internal class MakeRpg
    {
        public void Main(string[] args)
        {
            switch (Console.KeyAvailable)
            {
                case true:
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            break;  
                    }
                    break;
            }
        }
    }
}
