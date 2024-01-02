using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5
{
    internal class Class1
    {
        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static int Partition(int[] arr,int left,int right)
        {
            int pivot = arr[right];
            int i = left - 1;

            for (int j=left; j < right;j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr,i,j);
                }
            }

            Swap(arr,i+1,right);

            return i + 1;
        }

        static void QuickSor(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr,left,right);

                QuickSor(arr, left, pivot - 1);
                QuickSor(arr, pivot +1, right);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] { 5, 2, 4, 6, 1, 3 };

            QuickSor(arr,0,arr.Length-1);

            foreach (int i in arr)
                Console.WriteLine(i);

        }
    }
}
