// Задайте двумерный массив
// из целых чисел. Напишите программу, которая удалит
// строку и столбец, на пересечении которых расположен
// наименьший элемент массива. Под удалением
// понимается создание нового двумерного массива без
// строки и столбца

int[,] GenerateMatrix(int row, int col, int leftRange, int rightRange)
{
    int[,] tempMatrix = new int[row, col];
    Random rand = new Random();

    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return tempMatrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

void FindMinNumberIndexes(int[,] matrix, out int iIndex, out int jIndex)
{
    iIndex = 0;
    jIndex = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < matrix[iIndex, jIndex])
            {
                iIndex = i;
                jIndex = j;
            }
        }
    }
}

int[,] DeleteRowAndCol(int[,] matrix, int iMin, int jMin)
{
    int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

    for (int i = 0, x = 0; i < newMatrix.GetLength(0); i++)
    {
        x = i < iMin ? i : i + 1;
        for (int j = 0, y = 0; j < newMatrix.GetLength(1); j++)
        {
            y = j < jMin ? j : j + 1;
            newMatrix[i, j] = matrix[x, y];
        }
    }

    return newMatrix;
}
// ------------------
int[,] oldMatrix = GenerateMatrix(5, 7, -10, 10);
PrintMatrix(oldMatrix);
FindMinNumberIndexes(oldMatrix, out int iMin, out int jMin);
System.Console.WriteLine();
System.Console.WriteLine(iMin + " " + jMin);
System.Console.WriteLine();
PrintMatrix(DeleteRowAndCol(oldMatrix, iMin, jMin));