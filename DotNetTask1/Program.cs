namespace DotNetTask1;

class Program
{
    static int[,] ReadMatrixFromInput(int n)
    {
        Console.WriteLine("Введите матрицу:");
        int[,] matrix = new int[n, n];
        for (var i = 0; i < n; i++)
        {
            // Console.ReadLine().Split(' ').Select(num => int.Parse(num)).ToArray()
            var line = Console.ReadLine();
            var tokens = line.Split(' ');
            if (tokens.Length != n) throw new FormatException();
            for (var j = 0; j < n; j++)
                matrix[i, j] = int.Parse(tokens[j]);
        }
        return matrix;
    }

    static int[,] ReadMatrixFromInput()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("Введите размер квадратной матрицы:");
                var n = int.Parse(Console.ReadLine());
                return ReadMatrixFromInput(n);
            }
            catch (Exception)
            {
                Console.WriteLine("Что-то пошло не так, попробуйте еще раз");
            }
        }
    }

    static int SumMatrixRow(int[,] matrix, int row)
    {
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sum += matrix[row, j];
        }
        return sum;
    }

    static void PrintFilteredLinesSums(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (matrix[i, i] == 0)
            {
                int sum = SumMatrixRow(matrix, i);
                Console.WriteLine(string.Format("Сумма строки {0} равна {1}", i + 1, sum));
            }
        }
    }

    static void Main()
    {
        int[,] matrix = ReadMatrixFromInput();
        PrintFilteredLinesSums(matrix);
    }
}
