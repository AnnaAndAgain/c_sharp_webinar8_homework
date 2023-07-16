/*
Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся 
двузначных чисел. Напишите программу, которая будет 
построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
*/



int[,,] FillArrayRandom(int rows, int columns, int layers, int min, int max)
{
    int[,,] result = new int[rows, columns, layers];
    int tmp = 0;
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            for (int k = 0; k < layers; k++)
            {
                tmp = rnd.Next(min, max);
                while (NotUnique(result, tmp))
                {
                    tmp = rnd.Next(min, max);
                }
                result[i, j, k] = tmp;
            }
        }
    }
    return result;
}

bool NotUnique(int[,,] tmpArray, int tmpNumber) 
{
    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            for (int k = 0; k < tmpArray.GetLength(2); k++)
            {
                if (tmpArray[i, j, k] == tmpNumber) return true;
            }
        }
    }
    return false;
}

void PrintArray3(int[,,] tmpArray)
{
    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            for (int k = 0; k < tmpArray.GetLength(2); k++)
            {
                Console.Write(tmpArray[i, j, k] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void PrintIndexes(int[,,] tmpArray)
{
    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            for (int k = 0; k < tmpArray.GetLength(2); k++)
            {
                Console.Write($"{tmpArray[i, j, k]} ({i}, {j}, {k}) \t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

void Main()
{
    int[,,] myArray = FillArrayRandom(2, 3, 4, 10, 100);
    PrintArray3(myArray);
    Console.WriteLine();
    PrintIndexes(myArray);
    Console.WriteLine();
}

Main();