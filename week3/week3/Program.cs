namespace week3
{
    internal class Program
    {
        // out 키워드 사용 예시
        static void Divide(int a, int b, out int quotient, out int remainder)
        {
            quotient = a / b;
            remainder = a % b;
        }

        // ref 키워드 사용 예시
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b= temp;
        }

        static void Main(string[] args)
        {
            int quotient, remainder;
            Divide(7,3,out quotient,out remainder);
            Console.WriteLine($"{quotient}, {remainder}");

            int x = 1, y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"{x},{y}"); //참조 형태가 아닌 애들도 매개변수를 전달했을 때 값들을 반환받지 않고 직접적으로 변조를 받을수도 있다.

        }
    }
}
