namespace MaximTestCases.Task1;

public static class TaskSolution
{
    public static void Process()
    {
        Console.Write("Введите строку: ");
        var inputString = Console.ReadLine();
        Console.Write("Результат: ");

        if (string.IsNullOrEmpty(inputString))
        {
            Console.WriteLine("");
            return;
        }

        if (inputString.Length % 2 == 0)
        {
            var part1 = inputString.Substring(0, inputString.Length / 2).ToArray();
            var part2 = inputString.Substring(inputString.Length / 2).ToArray();

            Array.Reverse(part1);
            Array.Reverse(part2);

            Console.WriteLine(new string(part1) + new string(part2));
            return;
        }

        var chars = inputString.ToArray();

        Array.Reverse(chars);

        Console.WriteLine(new string(chars) + inputString);
    }
}