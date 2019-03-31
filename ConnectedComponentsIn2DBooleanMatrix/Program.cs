using System;

namespace ConnectedComponentsIn2DBooleanMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connected Components(/islands) in a 2D " +
                "boolean matrix!");
            Console.WriteLine("--------------------------------------" +
                "--------------");

            Console.WriteLine("Enter the dimension of the 2D Boolean matrix");
            try
            {
                int dimensions = int.Parse(Console.ReadLine());
                int[,] matrix = new int[dimensions, dimensions];
                for (int index = 0; index < dimensions; index++) {
                    Console.WriteLine("Enter the elements of the row" +
                        " "+index+" of the matrix separated by space");
                    String[] elements = Console.ReadLine().Split(' ');
                    for (int secIndex = 0; secIndex < dimensions; secIndex++) {
                        matrix[index, secIndex] = int.Parse(elements[secIndex]);
                    }
                }
                CountNumberOfConnectedIslands(matrix);
            }   
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "
                    + exception.Message);
            }




            Console.ReadLine();
        }

        private static void CountNumberOfConnectedIslands(int[,] matrix) {

            int[,] visited = new int[matrix.GetLength(0),
                                    matrix.GetLength(0)];

            int count = 0;

            for (int index = 0; index < matrix.GetLength(0); index++) {
                for (int secIndex = 0; secIndex < matrix.GetLength(0); secIndex++) {
                    if (matrix[index, secIndex] == 1 &&
                        visited[index, secIndex] != 1) {
                        DepthFirstSearch(index, secIndex, matrix, visited);
                        count++;
                    }
                }
            }

            Console.WriteLine("The number of connected components(/islands) " +
                "in the graph is "+count);

        }

        private static void DepthFirstSearch(int index, int secIndex, int[,]matrix, 
                                                               int[,]visited) {

            visited[index, secIndex] = 1;

            /* 8 Neighbours for a cell in a matrix
            * Top, Bottom, Left, Right,
            * UpperLeftDiagonal, UpperRightDiagonal, LowerLeftDiagonal
            *                                       LowerRightDiagonal
            */
            int[] rowNeighbourMatrix = {-1, 1, 0, 0, -1, -1, 1, 1};
            int[] colNeighbourMatrix = {0, 0, -1, 1, -1, 1, -1, 1};

            for (int neighborIterator = 0; neighborIterator < 8; neighborIterator++) {
                int newIndex = index + rowNeighbourMatrix[neighborIterator];
                int newSecIndex = secIndex + colNeighbourMatrix[neighborIterator];
                if (CanBeNavigated(matrix, newIndex, newSecIndex, visited)) {
                    DepthFirstSearch(newIndex, newSecIndex, matrix, visited);
                }
            }
        }

        private static Boolean CanBeNavigated(int[,] matrix, int index, int secIndex, 
                                                                int[,] visited) {
            Boolean result = false;

            if (index < matrix.GetLength(0) && secIndex < matrix.GetLength(0)
                && index >= 0 && secIndex >= 0 &&
                matrix[index, secIndex] == 1 && visited[index, secIndex] != 1) {
                return true;
            }


            return result;
        }
    }
}
