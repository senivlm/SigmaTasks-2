namespace Homework_2_DenkinDmytro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[,]
            {
                { 0, 1, 2, 3, 4 },
                { 5, 6, 6, 6, 6 },
                { 7, 8, 9, 9, 1 },
                { 2, 2, 3, 3, 0 }
            };

            int colour, startRowI, endRowI, startColI, endColI, len;
            ColourMatrix.FindLongestColourStartEndIndexLength(matrix, out colour, out startRowI, out endRowI, out startColI, out endColI, out len);
            Console.WriteLine($"{colour}, {startRowI}, {endRowI}, {startColI}, {endColI}, {len}");

            RectangularMatrixService rms = new();
            int[,] vertical = rms.FillVerticalSnake(3, 1);
            Console.WriteLine(rms.MatrixToString(vertical));

            int[,] snake = rms.FillDiagonalSnakeSquare(5, 5);
            Console.WriteLine(rms.MatrixToString(snake));

            int[,] spiral = rms.FillSpiralSnake(4, 3);
            Console.WriteLine(rms.MatrixToString(spiral));
        }
    }
}