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
    int maxCount = tmpArray.GetLength(0)*tmpArray.GetLength(1);
    int maxI = tmpArray.GetLength(0)-1;
    int maxJ = tmpArray.GetLength(1)-1;
    int minI = 0;
    int minJ = 0;
    while (count <= maxCount)
    {
        for (int i = minI; i <= maxI; i++)
        {
            tmpArray[i, minJ] = count;
            count++;
            if (count > maxCount) return;
        }
        minJ++;

        for (int j = minJ; j <= maxJ; j++)
        {
            tmpArray[maxI, j] = count;
            count++;
            if (count > maxCount) return;
        }
        maxI--;

        for (int i = maxI; i >= minI; i--)
        {
            tmpArray[i, maxJ] = count;
            count++;
            if (count > maxCount) return;
        }
        maxJ--;

        for (int j = maxJ; j >= minJ; j--)
        {
            tmpArray[minI, j] = count;
            count++;
            if (count > maxCount) return;
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
