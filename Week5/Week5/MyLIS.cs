using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    internal class MyLIS //문제가 있음, 제일 큰 값이 한 끝에서 두세번째쯤 있으면 이상해짐.
    {
        static void Main(string[] args)
        {
            Console.WriteLine("배열의 크기를 입력해주세요."); //배열 크기 받고
            string array = Console.ReadLine();

            int[] nums = new int[int.Parse(array)]; //배열 만들어준 다음

            Random rand = new Random();            

            Console.WriteLine("입력된 숫자는 ");
            for (int i = 0; i < nums.Length; i++) //랜덤으로 조건 범위 내의 숫자 생성
            {
                nums[i] = rand.Next(-((int)Math.Pow(10, 4)), (int)Math.Pow(10, 4));
                Console.Write($"{nums[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine($"최장 증가 수열의 길이는 {Findarray(nums)}입니다.");
        }

        static int Findarray(int[] arr)
        {
            int temp = 1;
            int beststreak = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (j == arr.Length - 1)
                    {
                        if (arr[i] < arr[j])
                            temp++;
                    }
                    else if (j < arr.Length - 1)
                        if (arr[i] < arr[j] && arr[j] > arr[j + 1])
                            temp++;
                }
                if (temp > beststreak)
                    beststreak = temp;
                temp = 1;
            }
            return beststreak;
        }
    }
}


