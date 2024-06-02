﻿namespace MaximTestCases.Task1;

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
        
        Console.WriteLine("Результат: " + modifiedString);
        Console.WriteLine("Количество вхождений: " + string.Join(", ", countChars.Select(x => 
            $"{x.Key} - {x.Value}")));
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
}