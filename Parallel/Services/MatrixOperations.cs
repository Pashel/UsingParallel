using System;
using System.Threading.Tasks;

namespace ParallelProject.Services
{
    public class MatrixOperations
    {
        public int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            // ammount of columns in matrix1 should equal ammount of rows in matrix2
            if (matrix1.GetLength(1) != matrix2.GetLength(0)) {
                throw new Exception("Can't be multiplied: incorrect matrix sizes");
            }

            // resul matrix size = matrix1_rows*matrix2_columns
            int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

            // go through matrix1 rows
            Parallel.For(0, matrix1.GetLength(0), (matrix1RowIndex) => {
                // go through matrix2 columns
                Parallel.For(0, matrix2.GetLength(1), (matrix2ColumnIndex) => {
                    // calculate value of cell in result matrix
                    var newCell = 0;
                    for (var index = 0; index < matrix1.GetLength(1); index++) {
                        newCell += matrix1[matrix1RowIndex, index] * matrix2[index, matrix2ColumnIndex];
                    }
                    result[matrix1RowIndex, matrix2ColumnIndex] = newCell;
                });
            });
            
            return result;
        }
    }
}
