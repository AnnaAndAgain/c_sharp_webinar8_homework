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



-------
/*
Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/



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