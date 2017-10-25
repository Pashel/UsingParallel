using ParallelProject.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests.Services
{
    class MatrixOperationsTests
    {

        [Test]
        public async Task Multiply_Myltiply2Matrix_ShouldEqual3rdMatix()
        {
            // Arrange
            MatrixOperations manager = new MatrixOperations();
            int[,] matrix1 = {{1, 2, 3, 4, 5, 6}, {2, 3, 4, 5, 6, 7}, {4, 5, 6, 7, 8, 9}};
            int[,] matrix2 = {{1,2,3},{2,3,4},{3,4,5},{4,5,6}, {5,6,7}, {6,7,8}};
            int[,] matrix3 = {{91,112,133},{112,139,166},{154,193,232}};

            // Act
            var result = manager.Multiply(matrix1, matrix2);

            // Assert
            for (var row = 0; row < result.GetLength(0); row++) {
                for (var column = 0; column < result.GetLength(1); column++) {
                    Assert.AreEqual(result[row, column], matrix3[row, column]);
                }
            }
        }

        [Test]
        public async Task Multiply_Myltiply2Matrix_ShoulNotdEqual3rdMatix()
        {
            // Arrange
            MatrixOperations manager = new MatrixOperations();
            int[,] matrix1 = { { 1, 2, 3, 4, 5, 6 }, { 2, 3, 4, 5, 6, 7 }, { 4, 5, 6, 7, 8, 9 } };
            int[,] matrix2 = { { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 }, { 4, 5, 6 }, { 5, 6, 7 }, { 6, 7, 8 } };
            int[,] matrix3 = { { 91, 4, 133 }, { 3, 139, 6 }, { 154, 1, 232 }, {2, 2, 2} };

            // Act
            var result = manager.Multiply(matrix1, matrix2);

            // Assert
            var equal = true;
            if (result.Length == matrix3.Length){
                for (var row = 0; row < result.GetLength(0); row++) {
                    for (var column = 0; column < result.GetLength(1); column++) {
                        if (result[row, column] != matrix3[row, column]){
                            equal = false;
                        }
                    }
                }
            } else {
                equal = false;
            }
            Assert.IsFalse(equal);
        }

    }
}
