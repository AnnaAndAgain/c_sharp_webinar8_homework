// Эта задача мне не далась.


/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

!!! в идеале - матрицы редактируемого размера, в т. ч. несимметричные
*/

void PrintArray(int[,] tmpArray)
{
    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            Console.Write(tmpArray[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

void Spiral(int[,] tmpArray)
{
    int count = 1;
    int maxI = tmpArray.GetLength(0);
    int maxJ = tmpArray.GetLength(1);
    int minI = 0;
    int minJ = 0;

    while (count < 15)
    {
        maxJ = maxJ - 1;
        for (int i = minI; i <= maxI; i++)
        {
            tmpArray[i, minJ] = count;
            count++;
        }
        
        for (int j = 1; j <= maxJ; j++)
        {
            tmpArray[maxI, j] = count;
            count++;
        }
        maxI = maxI - 1;

        for (int i = maxI; i >= minI; i--)
        {
            tmpArray[i, maxJ] = count;
            count++;
        }
        minJ = minJ +1;

        for (int j = maxJ; j >= minJ; j--)
        {
            tmpArray[minI, j] = count;
            count++;
        }
        minI++;
        
    }
}


void Main()
{
    int[,] myArray = new int[4, 4];
    PrintArray(myArray);
    Console.WriteLine();

    Spiral(myArray);
    PrintArray(myArray);
    Console.WriteLine();
}

Main();
