namespace MaximTestCases.Controllers.Response;
/// <summary>
/// Класс ответа на задание
/// </summary>
public class TaskAnswerResponse
{
    /// <summary>
    /// Обработанная строка
    /// </summary>
    public string ModifiedString { get; }
    
    /// <summary>
    /// Информация о том, сколько раз входил в обработанную строку каждый символ
    /// </summary>
    public string CountChars  { get; }
    
    /// <summary>
    /// Самая длинная подстрока начинающаяся и заканчивающаяся на гласную
    /// </summary>
    public string LargestSubstring  { get; }
    
    /// <summary>
    /// Отсортированная обработанная строка
    /// </summary>
    public string SortedString  { get; }
    
    /// <summary>
    /// «Урезанная» обработанная строка – обработанная строка без одного символа
    /// </summary>
    public string StringWithOutRandomChar  { get; }
    
    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="modifiedString">Обработанная строка</param>
    /// <param name="countChars">Информация о том, сколько раз входил в обработанную строку каждый символ</param>
    /// <param name="largestSubstring">Самая длинная подстрока начинающаяся и заканчивающаяся на гласную</param>
    /// <param name="sortedString">Отсортированная обработанная строка</param>
    /// <param name="stringWithOutRandomChar">«Урезанная» обработанная строка – обработанная строка без одного символа</param>
    public TaskAnswerResponse(string modifiedString, string countChars, string largestSubstring, string sortedString,
        string stringWithOutRandomChar)
    {
        ModifiedString = modifiedString;
        CountChars = countChars;
        LargestSubstring = largestSubstring;
        SortedString = sortedString;
        StringWithOutRandomChar = stringWithOutRandomChar;
    }
}