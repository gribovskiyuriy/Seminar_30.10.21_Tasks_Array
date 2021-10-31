/* Приветствую! Задание:
Имеется числовой массив A заполненный числами из отрезка [minValue; maxValue].
Создать на его основе масив B, отбрасывая те, которые нарушают порядок
-возрастания
-элементы, больше 8
-знакочередования

Решение:
1) Определение массива
2) Создание метода, который выдает случайные числа
3) Создание метода, которые проверяет числа на условие
4) Соединения методов основной программой 
*/

// Имеется числовой массив A заполненный числами из отрезка [minValue; maxValue].
Console.WriteLine("Введите количество чисел в массиве");
int count = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите минимальное число");
int minVal = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите максимальное число");
int maxVal = Convert.ToInt32(Console.ReadLine());


int[] WorkingArray(int n, int minValue, int maxValue)
{
    int[] a = new int[n];
    for (int i = 0; i < a.Length; i++) a[i] = new Random().Next(minValue, maxValue);
    return a;
}

void FormatingArray(int[] inputA)
{
    Console.WriteLine("Отсортированные числа: ");
    // Определяем начальные значения, x - в нашем задании это число 8
    // check нужен как логический оператор для проверки значений, которые программа будет находить
    // Если в массиве нет значений, которые < x (8), то программа будет завершать метод с выводом "Нет чисел"
    int i, findNumber = -1;
    int x = 8;
    bool check = false;

    // Проверяем первое число на условие "х < 8" в массиве
    for (i = 0; i < inputA.Length; i++)
    {
        if (inputA[i] <= x)
        {
            check = true;
            Console.Write(inputA[i] + " ");
            break;
        }
    }
    // Если таких чисел не будет, программа будет выдавать check == false и закончит метод
    // Если такое число будет, будет выбираться тело в else 
    if (!check)
    {
        Console.WriteLine("Нет чисел");
    }

    else
    {
        //Определяем последующие за определенным числом числа 
        findNumber = inputA[i];
        i++;

        while (i < inputA.Length)
        {
            //первое число меньше второго ?
            if (findNumber < inputA[i])
            {
                //второе число меньше или равно 8 ?
                if (inputA[i] <= x)
                {
                    //первое и второе не чередуются знаками?
                    if ((findNumber < 0 && inputA[i] < 0) || (findNumber > 0 && inputA[i] > 0))
                    {
                        //Выводим второе число и считаем от него
                        findNumber = inputA[i];
                        Console.Write(findNumber + " ");

                    }
                }
            }
            i++;
        }

    }
}

int[] myArray = WorkingArray(count, minVal, maxVal);
FormatingArray(myArray);