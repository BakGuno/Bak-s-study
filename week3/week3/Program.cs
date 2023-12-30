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

        }

        static void Main(string[] args)
        {
            int quotient, remainder;
            Divide(7,3,out quotient,out remainder);
            Console.WriteLine($"{quotient}, {remainder}");
        }
    }
}
