//namespace Week5
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

//            for (int i  = 0; i < arr.Length; i++) 
//                {
//                int minIndex = i;

//                for (int j = i+1; j < arr.Length; j++)
//                {
//                    if (arr[j] < arr[minIndex])
//                    {
//                        minIndex = j; //반복 도는 동안 제일 작은 수의 위치를 찾아옴
//                    }
//                }

//                int temp = arr[i]; //스왑문 작성
//                arr[i] = arr[minIndex];
//                arr[minIndex] = temp;
//            } 

//            foreach (int num in arr)
//            {
//                Console.WriteLine(num);
//            }
//        }
//    }
//}
