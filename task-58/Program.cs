/*
Задача 58: Задайте две матрицы. Напишите программу, которая будет 
находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
*/

//Не будем искушать пользователя, запросим у него размеры только один раз


int[] ReadSizes(string text)
{
    Console.WriteLine(text);
    return Array.ConvertAll(Console.ReadLine()!.Split("*"), int.Parse);
}

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

int[,] MultiplyMatrices (int[,] tmpMatrix1, int[,] tmpMatrix2)
{
    int[,] result = new int[tmpMatrix1.GetLength(0), tmpMatrix1.GetLength(0)]; // путем наблюдения за примерами на странице из материалов к уроку пришла к выводу, что результирующая матрица всегда квадратна, длина стороны соответсвует числу строк в первой из перемножаемых матриц. Задаю размеры матрицы исходя из этого предположения.
    
    //в лоб: по порядку считаем каждый элемент результирующей матрицы
    result[]

    return result;

    // менее в лоб: проходим по каждому элементу первой матрицы, перемножаем его на все нужные элементы второй и прибавляем результаты на нужные места
}
/*
int MultipleInstance(int[,] arr1, int[,] arr2, int x, int y)
{
    return arr1[x, y]*arr2[x, y] + [x, y]
}
*/

void Main()
{
    int minV = 0;
    int maxV = 10;
    int[] sizes = ReadSizes("Введите размер первой матрицы через звездочку без пробелов (например, 3*4). Вторая матрица будет сформирована автоматически.");
    Console.WriteLine();
    int[,] matrix1 = FillArrayRandom(sizes[0], sizes[1], minV, maxV);
    int[,] matrix2 = FillArrayRandom(sizes[1], sizes[0], minV, maxV);

    PrintArray(matrix1);
    Console.WriteLine();

    PrintArray(matrix1);
    Console.WriteLine();

    PrintArray(MultiplyMatrices(matrix1, matrix2);
    Console.WriteLine();
}

Main();

---
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