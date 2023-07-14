/*
Задача 54: Задайте двумерный массив. Напишите программу, которая 
упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
*/ 

int[,] FillArrayRandom(int rows, int columns, int min, int max)
{
    int[,] result = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j =0; j < columns; j++)
        {
            result[i, j] = rnd.Next(min, max);
        }
    }
    return result;
}

void PrintArray(int[,] tmpArray)
{
    
    for (int i = 0; i< tmpArray.GetLength(0); i++)
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            Console.Write($"{tmpArray[i, j]} ");
        }
        Console.WriteLine();
    }  
}

int[,] SortInRows(int[,] tmpArray)
{
    int[,] result = new int[tmpArray.GetLength(0), tmpArray.GetLength(1)];
    for (int row = 0; row < tmpArray.GetLength(0); row++)
    {
        for (int i = 0; i < tmpArray.GetLength(0); i++)
        {
            int tmp = 0;
            if 

        }
    }
}

void Main()
{
    int[,] unsortedArray = FillArrayRandom(3, 4, 0, 10);
    PrintArray(unsortedArray);
    System.Console.WriteLine();

}

Main();