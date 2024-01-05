//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week5
//{
//    internal class Longest_Increasing_Subsequence
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("배열의 크기를 입력해주세요."); //배열 크기 받고
//            string array = Console.ReadLine(); 

//            int[] nums = new int[int.Parse(array)+1]; //배열 만들어준 다음

//            Random rand = new Random(); 
//            nums[0] = 0; //알고리즘 상 첫칸은 0

//            Console.WriteLine("입력된 숫자는 ");
//            for (int i = 1; i < nums.Length; i++) //랜덤으로 조건 범위 내의 숫자 생성
//            {
//                nums[i] = rand.Next(-((int)Math.Pow(10, 4)), (int)Math.Pow(10, 4));
//                Console.Write($"{nums[i]} ");
//            }
            
//            Console.WriteLine();
//            Console.WriteLine($"최장 증가 수열의 길이는 {Findarray(nums)}입니다.");                      
//        }

//        static int Findarray(int[] arr) //가장 긴 연속의 길이를 반환
//        {
//            int temp=0; //실제 반환값
//            int temp2 = 0; //for문에 사용됨            
//            int[] length = new int[arr.Length]; //새로운 배열 생성 (숫자별로 연속의 길이를 정리해놓기위해)
            
//            for (int i = 0; i < length.Length; i++) //배열들의 값은 0
//            {
//                length[i] = 0;                
//            }                

//            for (int i = 1; i < arr.Length; i++) //맨 앞의 0은 제외하고 하기때문에 1부터 시작
//            {
//                for (int j = 0; j < i; j++)  // 여기는 맨앞의 0을 포함하고 계산해야 규칙이 생기기 때문에 0시작
//                {
//                    if (arr[j] < arr[i]) //arr[i] -> 기준, arr[j]가 돌면서 조건을 만족했을 때
//                        if (temp2 < length[j]) //현재 저장된 i번째 숫자가 뒤에 붙을 수 있는 수열의 길이 < 현재 수열의 길이
//                            temp2 = length[j]; //수열의 길이 갱신      
//                }
//                length[i] = temp2+1; //temp2에 한개를 더 붙이기 때문에 +1
//                temp2 = 0; //temp2 초기화
//            }

//            for (int i = 1; i < length.Length; i++){ //각 수열의 길이의 최대값을 구함                
//                if (length[i-1] < length[i])
//                    temp = length[i];
//            }            
            
//            return temp; //반환
//        }
//    }
//}
