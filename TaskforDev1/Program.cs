// Задача
// Cформировать случайным образом целочисленный массив A
// из натуральных двузначных чисел.

// Создать на его основе масив B, отбрасывая те, которые
// 1  нарушают порядок возрастания
// 2  больше среднего арифметического элементов A 
// 3  чётные 

/*
Решение задачи:
1) Метод создания массива случайных чисел из натуральных, двухзначных чисел.
2) Метод среднего арифметического от всего массива А.
3) Метод создания нового массива с заданными параметрами
// 1  нарушают порядок возрастания (xi < xi+1)
// 2  больше среднего арифметического элементов A (x <= Avg)
// 3  чётные (%2 == 0).
4) Метод печати массива.
5) Основной ход программы Main.
*/

//(1)
int[] RandomArray()
{
    //Ввод параметров
    Console.WriteLine("Введите количество чисел в массиве");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите минимальное число");
    int minValue = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите максимальное число");
    int maxValue = Convert.ToInt32(Console.ReadLine()) + 1;
    int[] RandArray = new int[n];
    /*
    Проверка числа на двухзначность и на натуральность (не сексуальную)
    1) Число больше 0 (x > 0)
    2) Число двузначное число в любом множестве (10 <= x < 100)
    3) Заполнение правильным числом массива
    */
    int i = 0;
    int r = 0;
    while (i < RandArray.Length)
    {
        r = new Random().Next(minValue, maxValue);
        if ((r > 0) && (r < 100) && (r >= 10))
        {
            RandArray[i] = r;
            i++;
        }
    }
    return RandArray;

}

//(2)
double AverageArray(int[] A)
{
    double Avg = -1;
    int SummArray = 0;
    for (int i = 0; i < A.Length; i++) SummArray += A[i];
    Avg = SummArray / A.Length;
    Console.WriteLine($"Среднее Арифметическое: {Avg}");
    return Avg;
}

// (3)
int[] FormatingArray(int[] currentA)
{
    // currentA = входящий массив
    // currentB = новый массив с отсортированными числами
    // ni = индекс нового массива. Нужен для записи найденного числа в новый массив currentB
    // { -1 } - если программа не найдет искомое число, то она будет выдавать -1.
    int[] currentB = { -1 };
    int i = 0;
    int ni = 0;
    // Задаем первое число как max
    int max = currentA[i];
    // Определение первого числа, удовлетворяющее значению четности и не больше среднего арифметического
    int Avg = (int)AverageArray(currentA);
    while (i < currentA.Length)
    {
        if ((currentA[i] % 2 == 0) && (currentA[i] <= Avg))
        {
            max = currentA[i];
            currentB[ni] = max;
            break;
        }
        i++;
    }
    // Определение следующих чисел в массиве, удовлетворяющих условию.
    while (i < currentA.Length)
    {
        if ((max < currentA[i]) && (currentA[i]% 2 == 0) && (currentA[i] <= Avg))
        {
            // Если число удовлетворяет всем условиям, то:
            // Оно записывается в max и будет сравниваться со следующими
            // Индекс нового массива увеличит размер на один, max - запишется в новый массив.
            max = currentA[i];
            ni++;
            Array.Resize(ref currentB, ni + 1);
            currentB[ni] = max;
        }
        i++;
    }
    return currentB;
}

//(4)
void PrintArray(int[] a)
{
    for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
    Console.WriteLine();
}

// Main
Console.WriteLine("ВНИМАНИЕ! Случайный массив будет выводится на экран, не вводите большое значение!");
int[] A = RandomArray();
PrintArray(A);
int[] B = FormatingArray(A);
PrintArray(B);