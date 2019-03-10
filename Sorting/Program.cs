using System;
using System.Collections.Generic;
using System.Linq;

namespace forexample
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Size = 10;
            int[] arr = new int[Size];
            FillArray(arr);
            ShowArray(arr);

            MergeSort(arr, 0, Size);

            ShowArray(arr);
            Console.ReadKey();
        }
        //Sorting. Four types

        //Bubbles Sort
        static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j - 1])
                        Swap(ref arr[j], ref arr[j - 1]);
                }
            }
        }
        //End of Bubbles Sort----------------------------

        //Selection Sort
        static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                        min = j;
                }
                if (min != i)
                    Swap(ref arr[min], ref arr[i]);
            }
        }
        //End of Selection Sort------------------------------

        //Insertion Sort
        static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                }
                arr[j] = temp;
            }
        }
        //End of Insertion Sort------------------------------

        //Merge Sort
        static void MergeSort(int[] arr, int start, int end)
        {
            if (end - start < 2) //если у нас 1-ин элемент 
                return; //выход
            if (end - start == 2) //если у нас 2- а элемента
            {
                if (arr[start] > arr[start + 1]) //меняем местами если 1-ый больше 2-ого
                    Swap(ref arr[start], ref arr[start + 1]);
                return; //выход
            }

            //рекурсивно вызываем тот же метод сортировки для поделённой на две части колекции
            MergeSort(arr, start, start + (end - start) / 2);
            MergeSort(arr, start + (end - start) / 2, end);

            //создаём лист который будем заполнять
            List<int> resultArr = new List<int>();
            int b1 = start;
            int e1 = start + (end - start) / 2;
            int b2 = e1;

            //если ещё есть элементы чтобы заполнить лист
            while (resultArr.Count < end - start)
            {
                //проверяем:
                //1)есть ли в 1-ой части элементы
                //2)есть ли во 2-ой части элементы + выбор элемента значение которого меньше
                if (b1 >= e1 || (b2 < end && arr[b2] < arr[b1]))
                {
                    resultArr.Add(arr[b2]);
                    b2++; // сдвиг указателя вперёд, т.к. данный элемент уже в листе
                }
                else
                {
                    resultArr.Add(arr[b1]);
                    b1++;
                }
            }

            //сохранение ОТСОРТИРОВАННОГО листа в нашу коллекцию
            for (int i = start; i < end; i++)
                arr[i] = resultArr[i - start];
        }
        //End of merge Sort--------------------------------------

        //Quick Sort
        static IEnumerable<int> QuickSort(IEnumerable<int> arr)
        {
            if (arr.Count() <= 1)
                return arr;
            var pivot = arr.First();
            var less = arr.Skip(1).Where(i => i <= pivot);
            var greater = arr.Skip(1).Where(i => i > pivot);
            return QuickSort(less).Union(new List<int> { pivot }).Union(QuickSort(greater));

        }
        //End of quick Sort--------------------------------------

        //=======methods=======
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        static void FillArray(params int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(100) + 1;
            }
        }
        static void ShowArray(params int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
            Console.WriteLine();
        }
    }

}
