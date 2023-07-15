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


int ReadInt(string text)
{
    Console.WriteLine(text);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}

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

// свожу задачу к сортировке одномерных массивов, соответсвующих строкам,
// методом перестановки рабочего элеиента с максимальным (с лекции) 
// и их возврату в массив

void ArraySorMaxMin(int[] tmpArray)
{
    for (int i = 0; i < tmpArray.Length - 1; i++)
    {
        int maxPosition = i;

        for (int j = i + 1; j < tmpArray.Length; j++)
        {
            if (tmpArray[j] > tmpArray[maxPosition]) maxPosition = j;
        }

        int temporary = tmpArray[i];
        tmpArray[i] = tmpArray[maxPosition];
        tmpArray[maxPosition] = temporary;
    }
};

void SortInRows(int[,] tmpArray)
{
    int[] oneRowArray = new int[tmpArray.GetLength(1)];
    for (int i = 0; i < tmpArray.GetLength(0); i++) // для каждой строки...
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++) //выгружаем строку в массив
        {
            oneRowArray [j] = tmpArray[i, j]; 
        }
        ArraySorMaxMin(oneRowArray); // сортируем получившийся массив
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            tmpArray[i, j] = oneRowArray [j] ; //вгружаем обратно
        }
    }
}

void Main()
{
    int minV = 0;
    int maxV = 10;
    int[,] unsortedArray = FillArrayRandom(ReadInt("Введите число строк:"), ReadInt("Введите число столбцов:"), minV, maxV);
    PrintArray(unsortedArray);
    System.Console.WriteLine();

    SortInRows(unsortedArray);
    PrintArray(unsortedArray);
}

Main();