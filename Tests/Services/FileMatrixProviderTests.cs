using NUnit.Framework;
using ParallelProject.Services;
using System.Threading.Tasks;

namespace Tests.Services
{
    [TestFixture]
    class FileMatrixProviderTests
    {
        private const string _path = @"C:\Users\Pavel_Sannikau\Documents\Visual Studio 2017\Projects\Parallel\Matrixes\";

        [Test]
        public async Task GetMatrixAsync_FileCorrectAndExists_ElementsCountShouldBe24()
        {
            // Arrange
            FileMatrixProvider provider = new FileMatrixProvider();

            // Act
            var result = await provider.GetMatrixAsync(_path + "1.txt");

            // Assert
            Assert.AreEqual(24, result.Length);
        }

        [Test]
        public async Task GetMatrixAsync_FileDoesNotExist_ShouldThrowException()
        {
            // Arrange
            FileMatrixProvider provider = new FileMatrixProvider();

            // Act
            var result = provider.GetMatrixAsync(_path + "blabla.txt");

            // Assert
            Assert.Catch(result.Wait);
        }

        [Test]
        public async Task GetMatrixAsync_FileExistsButEmpty_ShouldThrowException()
        {
            // Arrange
            FileMatrixProvider provider = new FileMatrixProvider();

            // Act
            var result = provider.GetMatrixAsync(_path + "0.txt");

            // Assert
            Assert.Catch(result.Wait);
        }

        [Test]
        public async Task GetMatrixAsync_FileExistsHasNoEqualStrings_ShouldThrowException()
        {
            // Arrange
            FileMatrixProvider provider = new FileMatrixProvider();

            // Act
            var result = provider.GetMatrixAsync(_path + "different.txt");

            // Assert
            Assert.Catch(result.Wait);
        }

        [Test]
        public async Task SaveMatrix_ReadAndWriteTheFile_ShouldBeTheSame()
        {
            // Arrange
            FileMatrixProvider provider = new FileMatrixProvider();

            // Act
            var result = await provider.GetMatrixAsync(_path + "1.txt");
            provider.SaveMatrix(_path + "1_result.txt", result);
            var result2 = await provider.GetMatrixAsync(_path + "1_result.txt");

            // Assert
            for (var row = 0; row < result.GetLength(0); row++) {
                for (var column = 0; column < result.GetLength(1); column++) {
                    Assert.AreEqual(result[row, column], result2[row, column]);
                }    
            }
        }
    }
}
