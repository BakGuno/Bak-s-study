using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    internal class Largest_Rectangle
    {
        static int LargestRectangleArea(List<int> height)
        {
            int temp = 0;
            List<int> area = new List<int>();
            int count=0;
            for (int i = 0; i < height.Count-1; i++)
            {
                for (int j = i + 1; j < height.Count; j++)
                {
                    if (height[i] <= height[j])
                    {
                        ++count;
                    }
                    else
                    {
                        area.Add(count);
                        count = 0;
                        break;
                    }                                           
                }                
                             
            }

            foreach (int i in area)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine(height.Count);
            //for (int i=0;i<area.Count-1;i++)
            //{
            //    if (area[i] < area[i + 1])
            //        temp = area[i+1];
            //    Console.WriteLine(area[i]);
                    
            //}
            return temp;
        }

        static void Main(string[] args)
        {
            List<int> height = new List<int>();
            int width = 1;
            bool check = false;            
                
            while (true)
            {
                Console.WriteLine($"{height.Count + 1}번째 직사각형의 높이를 입력하세요.");
                Console.WriteLine($"숫자 이외의 값을 입력하면 넘어갑니다.");
                string input = Console.ReadLine();
                int hei = 0; 
                bool intcheck = int.TryParse(input,out hei);
                switch (intcheck && height.Count <= Math.Pow(10,5))
                {
                    case true:
                        {
                        if (hei < 1 || hei > Math.Pow(10, 4))                         
                                break;
                        else
                            {
                                height.Add(hei);                                
                            }       
                        }
                        break;
                    default:
                        check = true;
                        break;
                }
                if (check)
                    break;
            }
            
        }
    }
}
