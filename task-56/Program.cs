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
1) Суммируем каждую строку, записываем результат в массив (новое)
2) Ищем внутри массива минимум и его индекс (реюз кода с семинара)
*/

int[] SumUpLines(int[,] tmpArray)
{
    int [] result = new int [tmpArray.GetLength(0)]; // создаем массив для сумм, длина = кол-ву строк в исходном
    for (int i = 0; i < tmpArray.GetLength(0); i++) 
    {
        for (int j = 0; j < tmpArray.GetLength(1); j++)
        {
            result[i]=+tmpArray[i, j]; // в результирующем массиве на соответсвующее номеру строки "место" записываем сумму элементов этой строки
        }
    }
    return result;
}

int FindMinIndex(int[] tmpArray)
{
    int result = 0;
    int min = tmpArray[0];

    for (int i = 0; i < tmpArray.GetLength(0); i++)
    {

        if (tmpArray[result] > tmpArray[i])
        {
            result = i;
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

    int rowNumber = FindMinIndex(SumUpLines(myArray)) + 1; //поскольку от нас хотят номер строки, а не ее индекс, приводим 2 "человеческий" вид, считаем с первой строки (а не нулевой)
    Console.WriteLine($"Меньше всего сумма в строке {rowNumber}");
}

Main();