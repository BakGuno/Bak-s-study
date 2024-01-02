using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    internal class Class4
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

        static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Func<int, int, int> addFunc = Add;
            int result = addFunc(3, 5);
            Console.WriteLine("결과 : "+result);

            Action<string> printAction = PrintMessage;
            printAction("Hello, World");
        }
    }
}
