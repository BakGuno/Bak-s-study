using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    internal class Flood_Fill2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("사용하실 배열의 총 크기를 입력하세요. 50이하");
            string inputx = Console.ReadLine();
            int row = int.Parse(inputx);
            Random rand = new Random();
            //int row = rand.Next(3, 50); //임의의 열 크기 받기
            int[][] arr = new int[row][];
            bool[][] visited = new bool[row][];
            int Col = 0;

            for (int i = 0; i < row; i++) //임의의 행 크기 받아서 임의의 값 작성
            {
                Console.WriteLine("사용하실 {0}번째 배열의 열 크기를 입력하세요. 50이하", i + 1);
                string inputy = Console.ReadLine();
                Col = int.Parse(inputy);
                //Col = rand.Next(1, 100);
                int[] temparr = new int[Col];
                bool[] tempbool = new bool[Col];

                for (int j = 0; j < Col; j++)
                {
                    temparr[j] = rand.Next(0, 2);
                    tempbool[j] = false;
                    Console.Write(temparr[j]);
                }

                Console.Write($"  | {i}번째 행의 크기 : {Col} ");
                Console.WriteLine();

                arr[i] = temparr;//원래는 2^16까진데 눈에 확 보이게 하려고 바꿈
                visited[i] = tempbool; //숫자 세팅하면서 다 false로 채워주기
            }

            Console.WriteLine("시작 지점을 입력해주세요. ");
            string start = Console.ReadLine();
            string[] starts = start.Split(",");
            int startRow = int.Parse(starts[0]); ;
            int startCol = int.Parse(starts[1]);
            visited[startRow][startCol] = true; //시작지점만 true로

            Console.WriteLine("무슨 숫자로 바꾸고 싶은 지 입력하세요.");
            string Changeinput = Console.ReadLine();
            int change = int.Parse(Changeinput);
            Console.WriteLine();


            //검수용
            for (int i = 0; i < row; i++)  //완성된 배열 출력
            {
                foreach (bool j in visited[i])
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < row; i++)  //완성된 배열 출력
            {
                foreach (int j in arr[i])
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Find(arr, startCol, startRow, visited, change);

            //결과 출력
            for (int i = 0; i < row; i++)
            {
                foreach (bool j in visited[i])
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < row; i++)
            {
                foreach (int j in arr[i])
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }

        static int[][] Find(int[][] arr, int Col, int Row, bool[][] visited, int change) //조건이 다채로움.
        {
            if (Row >= 1 && Col < arr[Row - 1].Length)
                if (arr[Row - 1].Length >= Col)
                    if (arr[Row - 1][Col] == arr[Row][Col])
                        if (visited[Row - 1][Col] == false)
                        {
                            visited[Row - 1][Col] = true;
                            Find(arr, Col, Row - 1, visited, change);
                        }


            if (Row < arr.Length - 1 && Col < arr[Row + 1].Length)
                if (arr[Row + 1][Col] == arr[Row][Col])
                    if (visited[Row + 1][Col] == false)
                    {
                        visited[Row + 1][Col] = true;
                        Find(arr, Col, Row + 1, visited, change);
                    }


            if (Col < arr[Row].Length - 1)
                if (arr[Row][Col + 1] == arr[Row][Col])
                    if (visited[Row][Col + 1] == false)
                    {
                        visited[Row][Col + 1] = true;
                        Find(arr, Col + 1, Row, visited, change);
                    }


            if (Col >= 1)
                if (arr[Row][Col - 1] == arr[Row][Col])
                    if (visited[Row][Col - 1] == false)
                    {
                        visited[Row][Col - 1] = true;
                        Find(arr, Col - 1, Row, visited, change);
                    }

            arr[Row][Col] = change; //들리는게 끝나면 맨 끝 방문한 곳부터 차례차례 숫자를 바꾸면서 나옴.  
            return arr; //바뀐 배열 반환
        }
    }
}
