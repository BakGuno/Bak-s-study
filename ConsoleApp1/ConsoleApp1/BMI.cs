/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class BMI
    {
        static void Main()
        {
            //BMI 계산식 : 몸무게/키^2
            bool ok = false;
            float mass = 0;
            float height = 0;
            while (!ok)
            {
                Console.Write("몸무게(Kg)와 키(cm)를 입력해주세요. ex)몸무게 키 : ");
                string input = Console.ReadLine();
                string[] mashei = input.Split(' ');
                if (mashei.Length != 2)
                    continue;
                bool check1 = float.TryParse(mashei[0], out mass);
                bool check2 = float.TryParse(mashei[1], out height);
                if (!(check1 && check2))
                    continue;
                ok = true;
            }
            float BMI = mass / (float)Math.Pow(height / 100, 2);
            string bman = "";
            if (BMI > 0 && 18.5 >= BMI)
                bman = "저체중";
            else if (BMI > 18.5 && BMI <= 25)
                bman = "정상";
            else if (BMI > 25 && BMI <= 30)
                bman = "과체중";
            else if (BMI > 30 && BMI <= 35)
                bman = "1단계 비만";
            else if (BMI > 35 && BMI <= 40)
                bman = "2단계 비만";
            else bman = "3단계 비만";
            Console.WriteLine($"입력하신 정보의 BMI는 {BMI:N2}이며 현재 {bman}입니다.");
        }
    }
}
*/