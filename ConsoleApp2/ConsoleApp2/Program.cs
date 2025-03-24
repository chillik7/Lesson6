using System;

public delegate int[] ArrayProcessor(int[] array);

class ArrayHandler
{
    public static int[] ProcessArray(int[] array, ArrayProcessor processor)
    {
        return processor(array);
    }
    public static int[] SortAscending(int[] array)
    {
        Array.Sort(array);
        return array;
    }
    public static int[] SortDescending(int[] array)
    {
        Array.Sort(array, (a, b) => b.CompareTo(a));
        return array;
    }
}

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 3, 8, 1, 2 };

        Console.WriteLine("Исходный массив: " + string.Join(", ", numbers));

        int[] sortedAsc = ArrayHandler.ProcessArray(numbers, ArrayHandler.SortAscending);
        Console.WriteLine("Отсортировано по возрастанию: " + string.Join(", ", sortedAsc));

        int[] sortedDesc = ArrayHandler.ProcessArray(numbers, ArrayHandler.SortDescending);
        Console.WriteLine("Отсортировано по убыванию: " + string.Join(", ", sortedDesc));
    }
}
