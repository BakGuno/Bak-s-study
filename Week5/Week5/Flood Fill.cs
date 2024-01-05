//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week5
//{
//    internal class Flood_Fill
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("사용하실 배열의 행 크기를 입력하세요. 50이하");
//            string inputx = Console.ReadLine();
//            int row =int.Parse(inputx);

//            Console.WriteLine("사용하실 배열의 열 크기를 입력하세요. 50이하");
//            string inputy = Console.ReadLine();
//            int Col = int.Parse(inputy);

//            int[,] grid = new int[row, Col]; 
//            bool[,] visited = new bool[row,Col];

//            Random rand     = new Random();
//            for (int i=0;i<row;i++)
//            {
//                for (int j = 0; j < Col; j++)
//                {
//                    grid[i, j] = rand.Next(0, 2); //원래는 2^16까진데 눈에 확 보이게 하려고 바꿈
//                    Console.Write($"[{grid[i, j]}]");
//                }
//                Console.WriteLine();
//            }                

//            Console.WriteLine("시작 지점을 입력해주세요. 행 : 0~{0}, 열 :0~{1}사이입니다.",row, Col);
//            string start = Console.ReadLine();
//            string[] starts = start.Split(",");
//            int startx = int.Parse(starts[0]);
//            int starty = int.Parse(starts[1]);
//            visited[startx, starty] = true;

//            Console.WriteLine("무슨 숫자로 바꾸고 싶은 지 입력하세요.");
//            string Changeinput = Console.ReadLine();
//            int change = int.Parse(Changeinput);

//            Find(grid, startx, starty,visited, change);

//            for (int i = 0; i < row; i++)  //완성된 배열 출력
//            {
//                for (int j = 0; j < Col; j++)
//                {
//                    Console.Write($"[{grid[i,j]}]"); 
//                }
//                Console.WriteLine();
//            }
//        }

//        static int[,] Find(int[,] grid,int x, int y, bool[,] visited,int change)
//        {           
//                if (y  >= 1) //그냥 상하좌우 순서로 이동할 수 있는지 부터 판별
//                    if (grid[x,y-1] == grid[x, y]) //그 후 이동할 곳의 값이 지금 있는 곳과 같고
//                        if (visited[x,y-1] == false) //내가 들른 적이 없다면
//                    {
//                        visited[x, y - 1] = true; //들른 곳으로 체크하고
//                        Find(grid, x, y - 1, visited,change); //거기서 더 들를 곳이 있는지 확인             
//                    }
                            
                    
//                if (y < grid.GetLength(1)-1)
//                    if (grid[x, y + 1] == grid[x, y])
//                        if (visited[x, y + 1] == false)
//                    {
//                        visited[x, y + 1] = true;
//                        Find(grid, x, y + 1, visited, change);                        
//                    }


//            if (x < grid.GetLength(0) - 1)
//                if (grid[x + 1, y] == grid[x, y])
//                    if (visited[x + 1, y] == false)
//                    {
//                        visited[x + 1, y] = true; 
//                        Find(grid, x + 1, y, visited, change);                        
//                    }


//            if (x >=1)
//                    if (grid[x-1, y] == grid[x, y])
//                        if (visited[x-1, y] == false)
//                    {
//                        visited[x - 1, y] = true;
//                        Find(grid, x - 1, y, visited, change);                        
//                    }
                           
//            grid[x, y] = change; //들리는게 끝나면 맨 끝 방문한 곳부터 차례차례 숫자를 바꾸면서 나옴.  
//            return grid; //바뀐 배열 반환
//        }
//    }
//}
