using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_.NET_PracticeTask4
{
    class Matrix
    {
        private int row;
        private int column;
        private double[,] matrix;
        private Matrix(int m,int n)
        {
            this.row = m;
            this.column = n;
            matrix = new double[m, n];
        }
        public Matrix(double[,] matrix, int m, int n)
        {
            this.row = m;
            this.column = n;
            this.matrix = matrix;
        }
        public Matrix(double[,] matrix)
        {
            this.row = matrix.GetLength(0);
            this.column = matrix.GetLength(1);
            this.matrix = matrix;
        }
        public double this[int indexM, int indexN]
        {
            get
            {
                if (indexM < 0 || indexN < 0 || indexM>=row || indexN >=column)
                {
                    throw new Exception("Inccorect index.");
                }
                return matrix[indexM, indexN];
            }
            set
            {
                if (indexM < 0 || indexN < 0 || indexM >= row || indexN >= column)
                {
                    throw new Exception("Inccorect index.");
                }
                matrix[indexM, indexN] = value;
            }
        }
        public Matrix AddMatrix(Matrix matrixToAdd)
        {
            if (this.row != matrixToAdd.row || this.column != matrixToAdd.column)
            {
                throw new Exception("Different size of matrix.");
            }
            Matrix sumMatrix = new Matrix(row,column);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    sumMatrix[i, j] = this[i, j] + matrixToAdd[i, j]; 
                }
            }
            return sumMatrix;
        }
        public Matrix SubtractMatrix(Matrix matrixToSubtract)
        {
            if (this.row != matrixToSubtract.row || this.column != matrixToSubtract.column)
            {
                throw new Exception("Different size of matrix.");
            }
            Matrix resultMatrix = new Matrix(row, column);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    resultMatrix[i, j] = this[i, j] - matrixToSubtract[i, j];
                }
            }
            return resultMatrix;
        }
        public Matrix MultiplyMatrix(Matrix matrixToMultiply)
        {
            if (this.column != matrixToMultiply.row)
            {
                throw new Exception("Can`t multiply this matrix. Different size.");
            }
            Matrix resultMatrix = new Matrix(this.row, matrixToMultiply.column);
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < matrixToMultiply.column; j++)
                {
                    for (int k = 0; k < this.column; k++)
                    {
                        resultMatrix[i, j] += this[i, k] * matrixToMultiply[k, j];
                    }
                }
            }
            return resultMatrix;
        }
        public Matrix MultiplyMatrixByCoeff(double coeff)
        {
            Matrix resultMatrix = new Matrix(row, column);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    resultMatrix[i, j] = this[i, j] * coeff;
                }
            }
            return resultMatrix;
        }
        
        public Matrix GetMinorMatrix(int row, int column)
        {
            if (this.row != this.column)
            {
                throw new ArgumentException("Matrix should be square!");
            }
            double[,] minor = new double[this.row - 1, this.column - 1];
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) minor[i - 1, j] = this[i, j];
                        if (i < row && j > column) minor[i, j - 1] = this[i, j];
                        if (i > row && j > column) minor[i - 1, j - 1] = this[i, j];
                        if (i < row && j < column) minor[i, j] = this[i, j];
                    }
                }
            }
            return new Matrix(minor);
        }
        public double GetMinor(int i,int j)
        {
            if (i<0 || j<0 || i>=row || j>=column)
            {
                throw new Exception("Incorrect index. Index is out of range matrix.");
            }
            double minor=0;
            Matrix minorMatrix = this.GetMinorMatrix(i, j);
            minor = Math.Pow(-1, i + j) * Matrix.Determinant(minorMatrix) / Matrix.Determinant(this);
            return minor;
        }
        public double getMinor_K(int k)
        {
            return GetMinor(k, k);
        }
        public static double Determinant(Matrix m)
        {
            if (m.row != m.column) throw new ArgumentException("Matrix should be square!");
            double det = 0;
            int length = m.row;

            if (length == 1) det = m[0, 0];
            if (length == 2) det = m[0, 0] * m[1, 1] - m[0, 1] * m[1, 0];

            if (length > 2)
                for (int i = 0; i < m.column; i++)
                    det += Math.Pow(-1, 0 + i) * m[0, i] * Determinant(m.GetMinorMatrix(0, i));

            return det;
        }
        
        public override string ToString()
        {
            String strMatr = "";
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    strMatr += this[i, j] + " ";
                }
                strMatr += "\n";
            }
            return strMatr;
        }
    }
}
