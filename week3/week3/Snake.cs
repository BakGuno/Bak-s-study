//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Threading;
//using System.Xml.Linq;

//class Program
//{
//    static void Main(string[] args)
//    {
//        // 뱀의 초기 위치와 방향을 설정하고, 그립니다.
//        Point p = new Point(4, 5, '*');
//        Snake snake = new Snake(p, 4, Direction.RIGHT);
//        snake.Draw();

//        // 음식의 위치를 무작위로 생성하고, 그립니다.
//        FoodCreator foodCreator = new FoodCreator(80, 20, '$');
//        Point food = foodCreator.CreateFood();
//        food.Draw();

//        // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
//        while (snake.isAlive)
//        {
//            Console.SetCursorPosition(0, 20);
//            Console.Write($"먹은 음식 갯수 : {snake.foodcount}");
//            Console.SetCursorPosition(0, 21);
//            Console.Write($"현재 길이 : {snake.Length}");
//            // 키 입력이 있는 경우에만 방향을 변경합니다.
//            switch (Console.KeyAvailable)
//            {
//                case (true):
//                    switch (Console.ReadKey().Key)
//                    {
//                        case ConsoleKey.UpArrow:
//                            snake.direction = Direction.UP;
//                            break;
//                        case ConsoleKey.DownArrow:
//                            snake.direction = Direction.DOWN;
//                            break;
//                        case ConsoleKey.RightArrow:
//                            snake.direction = Direction.RIGHT;
//                            break;
//                        case ConsoleKey.LeftArrow:
//                            snake.direction = Direction.LEFT;
//                            break;
//                    }
//                    break;
//                default:
//                    break;
//            }

//            // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
//            // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.
            
//            snake.Move();
//            if (snake.body.Last().IsHit(food)) //음식에 닿을 때
//            {
//                snake.EatFood();
//                food.Clear();
//                Point newfood = foodCreator.CreateFood();
//                food = newfood;
//                food.Draw();
//            }
//            if (snake.body.Last().x <= 0 || snake.body.Last().y <= 0  
//                || snake.body.Last().x >= 79 || snake.body.Last().y >= 19) //벽이랑 부딪히는 지 판별
//            {
//                Console.Clear();
//                Console.WriteLine($"먹은 음식 : {snake.foodcount}");
//                Console.WriteLine($"길이 : {snake.Length}");
//                Console.WriteLine("게임오버");
//                snake.isAlive = false;
//                break;
//            }
//            for( int i = 0; i< snake.body.Count-1; i++ ) {
//                if (snake.body.Last().IsHit(snake.body[i]) )
//                {
//                    Console.Clear();
//                    Console.WriteLine($"먹은 음식 : {snake.foodcount}");
//                    Console.WriteLine($"길이 : {snake.Length}");
//                    Console.WriteLine("게임오버");
//                    snake.isAlive = false;
//                    break;
//                }

//            }         
//            Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)

//            // 뱀의 상태를 출력합니다 (예: 현재 길이, 먹은 음식의 수 등)            
//        }
//    }
//}

//public class Point
//{
//    public int x { get; set; }
//    public int y { get; set; }
//    public char sym { get; set; }

//    // Point 클래스 생성자
//    public Point(int _x, int _y, char _sym)
//    {
//        x = _x;
//        y = _y;
//        sym = _sym;
//    }

//    // 점을 그리는 메서드
//    public void Draw()
//    {
//        Console.SetCursorPosition(x, y);
//        Console.Write(sym);
//    }

//    // 점을 지우는 메서드
//    public void Clear()
//    {
//        sym = ' ';
//        Draw();
//    }

//    // 두 점이 같은지 비교하는 메서드
//    public bool IsHit(Point p)
//    {
//        return p.x == x && p.y == y;
//    }
//}
//// 방향을 표현하는 열거형입니다.
//public enum Direction
//{
//    LEFT,
//    RIGHT,
//    UP,
//    DOWN
//}

//public class Snake
//{
//    public List<Point> body;
//    public Direction direction;
//    public int foodcount;
//    public int Length;
//    public bool isAlive = true;
//    public Snake(Point tail,int length,Direction _direction)
//    {
//        direction = _direction;
//        body = new List<Point>();
//        Length = length;
//        for (int i = 0; i < length; i++)
//        {
//            Point p = new Point(tail.x, tail.y, '*');
//            body.Add(p);
//            tail.x += 1;
//        }
//    }

//    public void Draw()
//    {

//        foreach (Point p in body)
//        {
//            Console.SetCursorPosition(p.x, p.y);
//            Console.Write(p.sym);
//        }
//    }

//    public void Move()    {
//        Point tail = body.First();
//        Point head = body.Last();
//        Point nextPoint = new Point(head.x, head.y, head.sym);
//        switch (direction)
//        {
//            case Direction.LEFT:
//                nextPoint.x -= 2;                
//                tail.Clear();
//                body.Remove(tail);
//                head = nextPoint;
//                body.Add(nextPoint);
//                foreach (Point p in body)
//                {
//                    if (p.x < 0)
//                        p.x = 0;
//                    Console.SetCursorPosition(p.x, p.y);                    
//                    Console.Write(p.sym);                    
//                }
//                break;
//            case Direction.DOWN:
//                nextPoint.y += 1;                
//                tail.Clear();
//                body.Remove(tail);
//                head = nextPoint;
//                body.Add(nextPoint);
//                foreach (Point p in body)
//                {
//                    Console.SetCursorPosition(p.x, p.y);
//                    Console.Write(p.sym);
//                }
//                break;
//            case Direction.RIGHT:
//                nextPoint.x += 2;                
//                tail.Clear();
//                body.Remove(tail);
//                head = nextPoint; 
//                body.Add(nextPoint);
//                foreach (Point p in body)
//                {
//                    Console.SetCursorPosition(p.x, p.y);
//                    Console.Write(p.sym);
                   
//                }
//                break;
//            case Direction.UP:
//                nextPoint.y -= 1;                
//                tail.Clear();
//                body.Remove(tail);
//                head = nextPoint;
//                body.Add(nextPoint);
//                foreach (Point p in body)
//                {
//                    Console.SetCursorPosition(p.x, p.y);
//                    Console.Write(p.sym);
//                }
//                break;
//        }
//    }

//    public void EatFood()
//    {
//        Point head = body.Last();        
//            foodcount++;
//            Length++;
//            switch (direction)
//            {
//                case Direction.LEFT:
//                    Point growLeft = new Point(head.x-2, head.y, '*');
//                    body.Add(growLeft);
//                    break;
//                case Direction .RIGHT:
//                    Point growRight = new Point(head.x + 2, head.y, '*');
//                    body.Add(growRight);
//                    break;
//                case Direction.UP:
//                    Point growUp = new Point(head.x, head.y-1, '*');
//                    body.Add(growUp);
//                    break;
//                case Direction.DOWN:
//                    Point growDown = new Point(head.x, head.y + 1, '*');
//                    body.Add(growDown);
//                    break;
//            }            
//    }
//}

//public class FoodCreator
//{
//    int mapWidth;
//    int mapHeight;
//    char sym;
//    public List<int> maps;
//    public FoodCreator(int Width,int height,char symbol)
//    {
//        mapWidth = Width;
//        mapHeight = height;
//        sym = symbol;
        
//        int x=0;
//        int y=0;
//        for (int j = 0; j < 2; j++) //벽 생성
//        {
//            for (int i = 1; i < mapWidth; i++)
//            {
//                if (j == 0)
//                {
                    
//                    Console.SetCursorPosition(i - 1, 0);
//                    Console.Write('#'); //81개 나옴
                    
//                }
//                else
//                {
//                    Console.SetCursorPosition(i - 1, 19); //80개 나옴 뭔 오류지
//                    Console.Write('#');
//                }
//            }
//            for (int i = 0; i < mapHeight; i++)
//            {
//                if (j == 0)
//                {
//                    Console.SetCursorPosition(0, i);
//                    Console.WriteLine('#'); //81개 나옴
//                }
//                else
//                {
//                    Console.SetCursorPosition(79, i); //80개 나옴 뭔 오류지
//                    Console.Write('#');
//                }
//            }
//        }
        
//    }
    
//    public Point CreateFood()
//    {
//        Random rand = new Random();
//        int xPos = 0;
//        int yPos = 0;
//        while (true)
//        {
//            xPos = rand.Next(1, mapWidth - 1);
//            yPos = rand.Next(1, mapHeight - 1);
//            if (xPos % 2 != 0)
//                break;            
//        }        
//        Point p = new Point(xPos,yPos,sym);
//        return p;
//    }
//}