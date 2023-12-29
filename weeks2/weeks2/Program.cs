using System.Runtime.InteropServices;

namespace weeks2
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
            /*//1)홀수와 짝수 구분하기
            Console.Write("숫자를 입력해주세요. : ");
            int num = int.Parse(Console.ReadLine());
            if (num % 2 == 0)
                Console.WriteLine("입력하신 수는 짝수입니다.");
            else Console.WriteLine("입력하신 수는 홀수입니다.");


            //2)등급 출력
            int playerScore = 100;
            string playerRank = "";

            switch (playerScore / 10)
            {
                case 10:
                case 9:
                    playerRank = "Diamond";
                    break;
                case 8:
                    playerRank = "Platinum";
                    break;
                case 7:
                    playerRank = "Gold";
                    break;
                case 6:
                    playerRank = "Silver";
                    break;
                default:
                    playerRank = "Bronze";
                    break;
            }

            Console.WriteLine(playerRank);

            //3)로그인 프로그램
            string id = "id";
            string passwrod = "pw";

            Console.WriteLine("아이디를 입력하세요. : ");
            string inputId = Console.ReadLine();
            Console.WriteLine("비밀번호를 입력하세요. : ");
            string inputPassword = Console.ReadLine();

            if (id == inputId && passwrod == inputPassword)
            {
                Console.WriteLine("로그인 성공");
            }
            else Console.WriteLine("로그인 실패");

            //4) 알파벳 판별 프로그램

            Console.WriteLine("문자를 입력하세요. : ");
            char input = Console.ReadLine()[0]; //인덱싱, 내가 뭘 입력하든 맨 첫번째것만 가져옴

            if ((input >= 'a' && input <= 'z') || (input >= 'A' && input <= 'Z'))
                Console.WriteLine("알파벳입니다.");
            else Console.WriteLine("알파벳이 아닙니다.");*/

            /* //5) 구구단 출력하기
             for (int i = 1; i < 10; i++)
             {
                 for (int j = 2; j < 10; j++)
                 {
                     Console.Write($"{j} * {i} = {i * j}  \t");
                 }
                 Console.WriteLine();
             }*/

            //1)가위바위보
            //string[] choice = { "가위", "바위", "보" };
            //string playerChoice = "";
            //string computerChoice = choice[new Random().Next(0,3)];

            //while (playerChoice != computerChoice) 
            //{
            //    Console.Write("가위,바위,보 중 하나를 선택하세요. : ");
            //    playerChoice = Console.ReadLine();

            //    if (playerChoice == computerChoice)
            //        Console.WriteLine("비겼습니다.");
            //    else if ((playerChoice == "가위" && computerChoice == "보") ||
            //            (playerChoice == "바위" && computerChoice == "가위") ||
            //            (playerChoice == "보" && computerChoice == "바위"))
            //        Console.WriteLine("플레이어 승리!");
            //    else Console.WriteLine("컴퓨터 승리!");
            //}

            //2)숫자맞추기
            //int targetNumber = new Random().Next(1,101);
            //int guess = 0;
            //int count = 0;
            //Console.WriteLine("1부터 100 사이의 숫자를 맞춰보세요.");

            //while (guess != targetNumber)
            //{
            //    Console.Write("추측한 숫자를 입력하세요.");
            //    guess = int.Parse(Console.ReadLine());
            //    count++;
            //    if (guess == targetNumber)
            //    {
            //        Console.WriteLine($"정답입니다! {count}번만에 맞추셨습니다.");
            //        break;
            //    }
            //    else if (guess < targetNumber)
            //        Console.WriteLine($"{guess}는 targetNumber보다 작습니다.");
            //    else Console.WriteLine($"{guess}는 targetNumber보다 큽니다.");
            //}

            //3)배열 실습
            //    int[] scores = new int[5];  // 5명의 학생 성적을 저장할 배열

            //    // 성적 입력 받기
            //    for (int i = 0; i < scores.Length; i++)
            //    {
            //        Console.Write("학생 " + (i + 1) + "의 성적을 입력하세요: ");
            //        scores[i] = int.Parse(Console.ReadLine());
            //    }

            //    // 성적 총합 계산
            //    int sum = 0;
            //    for (int i = 0; i < scores.Length; i++)
            //    {
            //        sum += scores[i];
            //    }

            //    // 성적 평균 출력
            //    double average = (double)sum / scores.Length;
            //    Console.WriteLine("성적 평균은 " + average + "입니다.");
            //}

            //Random random = new Random();  // 랜덤 객체 생성
            //int[] numbers = new int[3];  // 3개의 숫자를 저장할 배열

            //// 3개의 랜덤 숫자 생성하여 배열에 저장
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    numbers[i] = random.Next(1, 10);
            //}

            //int attempt = 0;  // 시도 횟수 초기화
            //while (true)
            //{
            //    Console.Write("3개의 숫자를 입력하세요 (1~9): ");
            //    int[] guesses = new int[3];  // 사용자가 입력한 숫자를 저장할 배열
            //    for (int i = 0; i < guesses.Length; i++)
            //    {
            //        guesses[i] = int.Parse(Console.ReadLine());
            //    }

            //    int correct = 0;

            //    for (int i = 0; i < numbers.Length; i++)
            //    {
            //        for (int j = 0; j < guesses.Length; j++)
            //        {
            //            if (numbers[i] == guesses[j])
            //            {
            //                correct++;
            //                break;
            //            }
            //        }
            //    }

            //    attempt++;
            //    Console.WriteLine($"시도 #{attempt} : {correct}개의 숫자를 맞추셨습니다.");

            //    if (correct == 3)
            //    {
            //        Console.WriteLine("축하합니다. 모든 숫자를 맞추셨습니다.");
            //        break;
            //    }


            //}

            //PrintLine();
            //PrintLine2(20);
            //int result = Add(10, 20);
            //Console.WriteLine(result);

            //int sum1 = AddNumbers(10, 20);
            //float sum2 = AddNumbers(10.5f, 21.5f);
            //int sum3 = AddNumbers(10, 20,30);

            //Console.WriteLine(sum1+" "+sum2+" "+sum3);
            //    CountDown(5);
            //}

            //static void CountDown(int n)
            //{
            //    if (n <= 0)
            //    {
            //        Console.WriteLine("Done");
            //    }
            //    else
            //    {
            //        Console.WriteLine(n);
            //        CountDown(n - 1);  // 자기 자신을 호출
            //    }
            //}

            // 메서드 호출



            //static int AddNumbers(int a, int b) //매개변수 같고 반환값이 다른건 아무 의미가 없다.
            //{
            //    return a + b;
            //}

            //static float AddNumbers(float a, float b)
            //{
            //    return a + b;
            //}

            //static int AddNumbers(int a, int b, int c) 
            //{
            //    return a + b + c;
            //}

            //static void PrintLine()
            //{
            //    for (int i = 0; i < 10; i++) 
            //    {
            //        Console.Write("=");
            //    }
            //    Console.WriteLine();
            //}

            //static void PrintLine2(int count)
            //{
            //    for (int i = 0; i< count; i++)
            //    {
            //        Console.Write("=");
            //    }
            //    Console.WriteLine();
            //}
            //static int Add(int a, int b)
            //{
            //   return a + b;
            //}
        }
    }

