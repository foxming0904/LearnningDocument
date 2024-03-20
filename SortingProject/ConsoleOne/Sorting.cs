using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOne
{
    /// <summary>
    /// 对
    /// </summary>
    public static class Sorting
    {
        #region 交换排序
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr">要排序的数组</param>
        /// <returns></returns>
        public static void BubbleSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    //Console.WriteLine($"Compare:{arr[j]} & {arr[j+1]}");
                    if (arr[j] > arr[j + 1])
                    {
                        //Console.WriteLine($"Swap number index:{arr[j]} & {arr[j + 1]}");
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        flag = false;
                    }
                }
                //Console.WriteLine($"The {i+1} round result："+String.Join(",",arr));
                if (flag) break;
            }
        }

        #region 快速排序
        public static void QuickSort(this int[] arr, int begin, int end)
        {
            if (begin >= end) return;
            int pivotIndex = QuickSort_Once(arr, begin, end);

            QuickSort_Once(arr, begin, pivotIndex - 1);
            QuickSort_Once(arr, pivotIndex + 1, end);
        }
        private static int QuickSort_Once(int[] arr, int begin, int end)
        {
            int pivot = arr[begin];
            int i = begin;
            int j = end;

            while (i < j)
            {
                while (arr[j] >= pivot && i < j) j--;
                arr[i] = arr[j];
                //arr[j] = pivot;
                //Console.WriteLine(string.Join(",", arr) + $"  j交换:{arr[j]} & {pivot}");

                while (arr[i] <= pivot && i < j) i++;
                arr[j] = arr[i];
                //arr[i] = pivot;
                //Console.WriteLine(string.Join(",", arr) + $"  i交换:{arr[j]} & {pivot}");

            }
            arr[i] = pivot;
            return i;
        }
        #endregion
        #endregion

        #region 选择排序
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr">要排序的数组</param> 
        public static void SelectSort(this int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                int temp = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < temp)
                    {
                        min = j;
                        temp = arr[j];
                    }
                }
                if (min != i)
                {
                   // Console.WriteLine($"交换{arr[i]} & {arr[min]}");
                    var t = arr[i];
                    arr[i] = arr[min];
                    arr[min] = t;
                }
            }
        }
 

        #endregion
    }
}
