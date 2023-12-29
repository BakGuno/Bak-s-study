using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weeks2
{
    internal class week2_2
    {
        static void Main(string[] args)
        {
            int[] x = [1, 4, 7];
            int[] y = [2, 8, 14];
            int k = 1;
            string[,] map = new string[9, 17];
            //맵 만드는 반복문
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (j == 5 || j == 11)
                        map[i, j] = "|";
                    else if (i== 2 || i == 5)
                        map[i, j] = "_";
                    else map[i, j] = " ";
                    
                }                
            }
            //숫자 넣는 반복문
            for (int i = 0; i <3; i++)
            {                
                for (int j = 0; j<3; j++)
                {
                    map[x[j], y[i]] = k.ToString();
                    k++;                    
                }

            }

            
        }

        static void showMap()
        {            
            Console.WriteLine($"플레이어 1: X  플레이어 2 : O");
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < Main.map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
