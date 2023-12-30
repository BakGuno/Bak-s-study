namespace week3
{
    internal class Program
    {
        public class Unit
        {
            public void Move()
            {
                Console.WriteLine("두발로 걷기");
            }

            public void Attack()
            {
                Console.WriteLine("Unit 공격");
            }
        }

        public class Marine : Unit
        {

        }

        public class Zergling : Unit
        {
            public void Move()
            {
                Console.WriteLine("네발로 걷기");
            }
        }

        static void Main(string[] args)
        {
            Marine marine = new Marine();
            marine.Move();
            marine.Attack();

            Zergling zergling = new Zergling();
            zergling.Move();
            zergling.Attack();
        }
    }
}
