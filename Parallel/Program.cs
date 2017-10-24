using System;
using ParallelProject.Services;
using System.Threading.Tasks;

namespace ParallelProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new FileMatrixProvider();
            var matrix1 = provider.GetMatrixAsync(@"../../../Matrixes/1.txt");
            var matrix2 = provider.GetMatrixAsync(@"../../../Matrixes/2.txt");

            Task.WaitAll(matrix1, matrix2);

            var manager = new MatrixOperations();
            var result = manager.Multiply(matrix1.Result, matrix2.Result);

            provider.SaveMatrix(@"../../../Matrixes/3.txt", result);
            
            Console.WriteLine("Done. Please press any key...");
            Console.ReadLine();
        }
    }
}
