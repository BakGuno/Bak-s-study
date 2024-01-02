//namespace Week4
//{
//    internal class Program
//    {
//        //인터페이스 구현해보기
//        public interface IMovable
//        {
//            void Move(int x, int y);

//        }

//        public class Player : IMovable
//        {
//            public void Move(int x, int y)
//            {
//                // 이동 구현 (클래스별로 이동방법이 다를 수 있으니까 구현해주면된다)
//            }
//        }

//        public class Enemy : IMovable
//        {
//            public void Move(int x, int y)
//            {
//                // 이동 구현
//            }
//        }
            
//        static void Main(string[] args)
//        {
//            IMovable movableObject1 = new Player();
//            IMovable movableObject2 = new Enemy();
//            //둘이 서로 다른 클래스고 다른 구현을 하고 있지만, 인터페이스로 기능 통합을 진행할 수 있다.
//            movableObject1.Move(1, 2);
//            movableObject2.Move(1, 9);
//        }
//    }
//}
