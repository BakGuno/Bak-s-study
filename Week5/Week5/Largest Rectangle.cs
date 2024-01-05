//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week5
//{
//    internal class Largest_Rectangle
//    {
//        static int LargestRectangleArea(List<int> height)
//        {
//            int temp = 0;
//            List<int> area = new List<int>();
//            int count = 0;

//            for (int i = 0; i < height.Count; i++)
//            {
//                area.Add(0);
//                for (int j = i + 1; j < height.Count; j++)
//                {
//                    if (height[i] <= height[j])
//                    {
//                        area[i]++;
//                    }
//                    else
//                        break;
//                }                
//            }
            
//            for (int i = 0; i < height.Count - 1; i++)
//            {
//                if ((area[i] + 1) * height[i] <= (area[i + 1] + 1) * height[i + 1])
//                    temp = (area[i + 1] + 1) * height[i + 1];
//            }
//            return temp;
//        }

//        static void Main(string[] args)
//        {
//            List<int> height = new List<int>();            
//            bool check = false;
            

//            while (true)
//            {
//                Console.WriteLine($"{height.Count + 1}번째 직사각형의 높이를 입력하세요.");
//                Console.WriteLine($"숫자 이외의 값을 입력하면 넘어갑니다.");
//                string input = Console.ReadLine();
//                int hei = 0;
//                bool intcheck = int.TryParse(input, out hei);
//                switch (intcheck && height.Count <= Math.Pow(10, 5))
//                {
//                    case true:
//                        {
//                            if (hei < 1 || hei > Math.Pow(10, 4))
//                                break;
//                            else
//                            {
//                                height.Add(hei);
//                            }
//                        }
//                        break;
//                    default:
//                        check = true;
//                        break;
//                }
//                if (check)
//                    break;
//            }
//            Console.WriteLine("주어진 배열에서 직사각형의 최대 크기는 {0}입니다.",LargestRectangleArea(height));
//        }
//    }
//}
