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
    
    /*сначала хотела считать в лоб: по порядку считаем каждый элемент результирующей матрицы; но осознала, что будет ужасное кол-во циклов, так что пробую иначе:
    проходить по каждому элементу первой матрицы, перемножаем его на все нужные элементы второй и прибавляем результаты на нужные места
    */
    
    for (int i = 0; i < tmpMatrix1.GetLength(0); i++) //это индексы строк первой матрицы
    {
        for (int j = 0; j < tmpMatrix1.GetLength(1); j++) //и индексы столбцов, получаем элемент первой матрицы
        {
            for (int k = 0; k< tmpMatrix2.GetLength(1); k++) // а этот счетчик поможет перебрать все элементы второй матрицы, на которые нужно найденный элемент умножить; его строка задана номером столбца первой матрицы, это будет его столбец
            {
                //перемножаем [i.j] первой матрицы на поочередно все [j, k] элементы второй
                //результат пишем в [i, k] элемент нового массиваб прибавляя к тому, что там уже лежит
                result[i, k] += tmpMatrix1[i, j]*tmpMatrix2[j, k];
            }
        }
    }
    return result;
}

void Main()
{
    int minV = 0;
    int maxV = 10; //это будет "не включая 10"
    int[] sizes = ReadSizes("Введите размер первой матрицы через звездочку без пробелов (например, 3*4). Вторая матрица будет сформирована автоматически.");
    Console.WriteLine();
    int[,] matrix1 = FillArrayRandom(sizes[0], sizes[1], minV, maxV);
    int[,] matrix2 = FillArrayRandom(sizes[1], sizes[0], minV, maxV);

    PrintArray(matrix1);
    Console.WriteLine();

    PrintArray(matrix2);
    Console.WriteLine();

    PrintArray(MultiplyMatrices(matrix1, matrix2));
    Console.WriteLine();
}

void Check1_tz() // Проверяю на матрицах из ТЗ, ожидаю {{18, 20}, {15, 18}}
{
    int[,] matrix1 = {{2, 4}, {3, 2}};
    int[,] matrix2 = {{3, 4}, {3, 3}};

    PrintArray(matrix1);
    Console.WriteLine();

    PrintArray(matrix2);
    Console.WriteLine();

    PrintArray(MultiplyMatrices(matrix1, matrix2));
    Console.WriteLine();
}

void Check2_website() // Проверяю на первом примере с сайта, прямоугольные матрицы. Ожидаю {{12, ​14}, {16, 12​}}
{
    int[,] matrix1 = {{1, 2, 2}, {3, 1, 1}};
    int[,] matrix2 = {{4, 2}, {3, 1}, {1, 5}};

    PrintArray(matrix1);
    Console.WriteLine();

    PrintArray(matrix2);
    Console.WriteLine();

    PrintArray(MultiplyMatrices(matrix1, matrix2));
    Console.WriteLine();
}

Main();
//Check1_tz();
//Check2_website();