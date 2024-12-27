using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Program
{
    public static void Main()
    {
        Program program = new Program();
    }
    #region Level 1
    public long Task_1_1(int n, int k)
    {
        long answer = 0;

        // code here
        static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        if (k > n) return answer;
        if (k > n - k) k = n - k;



        answer = Factorial(n) / (Factorial(k) * Factorial(n - k));


        // create and use Combinations(n, k);
        // create and use Factorial(n);

        // end

        return answer;
    }

    public int Task_1_2(double[] first, double[] second)
    {
        int answer = 0;

        // code here
        double GeronArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        if (!IsValidTriangle(first[0], first[1], first[2]) || !IsValidTriangle(second[0], second[1], second[2]))
        {
            return -1;
        }
        double areaFirst = GeronArea(first[0], first[1], first[2]);
        double areaSecond = GeronArea(second[0], second[1], second[2]);

        if (areaFirst > areaSecond)
        {
            return 1;
        }
        else if (areaFirst < areaSecond)
        {
            return 2;
        }
        else
        {
            return 0;
        }

        // create and use GeronArea(a, b, c);

        // end

        // first = 1, second = 2, equal = 0, error = -1
        return answer;
    }

    public int Task_1_3a(double v1, double a1, double v2, double a2, int time)
    {
        int answer = 0;

        // code here
        static double GetDistance(double v, double a, int t)
        {
            return v * t + 0.5 * a * t * t;
        }
        double distance1 = GetDistance(v1, a1, time);
        double distance2 = GetDistance(v2, a2, time);


        if (distance1 > distance2)
        {
            answer = 1;
        }
        else if (distance2 > distance1)
        {
            answer = 2;
        }
        else
        {
            answer = 0;
        }

        // create and use GetDistance(v, a, t); t - hours

        // end

        // first = 1, second = 2, equal = 0
        return answer;
    }

    public int Task_1_3b(double v1, double a1, double v2, double a2)
    {
        int answer = 0;

        // code here
        static double GetDistance(double v, double a, int t)
        {
            return v * t + 0.5 * a * t * t;
        }
        for (int t = 1; ; t++)
        {
            if (GetDistance(v2, a2, t) >= GetDistance(v1, a1, t))
            {
                return t;
            }
        }

        // use GetDistance(v, a, t); t - hours

        // end

        return answer;
    }
    #endregion

    #region Level 2
    public void Task_2_1(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxIndex(matrix, out row, out column);

        // end
    }

    public void Task_2_2(double[] A, double[] B)
    {
        // code here
        static int FindMaxIndex(double[] array)
        {
            int maxI = 0;
            double max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxI = i;
                }
            }

            return maxI;
        }
        static double Calculate(double[] array, int maxIndex)
        {
            double sum = 0;
            int K = 0;

            for (int i = maxIndex + 1; i < array.Length; i++)
            {
                sum += array[i];
                K++;
            }

            return K > 0 ? sum / K : 0;
        }
        {
            int maxIndexA = FindMaxIndex(A);
            int maxIndexB = FindMaxIndex(B);


            double averageA = Calculate(A, maxIndexA);
            double averageB = Calculate(B, maxIndexB);

            if (A.Length - maxIndexA > B.Length - maxIndexB)
            {

                A[maxIndexA] = averageA;
            }
            else
            {

                B[maxIndexB] = averageB;
            }
        }

        // create and use FindMaxIndex(array);
        // only 1 array has to be changed!

        // end
    }

    public void Task_2_3(ref int[,] B, ref int[,] C)
    {
        // code here

        //  create and use method FindDiagonalMaxIndex(matrix);

        // end
    }

    public void Task_2_4(int[,] A, int[,] B)
    {
        // code here
        static int FindDiagonalMaxIndex(int[,] matrix)
        {
            int max = matrix[0, 0];
            int maxI = 0;

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] > max)
                {
                    max = matrix[i, i];
                    maxI = i;
                }
            }
            return maxI;
        }
        int maxRowA = FindDiagonalMaxIndex(A); 
        int maxColB = FindDiagonalMaxIndex(B); 

        for (int i = 0; i < A.GetLength(1); i++)
        {
            int temp = A[maxRowA, i];
            A[maxRowA, i] = B[i, maxColB];
            B[i, maxColB] = temp;
        }

        //  create and use method FindDiagonalMaxIndex(matrix); like in Task_2_3

        // end
    }

    public void Task_2_5(int[,] A, int[,] B)
    {
        // code here

        // create and use FindMaxInColumn(matrix, columnIndex, out rowIndex);

        // end
    }

    public void Task_2_6(ref int[] A, int[] B)
    {
        // code here
        int maxIa = FindMaxIndex(A);
        int maxIb = FindMaxIndex(B);

        DeleteElement(ref A, maxIa);
        DeleteElement(ref B, maxIb);

        int newSize = A.Length + B.Length;
        Array.Resize(ref A, newSize);

        for (int i = 0; i < B.Length; i++)
        {
            A[A.Length - B.Length + i] = B[i];
        }
        static int FindMaxIndex(int[] array)
        {
            int maxIndex = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }
        static void DeleteElement(ref int[] array, int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }
        // create and use FindMax(matrix, out row, out column); like in Task_2_1
        // create and use DeleteElement(array, index);

        // end
    }

    public void Task_2_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use CountRowPositive(matrix, rowIndex);
        // create and use CountColumnPositive(matrix, colIndex);

        // end
    }

    public void Task_2_8(int[] A, int[] B)
    {
        // code here
        int max = 0;
        for (int i = 1; i < A.Length; i++)
        {
            if (A[i] > A[max])
            {
                max = i;
            }
        }
        Console.WriteLine(max);
        int maxB = 0;
        for (int i = 1; i < B.Length; i++)
        {
            if (B[i] > B[maxB])
            {
                maxB = i;
            }
        }
        SortArrayPart(A, max);
        SortArrayPart(B, maxB);
        
        int[] SortArrayPart(int[] array, int startIndex)
        {
            for (int i = startIndex + 1; i < array.Length; i++)
            {
                int ap = array[i], j = i - 1;
                while (j > startIndex && array[j] > ap)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = ap;
            }
            return array;

            // create and use SortArrayPart(array, startIndex);

            // end
        }
    }

    public int[] Task_2_9(int[,] A, int[,] C)
    {
        int[] answer = default(int[]);

        // code here

        // create and use SumPositiveElementsInColumns(matrix);

        // end

        return answer;
    }

    public void Task_2_10(ref int[,] matrix)
    {
        // code here
        int maxe = int.MinValue;
        int minel = int.MaxValue;
        int maxindex = -1;
        int minindex = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i >= j)
                {
                    if (matrix[i, j] > maxe)
                    {
                        maxe = matrix[i, j];
                        maxindex = j;
                    }
                }
                else
                {
                    if (matrix[i, j] < minel)
                    {
                        minel = matrix[i, j];
                        minindex = j;
                    }
                }
            }
        }
        if (maxindex != minindex)
        {
            if (maxindex > minindex)
            {
                matrix = RemoveColumn(matrix, maxindex);
                matrix = RemoveColumn(matrix, minindex);
            }
            else
            {
                matrix = RemoveColumn(matrix, minindex);
                matrix = RemoveColumn(matrix, maxindex);
            }
        }
        else
        {
            matrix = RemoveColumn(matrix, maxindex);
        }


    }

    public int[,] RemoveColumn(int[,] matrix, int colIndex)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] newMatrix = new int[rows, cols - 1];

        for (int i = 0; i < rows; i++)
        {
            int newColIndex = 0;
            for (int j = 0; j < cols; j++)
            {
                if (j != colIndex)
                {
                    newMatrix[i, newColIndex++] = matrix[i, j];
                }
            }
        }

        return newMatrix;
        // create and use RemoveColumn(matrix, columnIndex);

        // end
    }

    public void Task_2_11(int[,] A, int[,] B)
    {
        // code here

        // use FindMaxIndex(matrix, out row, out column); from Task_2_1

        // end
    }
    public void Task_2_12(int[,] A, int[,] B)
    {
        {
            int maxCA = FindMaxColumnIndex(A);
            int maxCB = FindMaxColumnIndex(B);
            SwapColumns(A, maxCA, B, maxCB);
        }

        int FindMaxColumnIndex(int[,] matrix)
        {
            int maxC = 0;
            int maxE = matrix[0, 0]; 

            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            for (int col = 0; col < colCount; col++) 
            {
                for (int row = 0; row < rowCount; row++) 
                {
                    if (matrix[row, col] > maxE)
                    {
                        maxE = matrix[row, col];
                        maxC = col; 
                    }
                }
            }

            return maxC;
        }

        void SwapColumns(int[,] matrixA, int colA, int[,] matrixB, int colB)
        {
            int rowC = matrixA.GetLength(0);

            for (int row = 0; row < rowC; row++)
            {

                (matrixA[row, colA], matrixB[row, colB]) = (matrixB[row, colB], matrixA[row, colA]);
                
            }
        }
    }

    public void Task_2_13(ref int[,] matrix)
    {
        // code here

        // create and use RemoveRow(matrix, rowIndex);

        // end
    }

    public void Task_2_14(int[,] matrix)
    {
        // code here
        static int[,] SortRow(int[,] matrix, int rowIndex)
        {
            int[,] output = matrix;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - i - 1; j++)
                {
                    if (output[rowIndex, j] > output[rowIndex, j + 1]) (output[rowIndex, j + 1], output[rowIndex, j]) = (output[rowIndex, j], output[rowIndex, j + 1]);
                    
                }
            }
            return output;
        }
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            matrix = SortRow(matrix, i);
        }




        // create and use SortRow(matrix, rowIndex);

        // end
    }

    public int Task_2_15(int[,] A, int[,] B, int[,] C)
    {
        int answer = 0;

        // code here

        // create and use GetAverageWithoutMinMax(matrix);

        // end

        // 1 - increasing   0 - no sequence   -1 - decreasing
        return answer;
    }

    public void Task_2_16(int[] A, int[] B)
    {
        // code here

        // create and use SortNegative(array);
        SortNegative(A);
        SortNegative(B);              
        // end

    }
    public int[] SortNegative(int[] array)
    {
        int c = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) c++;
        }
        int[] negative = new int[c];
        int p = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                negative[p] = array[i];
                p++;
            }
        }
        for (int i = 0; i < p; i++)
        {
            for (int j = 0; j < p - 1 - i; j++)
            {
                if (negative[j] < negative[j + 1])
                {
                    int a = negative[j];
                    negative[j] = negative[j + 1];
                    negative[j + 1] = a;
                }
            }
        }
        p = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                array[i] = negative[p];
                p++;
            }
        }
        return array;
    }

    public void Task_2_17(int[,] A, int[,] B)
    {
        // code here

        // create and use SortRowsByMaxElement(matrix);

        // end
    }

    public void Task_2_18(int[,] A, int[,] B)
    {
        // code here

        // create and use SortDiagonal(matrix);
        SortDiagonal(A);
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int k = 0; k < A.GetLength(1); k++)
            {
                Console.Write(A[i, k] + " ");
            }
            Console.WriteLine();
        }
        SortDiagonal(B);
        int[,] SortDiagonal(int[,] matrix)
        {
            int[] d = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                d[i] = matrix[i, i];
            }
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                int key = d[i], j = i - 1;
                while (j >= 0 && d[j] > key)
                {
                    d[j + 1] = d[j];
                    j--;
                }
                d[j + 1] = key;
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = d[i];
            }
            return matrix;
        }
        // end
    }

    public void Task_2_19(ref int[,] matrix)
    {
        // code here

        // use RemoveRow(matrix, rowIndex); from 2_13

        // end
    }
    public void Task_2_20(ref int[,] A, ref int[,] B)
    {
        // code here
        // code here
        {
            A = RemoveColumnsWithoutZero(A);
            B = RemoveColumnsWithoutZero(B);


        }

        int[,] RemoveColumnsWithoutZero(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int col = cols - 1; col >= 0; col--)
            {
                bool containsZero = false;

                for (int row = 0; row < rows; row++)
                {
                    if (matrix[row, col] == 0)
                    {
                        containsZero = true;
                        break;
                    }
                }
                if (!containsZero) matrix = RemoveColumn(matrix, col);              
            }

            return matrix;
        }

        int[,] RemoveColumn(int[,] matrix, int colIndex)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] rez = new int[rows, cols - 1];           
            for (int i = 0; i < rows; i++)
            {
                int newColIndex = 0;
                for (int j = 0; j < cols; j++)
                {
                    if (j != colIndex) rez[i, newColIndex++] = matrix[i, j];
                    
                }
            }
            return rez;

        }

        // use RemoveColumn(matrix, columnIndex); from 2_10

        // end
    }

    public void Task_2_21(int[,] A, int[,] B, out int[] answerA, out int[] answerB)
    {
        answerA = null;
        answerB = null;

        // code here

        // create and use CreateArrayFromMins(matrix);

        // end
    }

    public void Task_2_22(int[,] matrix, out int[] rows, out int[] cols)
    {
        rows = null;
        cols = null;

        rows = new int[matrix.GetLength(0)]; 
        cols = new int[matrix.GetLength(1)]; 

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            rows[i] = CountNegativeInRow(matrix, i);
        }

        cols = FindMaxNegativePerColumn(matrix);
      
    }

    int CountNegativeInRow(int[,] matrix, int rowIndex)
    {
        int count = 0;
        for (int j = 0; j < matrix.GetLength(1); j++) 
        {
            if (matrix[rowIndex, j] < 0) count++;
            
        }
        return count;
    }

    int[] FindMaxNegativePerColumn(int[,] matrix)
    {
        int[] maxi = new int[matrix.GetLength(1)]; 

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int max = int.MinValue; 
            bool foundNegative = false; 

            for (int i = 0; i < matrix.GetLength(0); i++)  
            {
                if (matrix[i, j] < 0)
                {
                    if (matrix[i, j] > max)
                    {
                        max = matrix[i, j];
                    }
                    foundNegative = true;
                }
            }
            if (!foundNegative) maxi[j] = int.MinValue;

            else maxi[j] = max;
            
        }

        return maxi;
    }

    public void Task_2_23(double[,] A, double[,] B)
    {
        // code here

        // create and use MatrixValuesChange(matrix);

        // end
    }

    public void Task_2_24(int[,] A, int[,] B)
    {

        if (A == null || B == null || A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1))
        {
            return;
        }


        int rowA, colA;
        FindMaxIndex(A, out rowA, out colA);
        SwapColumnWithDiagonal(A, colA);
        int rowB, colB;

        FindMaxIndex(B, out rowB, out colB);
        SwapColumnWithDiagonal(B, colB);

        void FindMaxIndex(int[,] matrix, out int row, out int col)
        {
            int maxElement = matrix[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        void SwapColumnWithDiagonal(int[,] matrix, int columnIndex)
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                int temp = matrix[i, i];
                matrix[i, i] = matrix[i, columnIndex];
                matrix[i, columnIndex] = temp;
            }
        }

        // use FindMaxIndex(matrix, out row, out column); like in 2_1
        // create and use SwapColumnDiagonal(matrix, columnIndex);

        // end
    }

    public void Task_2_25(int[,] A, int[,] B, out int maxA, out int maxB)
    {
        maxA = 0;
        maxB = 0;

        // code here

        // create and use FindRowWithMaxNegativeCount(matrix);
        // in FindRowWithMaxNegativeCount create and use CountNegativeInRow(matrix, rowIndex); like in 2_22

        // end
    }

    public void Task_2_26(int[,] A, int[,] B)
    {
        // code here
        {
            if (A == null || B == null || A.GetLength(0) != A.GetLength(1) || B.GetLength(0) != B.GetLength(1))
            {
                return;
            }
            int rowA = FindRowWithMaxNegativeCount(A);
            int rowB = FindRowWithMaxNegativeCount(B);
            SwapRows(A, rowA, B, rowB);
        }
        int CountNegativeInRow(int[,] matrix, int rowIndex)
        {
            int c = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[rowIndex, j] < 0) c++;              
            }
            return c;
        }
        int FindRowWithMaxNegativeCount(int[,] matrix)
        {
            int maxN = -1;
            int rowI = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int negativeCount = CountNegativeInRow(matrix, i);
                if (negativeCount > maxN)
                {
                    maxN = negativeCount;
                    rowI = i;
                }
            }

            return rowI;
        }
        void SwapRows(int[,] matrixA, int rowA, int[,] matrixB, int rowB)
        {
            int columns = matrixA.GetLength(1);

            for (int j = 0; j < columns; j++)
            {
                (matrixA[rowA, j], matrixB[rowB, j]) = (matrixB[rowB, j], matrixA[rowA, j]);

            }
        }



        // create and use FindRowWithMaxNegativeCount(matrix); like in 2_25
        // in FindRowWithMaxNegativeCount use CountNegativeInRow(matrix, rowIndex); from 2_22

        // end
    }

    public void Task_2_27(int[,] A, int[,] B)
    {
        // code here

        // create and use FindRowMaxIndex(matrix, rowIndex, out columnIndex);
        // create and use ReplaceMaxElementOdd(matrix, row, column);
        // create and use ReplaceMaxElementEven(matrix, row, column);

        // end
    }

    public void Task_2_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        {
            answerFirst = FindSequence(first, 0, first.Length - 1);
            answerSecond = FindSequence(second, 0, second.Length - 1);
        }
        int FindSequence(int[] array, int start, int end)
        {
            bool increasing = true, decreasing = true;

            for (int i = start + 1; i <= end; i++)
            {
                if (array[i] > array[i - 1]) decreasing = false;
                if (array[i] < array[i - 1]) increasing = false;
            }

            if (increasing) return 1;
            if (decreasing) return -1;
            return 0;
        }
    }

    public void Task_2_28b(int[] first, int[] second, ref int[,] answerFirst, ref int[,] answerSecond)
    {
        // code here
        answerFirst = FindSequence_b(first, 0, first.Length - 1);
        answerSecond = FindSequence_b(second, 0, second.Length - 1);
         int[,] FindSequence_b(int[] array, int A, int B)
        {
            int c = 0;
            for (int i = A; i < B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (FindSequence(array, i, j) != 0)
                    {
                        c++;
                    }
                }
            }

            int n = 0;
            int[,] inte = new int[c, 2];

            for (int i = A; i < B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (FindSequence(array, i, j) != 0)
                    {
                        inte[n, 0] = i;
                        inte[n, 1] = j;
                        n++;
                    }
                }
            }

            return inte;
        }
         int FindSequence(int[] array, int A, int B)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;
        for (int i = A + 1; i <= B; i++)
        {
            if (array[i] > array[i - 1]) isDecreasing = false;
            if (array[i] < array[i - 1]) isIncreasing = false;
        }

        if (isIncreasing) return 1;  
        if (isDecreasing) return -1; 
        return 0;               
    }

    // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a
    // A and B - start and end indexes of elements from array for search

    // end
}

    public void Task_2_28c(int[] first, int[] second, ref int[] answerFirst, ref int[] answerSecond)
    {
        // code here
        int[,] fi = FindSequence_b(first, 0, first.Length - 1);
        int[,] se = FindSequence_b(second, 0, second.Length - 1);

        answerFirst = FindSequence_max(fi);
        answerSecond = FindSequence_max(se);
         int[] FindSequence_max(int[,] matrix)
    {
        int max = -999, imax = 0, length = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            length = Math.Abs(matrix[i, 0] - matrix[i, 1]);
            if (length > max)
            {
                max = length;
                imax = i;
            }
        }
        int[] a = new int[2];
        a[0] = matrix[imax, 0];
        a[1] = matrix[imax, 1];
        return a;
    }

        int[,] FindSequence_b(int[] array, int A, int B)
        {
            int c = 0;
            for (int i = A; i < B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (FindSequence(array, i, j) != 0)
                    {
                        c++;
                    }
                }
            }

            int n = 0;
            int[,] inte = new int[c, 2];

            for (int i = A; i < B; i++)
            {
                for (int j = i + 1; j <= B; j++)
                {
                    if (FindSequence(array, i, j) != 0)
                    {
                        inte[n, 0] = i;
                        inte[n, 1] = j;
                        n++;
                    }
                }
            }

            return inte;
        }
        int FindSequence(int[] array, int A, int B)
        {
            bool isIncreasing = true;
            bool isDecreasing = true;
            for (int i = A + 1; i <= B; i++)
            {
                if (array[i] > array[i - 1]) isDecreasing = false;
                if (array[i] < array[i - 1]) isIncreasing = false;
            }

            if (isIncreasing) return 1;
            if (isDecreasing) return -1;
            return 0;
        }

        // use FindSequence(array, A, B); from Task_2_28a or entirely Task_2_28a or Task_2_28b
        // A and B - start and end indexes of elements from array for search

    }
    #endregion

    #region Level 3
    public void Task_3_1(ref double[,] firstSumAndY, ref double[,] secondSumAndY)
    {
        // code here

        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }

   
    
    
    

    public void Task_3_2(int[,] matrix)
    {
        // code here
        SortRowStyle sortStyle = default(SortRowStyle);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (i % 2 == 0) sortStyle = SortAscending;          
            else sortStyle = SortDescending;            
            sortStyle(matrix, i);
        }


        // create and use public delegate SumFunction(x) and public delegate YFunction(x)
        // create and use method GetSumAndY(sFunction, yFunction, a, b, h);
        // create and use 2 methods for both functions calculating at specific x

        // end
    }
    public delegate int[,] SortRowStyle(int[,] matrix, int rowIndex);
    public int[,] SortAscending(int[,] matrix, int rowIndex)
    {
        for (int d = 1; d < matrix.GetLength(1); d++)
        {
            int l = matrix[rowIndex, d], k = d - 1;
            while (k >= 0 && matrix[rowIndex, k] > l)
            {
                matrix[rowIndex, k + 1] = matrix[rowIndex, k];
                k--;
            }
            matrix[rowIndex, k + 1] = l;
        }
        return matrix;
    }
    public int[,] SortDescending(int[,] matrix, int rowIndex)
    {
        for (int p = 1; p < matrix.GetLength(1); p++)
        {
            int d = matrix[rowIndex, p], k = p - 1;
            while (k >= 0 && matrix[rowIndex, k] < d)
            {
                matrix[rowIndex, k + 1] = matrix[rowIndex, k];
                k--;
            }
            matrix[rowIndex, k + 1] = d;
        }
        return matrix;
    }

    public double Task_3_3(double[] array)
    {
        double answer = 0;
        // SwapDirection swapper = default(SwapDirection); - uncomment me

        // code here

        // create and use public delegate SwapDirection(array);
        // create and use methods SwapRight(array) and SwapLeft(array)
        // create and use method GetSum(array, start, h) that sum elements with a negative indexes
        // change method in variable swapper in the if/else and than use swapper(matrix)

        // end

        return answer;
    }

    public int Task_3_4(int[,] matrix, bool isUpperTriangle)
    {
        int answer = 0;

        // code here

        // create and use public delegate GetTriangle(matrix);
        // create and use methods GetUpperTriange(array) and GetLowerTriange(array)
        // create and use GetSum(GetTriangle, matrix)

        // end
        GetTriange tr;
        if (isUpperTriangle) tr = GetUpperTriange;     
        else tr = GetLowerTriange;        
        answer = GetSum(tr, matrix);

        return answer;
    }
    public delegate int[] GetTriange(int[,] matrix);
    public int[] GetUpperTriange(int[,] matrix)
    {
        int k = 0;
        int len = matrix.GetLength(0);
        int len1 = matrix.GetLength(1);
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < matrix.GetLength(1); j++)
            {
                k++;
            }
        }
        int[] ap = new int[k];
        int n = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len1; j++)
            {
                ap[n] = matrix[i, j] * matrix[i, j];
                n++;
            }
        }
        return ap;
    }
    public int[] GetLowerTriange(int[,] matrix)
    {
        int k = 0;
        int len = matrix.GetLength(0);
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j <= i; j++)           
                k++;    
        }
        int[] ap = new int[k];
        int n = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                ap[n] = matrix[i, j] * matrix[i, j];
                n++;
            }
        }
        return ap;
    }
     public int GetSum(GetTriange array, int[,] matrix)
    {
        int s = 0;
        int[] a = array(matrix);
        double len = a.Length;
        for (int k = 0; k < len; k ++)      
            s = s +  a[k];
        
        return s;
    }
    public void Task_3_5(out int func1, out int func2)
    {
        func1 = 0;
        func2 = 0;

        // code here

        // use public delegate YFunction(x, a, b, h) from Task_3_1
        // create and use method CountSignFlips(YFunction, a, b, h);
        // create and use 2 methods for both functions

        // end
    }

    public void Task_3_6(int[,] matrix)
    {
        // code here

        // create and use public delegate FindElementDelegate(matrix);
        // use method FindDiagonalMaxIndex(matrix) like in Task_2_3;
        // create and use method FindFirstRowMaxIndex(matrix);
        // create and use method SwapColumns(matrix, FindDiagonalMaxIndex, FindFirstRowMaxIndex);
        FindElementDelegate findDiagonalMaxIndex = FindDiagonalMaxIndex;
        FindElementDelegate findFirstRowMaxIndex = FindFirstRowMaxIndex;
        SwapColumns(matrix, findDiagonalMaxIndex, findFirstRowMaxIndex);
        // end
    }
    public delegate int FindElementDelegate(int[,] matrix);
    public int FindDiagonalMaxIndex(int[,] matrix)
    {
        int maxE = int.MinValue;
        int maxI = -1;

        for (int i = 0; i < Math.Min(matrix.GetLength(0), matrix.GetLength(1)); i++)
        {
            if (matrix[i, i] > maxE)
            {
                maxE = matrix[i, i];
                maxI = i;
            }
        }

        return maxI;
    }
    public int FindFirstRowMaxIndex(int[,] matrix)
    {
        int maxE = int.MinValue;
        int maxI = -1;
        int len = matrix.GetLength(1);
        for (int col = 0; col < len; col++)
        {
            if (matrix[0, col] > maxE)
            {
                maxE = matrix[0, col];
                maxI = col;
            }
        }

        return maxI;
    }
    public void SwapColumns(int[,] matrix, FindElementDelegate findDiagonalMax, FindElementDelegate findFirstRowMax)
    {
        int dM = findDiagonalMax(matrix);
        int firstR = findFirstRowMax(matrix);
        int len = matrix.GetLength(0);
        for (int row = 0; row < len; row++)
        {
            (matrix[row, dM], matrix[row, firstR]) = (matrix[row, firstR], matrix[row, dM]);
            
        }
    }

    public void Task_3_7(ref int[,] B, int[,] C)
    {
        // code here

        // create and use public delegate CountPositive(matrix, index);
        // use CountRowPositive(matrix, rowIndex) from Task_2_7
        // use CountColumnPositive(matrix, colIndex) from Task_2_7
        // create and use method InsertColumn(matrixB, CountRow, matrixC, CountColumn);

        // end
    }

    public void Task_3_10(ref int[,] matrix)
    {
        // FindIndex searchArea = default(FindIndex); - uncomment me

        // code here
        FindIndex below = default(FindIndex);
        below = FindMaxBelowDiagonalIndex;
        FindIndex above = default(FindIndex);
        above = FindMinAboveDiagonalIndex;
        matrix = RemoveColumns(matrix, below, above);
        // create and use public delegate FindIndex(matrix);
        // create and use method FindMaxBelowDiagonalIndex(matrix);
        // create and use method FindMinAboveDiagonalIndex(matrix);
        // use RemoveColumn(matrix, columnIndex) from Task_2_10
        // create and use method RemoveColumns(matrix, findMaxBelowDiagonalIndex, findMinAboveDiagonalIndex)

        // end
    }
    public delegate int FindIndex(int[,] matrix);
    public int FindMaxBelowDiagonalIndex(int[,] matrix)
    {
        int maximum = -999999, max = 0;
        int len = matrix.GetLength(0);
        for (int i = 0; i < len ; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (matrix[i, j] > maximum)
                {
                    maximum = matrix[i, j];
                    max = j;
                }
            }
        }
        return max;
    }
    public int FindMinAboveDiagonalIndex(int[,] matrix)
    {
        int minimum = 999, jmin = 0;
        int len = matrix.GetLength(0);
        int len1 = matrix.GetLength(1);
        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j < len1; j++)
            {
                if (matrix[i, j] < minimum)
                {
                    minimum = matrix[i, j];
                    jmin = j;
                }
            }
        }
        return jmin;
    }
    public int[,] RemoveColumns(int[,] matrix, FindIndex below, FindIndex above)
    {
        int bel = below(matrix);
        int ab = above(matrix);
        if (bel > ab)
        {
            matrix = RemoveColumn(matrix, bel);
            matrix = RemoveColumn(matrix, ab);
        }
        if (bel < ab)
        {
            matrix = RemoveColumn(matrix, ab);
            matrix = RemoveColumn(matrix, bel);
        }
        else matrix = RemoveColumn(matrix, bel);

        return matrix;
    }


    public void Task_3_13(ref int[,] matrix)
    {
        // code here

        // use public delegate FindElementDelegate(matrix) from Task_3_6
        // create and use method RemoveRows(matrix, findMax, findMin)

        // end
    }

    public void Task_3_22(int[,] matrix, out int[] rows, out int[] cols)
    {

        rows = null;
        cols = null;

        // code here

        // create and use public delegate GetNegativeArray(matrix);
        // use GetNegativeCountPerRow(matrix) from Task_2_22
        // use GetMaxNegativePerColumn(matrix) from Task_2_22
        // create and use method FindNegatives(matrix, searcherRows, searcherCols, out rows, out cols);

        // end
    }
    public delegate int GetNegativeArray(int[,] matrix, int index);
    public int GetNegativeCountPerRow(int[,] matrix, int index)
    {
        int k = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[index, i] < 0) k++;          
        }
        return k;
    }
    public int GetMaxNegativePerColumn(int[,] matrix, int index)
    {
        int maximum = -9999999;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, index] < 0 && matrix[i, index] > maximum) maximum = matrix[i, index];   
        }
        return maximum;
    }
    public void FindNegative(int[,] matrix, GetNegativeArray searcherRows, GetNegativeArray searcherCols, out int[] rows, out int[] cols)
    {
        rows = new int[matrix.GetLength(0)]; cols = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(0); j++)        
            rows[j] = searcherRows(matrix, j);
        
        for (int j= 0; j < matrix.GetLength(1); j++)       
            cols[j] = searcherCols(matrix, j);
        
    }

    public void Task_3_27(int[,] A, int[,] B)
    {
        // code here

        // create and use public delegate ReplaceMaxElement(matrix, rowIndex, max);
        // use ReplaceMaxElementOdd(matrix) from Task_2_27
        // use ReplaceMaxElementEven(matrix) from Task_2_27
        // create and use method EvenOddRowsTransform(matrix, replaceMaxElementOdd, replaceMaxElementEven);

        // end
    }

    public void Task_3_28a(int[] first, int[] second, ref int answerFirst, ref int answerSecond)
    {
        // code here
        IsSequence inc = FindIncreasingSequence;
        IsSequence dec = FindDecreasingSequence;

        answerFirst = DefineSequence(first, inc, dec);
        answerSecond = DefineSequence(second, inc, dec);

        // create public delegate IsSequence(array, left, right);
        // create and use method FindIncreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method FindDecreasingSequence(array, A, B); similar to FindSequence(array, A, B) in Task_2_28a
        // create and use method DefineSequence(array, findIncreasingSequence, findDecreasingSequence);

        // end
    }
    public delegate bool IsSequence(int[] array, int left, int right);
    public bool FindIncreasingSequence(int[] array, int A, int B)
    {
        bool isIncreasing = true;
        for (int j = A; j < B; j++)
        {
            if (array[j] >= array[j + 1]) 
            {
                isIncreasing = false;
                break;
            }
        }
        return isIncreasing;
    }
    public bool FindDecreasingSequence(int[] array, int A, int B)
    {
        bool isDecreasing = true;
        for (int j = A; j < B; j++)
        {
            if (array[j] <= array[j + 1]) 
            {
                isDecreasing = false;
                break;
            }
        }
        return isDecreasing;
    }
    public int DefineSequence(int[] array, IsSequence findIncreasingSequence, IsSequence findDecreasingSequence)
    {
        if (findIncreasingSequence(array, 0, array.Length - 1)) return 1;      
        if (findDecreasingSequence(array, 0, array.Length - 1)) return -1;
       
        return 0; 
    }

    public void Task_3_28c(int[] first, int[] second, ref int[] answerFirstIncrease, ref int[] answerFirstDecrease, ref int[] answerSecondIncrease, ref int[] answerSecondDecrease)
    {
        // code here
        IsSequence inc = FindIncreasingSequence;
        IsSequence dec = FindDecreasingSequence;

        answerFirstIncrease = FindLongestSequence(first, inc);
        answerFirstDecrease = FindLongestSequence(first, dec);

        answerSecondIncrease = FindLongestSequence(second, inc);
        answerSecondDecrease = FindLongestSequence(second, dec);
        // create public delegate IsSequence(array, left, right);
        // use method FindIncreasingSequence(array, A, B); from Task_3_28a
        // use method FindDecreasingSequence(array, A, B); from Task_3_28a
        // create and use method FindLongestSequence(array, sequence);

        // end
    }
    public int[] FindLongestSequence(int[] array, IsSequence sequence)
    {
        int maximum = -999999;
        int[] rez = new int[2];
        for (int i = 0; i < array.Length - 1; i++)       
            for (int j = i + 1; j < array.Length; j++)
            {
                if (sequence(array, i, j))
                {
                    int ij = j - i;
                    if (ij > maximum)
                    {
                        maximum = ij;
                        rez[0] = i;
                        rez[1] = j;
                    }
                }
            }
        
        return rez;
    }
    #endregion
    #region bonus part
    public double[,] Task_4(double[,] matrix, int index)
    {
        // MatrixConverter[] mc = new MatrixConverter[4]; - uncomment me

        // code here

        // create public delegate MatrixConverter(matrix);
        // create and use method ToUpperTriangular(matrix);
        // create and use method ToLowerTriangular(matrix);
        // create and use method ToLeftDiagonal(matrix); - start from the left top angle
        // create and use method ToRightDiagonal(matrix); - start from the right bottom angle

        // end

        return matrix;
    }
    #endregion
}
