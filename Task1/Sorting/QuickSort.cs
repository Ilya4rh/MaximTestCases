namespace MaximTestCases.Task1.Sorting;

public static class QuickSort
{
    public static string GetSortedString(string str)
    {
        var chars = str.ToArray();
        
        QuickSortRealization(chars, 0, chars.Length - 1);

        return new string(chars);
    }

    private static void QuickSortRealization(char[] chars, int start, int end)
    {
        if (start >= end) return;
        
        var pivot = chars[end];
        var i = start - 1;

        for (var j = start; j < end; j++)
        {
            if (chars[j] < pivot)
            {
                i++;
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
        }

        (chars[i + 1], chars[end]) = (chars[end], chars[i+1]);
        var pivotIndex = i + 1;
        
        QuickSortRealization(chars, start, pivotIndex - 1);
        QuickSortRealization(chars, pivotIndex + 1, end);
    }
}