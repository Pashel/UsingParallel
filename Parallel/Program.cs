using  System;

namespace ParallelProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new FileMatrixProvider();
            var matrix1 = provider.GetMatrix(@"../../1.txt");
            var matrix2 = provider.GetMatrix(@"../../2.txt");

            var manager = new MatrixOperations();
            var result = manager.Multiply(matrix1, matrix2);

            provider.SaveMatrix(@"../../3.txt", result);
            
            Console.WriteLine("Done. Please press any key...");
            Console.ReadLine();
        }
    }
}
