//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Week4
//{
//    internal class Class2
//    {
        
//        //다중 상속 구현 예제
//        public interface IItemPickable
//        {
//            void PickUp();
//        }

//        public interface IDroppalbe
//        {
//            void Drop();
//        }

//        public class Item : IItemPickable, IDroppalbe
//        {
//            public string Name { get; set; }

//            public void PickUp()
//            {
//                Console.WriteLine("아이템 {0}을 주웠습니다.", Name);
//            }
//            public void Drop()
//            {
//                Console.WriteLine("아이템 {0}을 버렸습니다.", Name);
//            }
//        }

//        public class Player
//        {
//            public void InteractWithItem(IItemPickable item)
//            {
//                item.PickUp();
//            }

//            public void DropItem(IDroppalbe item)
//            {
//                item.Drop();
//            }
//        }

//        static void Main(string[] args)
//        {
//            Player player = new Player();
//            Item item = new Item { Name = "Sword" };

//            //아이템 주울 수 있음
//            player.InteractWithItem(item);

//            //아이템 버릴 수 있음
//            player.DropItem(item);
//        }
//    }
//}
