using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM_.NET_PracticeTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matr1 = { { 1, 2, 3 }, { 3, 3, 4 }, { 5, 5, 5 } };
            double[,] matr2 = { { 2, 3, 4 }, { 3, 3, 4 }, { -1, -4, 5 } };

            Console.WriteLine("Creating matrix1...");
            Matrix matrix1 = new Matrix(matr1);          
            Console.WriteLine("matrix1:\n" +  matrix1.ToString());
            Console.WriteLine("det(matrix1) = " + Matrix.Determinant(matrix1));
            Thread.Sleep(3000);

            Console.WriteLine("\nCreating matrix2...");
            Matrix matrix2 = new Matrix(matr2);
            Console.WriteLine("matrix2:\n" + matrix2.ToString());     
            Console.WriteLine("det(matrix2) = " + Matrix.Determinant(matrix2));
            Thread.Sleep(3000);

            int i = 0, j = 1;
            Matrix minorMatr = matrix1.GetMinorMatrix(i, j);
            Console.WriteLine("\nminor (i={0},j={1}) = {2} ",i,j, matrix1.GetMinor(i,j));
            Thread.Sleep(1500);
            int k1 = 1;
            Console.WriteLine("minor (k={0}) = {1}",k1,matrix1.getMinor_K(k1));
            int k2 = 2;
            Console.WriteLine("minor (k={0}) = {1}", k2, matrix1.getMinor_K(k2));
            Thread.Sleep(3000);

            Console.WriteLine("\nsuma = matrix1 + matrix2");
            Matrix suma = matrix1.AddMatrix(matrix2);
            Console.WriteLine("suma:\n" + suma.ToString());
            Thread.Sleep(3000);

            Console.WriteLine("\nsubtract = matrix1 - matrix2");
            Matrix subtract = matrix1.SubtractMatrix(matrix2);
            Console.WriteLine("subtract:\n" + subtract.ToString());
            Thread.Sleep(3000);

            Matrix matrix4 = new Matrix(new double[,] { { 1, 2, 3,2 }, { 3, 3, -4 ,-3}, { -4, 2, 1,-2 } });
            Matrix multiplication = matrix1.MultiplyMatrix(matrix4);
            Console.WriteLine("multiplication:\n" + multiplication.ToString());
            Console.WriteLine("\nSuccessfully completed the program!");

            Console.Read();
        }
    }
}
