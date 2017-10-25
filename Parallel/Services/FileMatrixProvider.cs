using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using System.Threading.Tasks;

namespace ParallelProject.Services
{
    public class FileMatrixProvider
    {
        public async Task<int[,]> GetMatrixAsync(string path)
        {
            // read matrix lines from file
            var fileLines = new List<string>();
            using (var reader = new StreamReader(path, Encoding.UTF8)) {
                string line;
                while ((line = await reader.ReadLineAsync()) != null) {
                    fileLines.Add(line);
                }
            }
            if (fileLines.Count == 0) {
                throw new Exception("Empty file passed");
            }

            int rowsCount = fileLines.Count;
            int columnsCount = ParseString(fileLines[0]).Length;
            int[,] matrix = new int[rowsCount, columnsCount];

            // fill matrix with file strings
            for (var rowNum = 0; rowNum < fileLines.Count; rowNum++) {
                var elementsInString = ParseString(fileLines[rowNum]);
                if (elementsInString.Length != columnsCount) {
                    throw new Exception("Incorrect matrix format");
                }
                for (var columnNum = 0; columnNum < elementsInString.Length; columnNum++) {
                    matrix[rowNum, columnNum] = elementsInString[columnNum];
                }
            }

            return matrix;
        }

        public void SaveMatrix(string path, int[,] matrix)
        {
            var fileLines = new List<string>();
            var elementsInString = new List<int>();

            for (int rowNum = 0; rowNum < matrix.GetLength(0); rowNum++) {
                for (var columnNum = 0; columnNum < matrix.GetLength(1); columnNum++) {
                    elementsInString.Add(matrix[rowNum, columnNum]);
                }
                // make and save line (format: "1;2;3") from each matrix string
                fileLines.Add(string.Join(";", elementsInString));
                elementsInString.Clear();
            }

            using (var writer = new StreamWriter(path, false, Encoding.UTF8)) {
                foreach (var line in fileLines) {
                    writer.WriteLine(line);
                }
            }
        }

        // parse string (format: "1;2;3;4") to array of integers
        private int[] ParseString(string input)
        {
            var row = new List<int>();
            var stringView = input.Split(';');

            foreach (var item in stringView) {
                row.Add(int.Parse(item));
            }

            return row.ToArray();
        }
    }
}
