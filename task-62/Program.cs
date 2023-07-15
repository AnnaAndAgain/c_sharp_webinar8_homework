/*
Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07

!!! в идеале - матрицы редактируемого размера, в т. ч. несимметричные
*/





----


int[,] FillArrayRandom(int rows, int columns, int min, int max)
{
    int[,] result = new int[rows, columns];
    Random rnd = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = rnd.Next(min, max);
        }
    }
    return result;
}

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

int ReadInt(string text)
{
    Console.WriteLine(text);
    int result = Convert.ToInt32(Console.ReadLine());
    return result;
}

/*
void PrintDictionary(int[,] tmpArray)
{

    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        if (tmpArray[i, 1]>0) Console.WriteLine($"{tmpArray[i, 0]} встречается {tmpArray[i, 1]} раз(а)");
    }
}
*/

void PrintDictionary1(int[] tmpArray)
{

    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {
        if (tmpArray[i]>0) Console.WriteLine($"{i} встречается {tmpArray[i]} раз(а)");
    }
}


/* здесь с кучей прогонов вариант:
int[,] CreateDictionary(int[,] tmpArray, int tmpArrMin, int tmpArrMax)
{
    int [,] result = new int [tmpArrMax-tmpArrMin, 2];
    int index = 0; //номер строки в массиве, куда будем писать элемент и частотность
    for (int k = tmpArrMin; k < tmpArrMax; k++) //перебираем все возможные значения
    {
        int count = 0;
        for (int i = 0; i < tmpArray.GetLength(0); i++) //перебираем строки
        {
            for (int j = 0; j < tmpArray.GetLength(1); j++) //и столбцы, вместе - элементы
            {
                if (tmpArray[i, j]==k) // сравниваем с очереным возможным значением
                {
                    count ++;
                }
            }
        }
        if (count > 0)
        {
            result[index, 0] = k;
            result[index, 1] = count;
            index++;
        }
    }
    return result;
}
*/

int[] CreateDictionary1(int[,] tmpArray, int tmpArrMin, int tmpArrMax)
{
    int [] result = new int [tmpArrMax-tmpArrMin];
    for (int i = 0; i < tmpArray.GetLength(0); i++) //перебираем строки
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++) //и столбцы, вместе - элементы
        {
            result[tmpArray[i, j]]++;
        }
    }
    return result;
}

void Main()
{
    int minV = 0;
    int maxV = 10;
    int[,] myArray = FillArrayRandom(ReadInt("Введите число строк:"), ReadInt("Введите число столбцов:"), minV, maxV);
    PrintArray(myArray);
    Console.WriteLine();

    int[] arrDict = CreateDictionary1(myArray, minV, maxV);
    PrintDictionary1(arrDict);
}

Main();