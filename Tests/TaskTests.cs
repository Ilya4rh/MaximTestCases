using MaximTestCases.Task1;
using MaximTestCases.Task1.Sorting;
using NUnit.Framework;

namespace MaximTestCases.Tests;

public class TaskTests
{
    [TestCase("qwer", "wqre")]
    [TestCase("qwert", "trewqqwert")]
    [TestCase("asfjnsdgkdsdfmdf", "gdsnjfsafdmfdsdk")]
    [TestCase("qlcjzplru", "urlpzjclqqlcjzplru")]
    [TestCase("qlcjzplrusrnrbgfgvbfrter", "nrsurlpzjclqretrfbvgfgbr")]
    public void CheckModifiedString(string inputString, string expectedModifiedString)
    {
        var result = TaskSolution.GetModifiedString(inputString);

        Assert.That(result.Equals(expectedModifiedString), Is.True);
    }
    
    [TestCase("wqre", "w - 1, q - 1, r - 1, e - 1")]
    [TestCase("trewqqwert", "t - 2, r - 2, e - 2, w - 2, q - 2")]
    [TestCase("gdsnjfsafdmfdsdk", "g - 1, d - 4, s - 3, n - 1, j - 1, f - 3, a - 1, m - 1, k - 1")]
    [TestCase("urlpzjclqqlcjzplru", "u - 2, r - 2, l - 4, p - 2, z - 2, j - 2, c - 2, q - 2")]
    [TestCase("nrsurlpzjclqretrfbvgfgbr", 
        "n - 1, r - 5, s - 1, u - 1, l - 2, p - 1, z - 1, j - 1, c - 1, q - 1, e - 1, t - 1, f - 2, b - 2, v - 1, g - 2")]
    public void CheckCountChars(string modifiedString, string expectedCountCharsString)
    {
        var result = TaskSolution.GetCountChars(modifiedString);
        var resultToString = string.Join(", ", result.Select(x => $"{x.Key} - {x.Value}"));
        
        Assert.That(resultToString.Equals(expectedCountCharsString), Is.True);
    }

    [TestCase("wqre", "e")]
    [TestCase("trewqqwert", "ewqqwe")]
    [TestCase("gdsnjfsafdmfdsdk", "a")]
    [TestCase("urlpzjclqqlcjzplru", "urlpzjclqqlcjzplru")]
    [TestCase("nrsurlpzjclqretrfbvgfgbr", "urlpzjclqre")]
    public void CheckLargestSubstring(string modifiedString, string expectedLargestSubstring)
    {
        var result = TaskSolution.GetLargestSubstring(modifiedString);
        
        Assert.That(result.Equals(expectedLargestSubstring), Is.True);
    }
    
    [TestCase("wqre", "eqrw")]
    [TestCase("trewqqwert", "eeqqrrttww")]
    [TestCase("gdsnjfsafdmfdsdk", "addddfffgjkmnsss")]
    [TestCase("urlpzjclqqlcjzplru", "ccjjllllppqqrruuzz")]
    [TestCase("nrsurlpzjclqretrfbvgfgbr", "bbceffggjllnpqrrrrrstuvz")]
    public void CheckSortedString(string modifiedString, string expectedSortedString)
    {
        var sortedStringQuickSort = QuickSort.GetSortedString(modifiedString);
        var sortedStringTreeSort = TreeSort.GetSortedString(modifiedString);
        
        Assert.That(sortedStringQuickSort.Equals(expectedSortedString), Is.True);
        Assert.That(sortedStringTreeSort.Equals(expectedSortedString), Is.True);
    }

    [TestCase("wqre", 3)]
    [TestCase("trewqqwert", 9)]
    [TestCase("gdsnjfsafdmfdsdk", 15)]
    [TestCase("urlpzjclqqlcjzplru", 17)]
    [TestCase("nrsurlpzjclqretrfbvgfgbr", 23)]
    public void CheckLengthStringWithOutRandomChar(string modifiedString, int expectedLength)
    {
        var stringWithOutRandomChar = TaskSolution.GetStringWithOutRandomChar(modifiedString);
        
        Assert.That(expectedLength.Equals(stringWithOutRandomChar.Length), Is.True);
    }
}