//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace weeks2
//{
//    internal class week2_1
//    {
//        static void Main(string[] args)
//        {            
//            int targetNumber = new Random().Next(1, 101);
//            int guess = 0;
//            int count = 0;
//            Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

//            while (guess != targetNumber)
//            {
//                Console.Write("추측한 숫자를 입력하세요.");
//                guess = int.Parse(Console.ReadLine());
//                count++;
//                if (guess == targetNumber)
//                {
//                    Console.WriteLine($"정답입니다! {count}번만에 맞추셨습니다.");
//                    break;
//                }
//                else if (guess < targetNumber)
//                    Console.WriteLine($"{guess}는 targetNumber보다 작습니다.");
//                else Console.WriteLine($"{guess}는 targetNumber보다 큽니다.");
//            }

//        }

//    }
//}
