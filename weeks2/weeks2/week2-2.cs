﻿using System;
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
                    else if (i == 2 || i == 5)
                        map[i, j] = "_";
                    else map[i, j] = " ";

                }
            }

            //숫자 넣는 반복문
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    map[x[i], y[j]] = k.ToString();
                    k++;
                }
                Console.WriteLine();

            }

            //게임 동작부
            int count = 0; //턴수 + 플레이어 순서 정하기용
            bool ok = false;
            while (ok == false)
            {
                Console.Clear();
                Console.WriteLine($"플레이어 1: X  플레이어 2 : O");
                Console.WriteLine();
                Console.WriteLine();

                //맵 그리기
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }
                if (count % 2 == 0)
                {
                    Console.Write("플레이어 1의 차례입니다. 숫자를 선택해주세요. : ");
                    string p1Choice = Console.ReadLine();
                    switch (int.Parse(p1Choice))
                    {
                        case 1:
                            if (map[1, 2] != "O")
                                map[1, 2] = "X";
                            else continue;
                            break;
                        case 2:
                            if (map[1, 8] != "O")
                                map[1, 8] = "X";
                            break;
                        case 3:
                            if (map[1, 14] != "O")
                                map[1, 14] = "X";
                            break;
                        case 4:
                            if (map[4, 2] != "O")
                                map[4, 2] = "X";
                            break;
                        case 5:
                            if (map[4, 8] != "O")
                                map[4, 8] = "X";
                            break;
                        case 6:
                            if (map[4, 14] != "O")
                                map[4, 14] = "X";
                            break;
                        case 7:
                            if (map[7, 2] != "O")
                                map[7, 2] = "X";
                            break;
                        case 8:
                            if (map[7, 8] != "O")
                                map[7, 8] = "X";
                            break;
                        case 9:
                            if (map[7, 14] != "O")
                                map[7, 14] = "X";
                            break;
                    }
                    count++;
                }
                else
                {
                    Console.Write("플레이어 2의 차례입니다. 숫자를 선택해주세요. : ");
                    string p2Choice = Console.ReadLine();
                    switch (int.Parse(p2Choice))
                    {
                        case 1:
                            if (map[1, 2] != "X")
                                map[1, 2] = "O";
                            else continue;
                            break;
                        case 2:
                            if (map[1, 8] != "X")
                                map[1, 8] = "O";
                            break;
                        case 3:
                            if (map[1, 14] != "X")
                                map[1, 14] = "O";
                            break;
                        case 4:
                            if (map[4, 2] != "X")
                                map[4, 2] = "O";
                            break;
                        case 5:
                            if (map[4, 8] != "X")
                                map[4, 8] = "O";
                            break;
                        case 6:
                            if (map[4, 14] != "X")
                                map[4, 14] = "O";
                            break;
                        case 7:
                            if (map[7, 2] != "X")
                                map[7, 2] = "O";
                            break;
                        case 8:
                            if (map[7, 8] != "X")
                                map[7, 8] = "O";
                            break;
                        case 9:
                            if (map[7, 14] != "X")
                                map[7, 14] = "O";
                            break;
                    }
                    count++;
                }

                //게임이 끝나는 조건들
                if ((map[1, 2] == map[1, 8] && map[1, 8] == map[1, 14]) ||
                    (map[4, 2] == map[4, 8] && map[4, 8] == map[4, 14]) ||
                    (map[7, 2] == map[7, 8] && map[7, 8] == map[7, 14]) ||
                    (map[1, 2] == map[4, 2] && map[4, 2] == map[7, 2]) ||
                    (map[1, 8] == map[4, 8] && map[4, 8] == map[7, 8]) ||
                    (map[1, 14] == map[4, 14] && map[4, 14] == map[7, 14]) ||
                    (map[1, 2] == map[4, 8] && map[4, 8] == map[7, 14]) ||
                    (map[1, 14] == map[4, 8] && map[4, 8] == map[7, 2]) && count < 9)
                {
                    if (count % 2 != 0) //이미 count가 ++ 된 상태기 때문에 뒤바꿔준다.
                    {
                        Console.WriteLine("1P의 승리입니다.");
                        ok = true;
                    }
                    else if (count % 2 == 0)
                    {
                        Console.WriteLine("2P의 승리입니다.");
                        ok = true;
                    }
                }
                else if (count > 8) //9칸이니까 턴이 9턴이 넘어가면 둘 곳이 없어짐.
                {
                    Console.WriteLine("더 이상 둘 곳이 없습니다.");
                    ok = true;
                }
            }
        }
    }
}
