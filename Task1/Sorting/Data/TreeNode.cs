namespace MaximTestCases.Task1.Sorting.Data;

public class TreeNode
{
    public char Value;
    public TreeNode? Left;
    public TreeNode? Right;

    public TreeNode(char value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}