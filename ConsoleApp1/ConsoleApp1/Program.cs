/*using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {       
        static void Main(string[] args)
        {
            //변수 선언, 초기화
            bool ok = false;
            int num1 = 0;
            int num2 = 0;
            int sum;
            string[] numbers = new string[2];

            while (ok == false) //'숫자'로 '2개'일때만 넘어가도록
            {
                Console.Write("숫자를 입력해주세요. ex)5 5 :");
                string input = Console.ReadLine();
                numbers = input.Split(' ');
                if (numbers.Length != 2)
                    continue;
                bool check1 = int.TryParse(numbers[0], out num1);
                bool check2 = int.TryParse(numbers[1], out num2);
                if (!(check1 && check2))
                    continue;
                ok = true;
            }
           

            Console.WriteLine("두 수에 적용할 연산을 선택해주세요. ");
            Console.Write("기호로 표시하시면 됩니다. ex)+,-,*,/  : ");           
            string arith = Console.ReadLine();            
            //사칙연산 기호에 맞는 것만 판단해서 사용
            while (!(arith == "*" || arith == "+" || arith == "-" || arith == "/"))
            {
                Console.Write("다시 선택해주세요. : ");
                arith = Console.ReadLine();
            }
            if (arith == "*")
                sum = num1 * num2;
            else if (arith == "+")
                sum = num1 + num2;
            else if (arith == "-")
                 sum = num1 - num2;
            else sum = num1 / num2;

            Console.WriteLine($"{num1} {arith} {num2} = {sum}");
        }        
    }
    
    
}
*/