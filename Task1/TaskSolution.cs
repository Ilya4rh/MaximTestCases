using MaximTestCases.Task1.Sorting;

namespace MaximTestCases.Task1;

public static class TaskSolution
{
    public static void Process()
    {
        Console.Write("Введите строку: ");
        var inputString = Console.ReadLine();

        if (string.IsNullOrEmpty(inputString))
        {
            Console.WriteLine("");
            return;
        }

        var unsuitableLetters = GetUnsuitableLetters(inputString);

        if (unsuitableLetters.Count > 0)
        {
            Console.WriteLine("Введены не подходящие символы: " + string.Join(", ", unsuitableLetters));
            return;
        }

        var modifiedString = GetModifiedString(inputString);
        var countChars = GetCountChars(modifiedString);
        var largestSubstring = GetLargestSubstring(modifiedString);
        
        Console.WriteLine("Результат: " + modifiedString);
        Console.WriteLine("Количество вхождений: " + string.Join(", ", countChars.Select(x => 
            $"{x.Key} - {x.Value}")));
        Console.WriteLine("Самая длинная подстрока начинающаяся и заканчивающаяся на гласную: " + largestSubstring);

        var sortedString = GetSortedString(modifiedString);
        
        Console.WriteLine("Отсортированая строка: " + sortedString);
    }

    private static List<char> GetUnsuitableLetters(string str)
    {
        var correctLetters = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
        
        return str.Where(c => !correctLetters.Contains(c)).ToList();
    }

    private static string GetModifiedString(string str)
    {
        if (str.Length % 2 == 0)
        {
            var part1 = str.Substring(0, str.Length / 2).ToArray();
            var part2 = str.Substring(str.Length / 2).ToArray();

            Array.Reverse(part1);
            Array.Reverse(part2);

            return new string(part1) + new string(part2);
        }

        var chars = str.ToArray();

        Array.Reverse(chars);

        return new string(chars) + str;
    }

    private static Dictionary<char, int> GetCountChars(string str)
    {
        var result = new Dictionary<char, int>();

        foreach (var c in str)
        {
            result.TryAdd(c, 0);
            result[c]++;
        }

        return result;
    }
    
    private static string GetLargestSubstring(string str)
    {
        var vowels = new HashSet<char>("aeiouy");
        var startIndex = -1;
        var endIndex = -1;

        for (var i = 0; i < str.Length; i++)
        {
            if (!vowels.Contains(str[i])) 
                continue;
            if (startIndex == -1) 
                startIndex = i;
            if (endIndex < i) 
                endIndex = i;
        }

        if (startIndex == -1 && endIndex == -1) 
            return "";

        return str.Substring(startIndex, endIndex - startIndex + 1);
    }

    private static string GetSortedString(string str)
    {
        while (true)
        {
            Console.Write("Выберите способ сортировки из предложенных в скобках (QuickSort / TreeSort) и напишите его: ");
            var sortingMethod = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(sortingMethod))
                Console.WriteLine("Ничего не введено!");
            else switch (sortingMethod)
            {
                case "QuickSort":
                    return QuickSort.GetSortedString(str);
                case "TreeSort":
                    return TreeSort.GetSortedString(str);
                default:
                    Console.WriteLine("Ошибка ввода!");
                    break;
            }
        }
    }
}