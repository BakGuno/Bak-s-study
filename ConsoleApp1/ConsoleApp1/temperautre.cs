/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class temperautre
    {
        static void Main()
        {
            //섭씨 > 화씨  (섭씨 * 9 / 5) + 32
            bool ok = false;
            float Temp=0;
            string temp = "";
            while (ok == false)
            {
                Console.Write("섭씨 온도를 숫자만 입력해주세요. : ");
                temp = Console.ReadLine();                
                bool check = float.TryParse(temp, out Temp);
                if (check == false)
                    continue;
                ok = true;
            }
            float Fahren = (Temp * 9 / 5) + 32;
            Console.WriteLine($"입력하신 섭씨 {temp:N1}도는 화씨로 {Fahren:N1}도 입니다.");
        }
    }
}
*/