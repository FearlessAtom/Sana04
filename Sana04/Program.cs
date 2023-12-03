using System;

namespace Sana04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int n = 5, m = 5, minvalue = -10, maxvalue = 10;
            int[,] array = new int[n, m];
            Console.WriteLine("Array = ");
            for (int index = 0; index < n; index++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[index, j] = random.Next(minvalue, maxvalue);

                }
            }
            PrintArray(array, n, m);
            Console.WriteLine($"Number of positive elements = {NumberOfPositiveElements(array, n , m)}");
            if (MaxElementThatOccursMoreThatOnes(array, n, m) != 0) { Console.WriteLine($"Max element that occurs more than ones = {MaxElementThatOccursMoreThatOnes(array, n, m)}"); }
            else { Console.WriteLine("The array has no elements that occur more than twice"); }
            Console.WriteLine($"Number of rows that do not have negative elements = {NumberOfRowsThatDoNotHaveZeros(array, n, m)}") ;
            Console.WriteLine($"Number of columns that have at least one zero = {NumberOfColumnsThatHaveAtLeastOneZero(array, n, m)}");
            if (LongestSeriesOfIdenticalElements(array, n, m) != 0) { Console.WriteLine($"Longest series of identical elements = {LongestSeriesOfIdenticalElements(array, n, m)}"); }
            else { Console.WriteLine("There are no series of number in rows!"); }
            Console.WriteLine($"Product of elements in rows without negative elements = {ProductOfElementsInRowsWithoutNegativeElements(array, n, m)}");
            Console.WriteLine($"Max sum of parallel diagonals = {MaxSumOfParallelDiagonals(array, n, m)}");
            Console.WriteLine($"Sum of elements in columns without negative numbers = {SumOfElementsWithoutNegativeElements(array, n, m)}");
            Console.WriteLine($"Min sum of parallel anti diagonals = {MinSumOfParallelAntiDiagonals(array, n, m)}");
            Console.WriteLine($"Sum of elements in columns with at least one negative element = {SumOfColumnsWithAtLeastOneNegativeElement(array, n, m)}");
            Console.Write($"Transposed Array = \n");
            TransposedArray(array, n, m);
        }
        public static void PrintArray(int[,] array, int n, int m)
        {
            for(int index = 0; index < n; index++)
            {
                for (int j = 0; j < m; j++)
                {
                    string paddedarray = array[index, j].ToString().PadLeft(3);
                    Console.Write($"{paddedarray} ");
                }
                Console.WriteLine();
            }
        }
        public static int NumberOfPositiveElements(int[,] array, int n, int m)
        {
            int count = 0;
            for(int index = 0;index < n; index++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (array[index,j] > 0) { count = count + 1; }
                }
            }
            return count;
        }
        public static int MaxElementThatOccursMoreThatOnes(int[,] array,int n, int m)
        {
            bool found = false;
            int max = int.MinValue;
            for(int index = 0; index < n; index++)
            {
                for(int j = 0; j < m; j++)
                {
                    for( int k = 0; k < m; k++)
                    {
                        for(int  l = 0; l < n; l++)
                        {
                            if(index != k || j != l)
                            {
                                if (array[index,j] == array[k,l] && array[index,j] > max)
                                {
                                    max = array[index,j];
                                    found = true;
                                }
                            }
                        }
                    }
                }
            }
            if(found)return max;
            return 0;
        }
        public static int NumberOfRowsThatDoNotHaveZeros(int[,] array,int n, int m)
        {
            int count = 0;
            bool found = false;
            for(int index = 0; index < n;index++)
            {
                found = false;
                for(int j = 0; j < m; j++)
                {
                    if (array[index,j] == 0)
                    {
                        found = true;
                    }
                }
                if (!found) { count = count + 1; }
            }
            return count;
        }
        public static int NumberOfColumnsThatHaveAtLeastOneZero(int[,] array,int n, int m)
        {
            int count = 0;
            for( int j = 0; j < m;j++)
            {
                bool found = false;
                for(int index = 0; index < n;index++) 
                {
                    if (array[index,j] == 0)
                    {
                        found = true;
                        break;
                    }
                }
                if (found) { count = count + 1; }
            }
            return count;
        }
        public static int LongestSeriesOfIdenticalElements(int[,] array,int n, int m)
        {
            int result = 0, row = 0;
            for(int index = 0; index < n; index++)
            {
                int count = 1;
                for(int j = 0; j < m - 1; j++)
                {
                    if (array[index, j] == array[index, j + 1]) { count = count + 1;
                         row  = index + 1;
                         break; }
                    else { count = 1; }
                }
                if (count > result)  { result = count; }
            }
            return row;
        }    
        public static int ProductOfElementsInRowsWithoutNegativeElements(int[,] array, int n, int m)
        {
            int product = 1, result = 1;
            bool output = false;
            for(int index = 0; index < n; index++)
            {
                bool found = false;
                for(int j = 0; j < m; j++)
                {
                    if (array[index,j] < 0) {
                        found = true;
                        break; }
                    product = product * array[index, j];
                }
                if (!found) { output = true; }
                if (!found) result = result * product;
            }
            if(output)return result;
            return 0;
        }
        public static int MaxSumOfParallelDiagonals(int[,] array, int n, int m)
        {
            int[] diagonalsums = new int[n * 2 - 1];
            for (int index = 0; index < n * 2 - 1; index++)
                for (int j = 0; j < n; j++)
                    if (index + j >= n - 1 && index + j < n + m - 1)
                        diagonalsums[index] = diagonalsums[index] +  array[j, index + j - (n - 1)];
            return diagonalsums.Max();
        }
        public static int SumOfElementsWithoutNegativeElements(int[,] array, int n, int m)
        {
            int sum = 0, result = 0;
            bool found = false;
            for (int j = 0; j < m; j++)
            {
                found = false;
                for (int index = 0; index < n; index++)
                {
                    if (array[index, j] < 0) { found = true; break; }
                    sum = sum + array[index, j];
                }
                if (!found) { result = result + sum; }
            }
            return result;
        }
        public static int MinSumOfParallelAntiDiagonals(int[,] array, int n, int m)
        {
        int[] diagonalsums = new int[n * 2 - 1];
            for (int index = 0; index < n * 2 - 1; index++)
                for (int j = 0; j < n; j++)
                    if (index - j >= 0 && index - j < m)
                    {
                        diagonalsums[index] = diagonalsums[index] + array[j, index - j];
                    }
            for(int index = 0;index < diagonalsums.Length; index++)
            {
                diagonalsums[index] = Math.Abs(diagonalsums[index]); ;
            }
            return diagonalsums.Min();
        }
        public static int SumOfColumnsWithAtLeastOneNegativeElement(int[,] array, int n, int m)
        {
            int sum = 0,result = 0;
            bool found = false;
            for(int j = 0; j < m; j++)
            {
                sum = 0;
                found = false;
                for(int index = 0; index < n; index++)
                {
                    if (array[index,j] < 0) { found = true;}
                    sum = sum + array[index,j];
                }
                if (found) { result = result + sum; }
            }
            return result;
        }
    public static void TransposedArray(int[,] array, int n, int m)
        {
            int[,] transposedarray = new int[n,m];
            for(int index = 0;index < n; index++)
            {
                for(int j = 0; j < m; j++)
                {
                    transposedarray[j,index] = array[index,j];
                }
            }
        PrintArray(transposedarray, n, m);
        }
    }
}