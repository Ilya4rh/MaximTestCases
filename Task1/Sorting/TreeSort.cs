using MaximTestCases.Task1.Sorting.Data;

namespace MaximTestCases.Task1.Sorting;

public class TreeSort
{
    public static string GetSortedString(string str)
    {
        var chars = str.ToArray();
        TreeNode? root = null;

        foreach (var c in chars)
        {
            root = InsertRoot(root, c);
        }

        return MakeResultString(root);
    }

    private static TreeNode InsertRoot(TreeNode? root, char value)
    {
        if (root == null)
            root = new TreeNode(value);
        else if (value < root.Value)
            root.Left = InsertRoot(root.Left, value);
        else
            root.Right = InsertRoot(root.Right, value);
        
        return root;
    }

    private static string MakeResultString(TreeNode? root)
    {
        if (root == null)
            return string.Empty;

        var result = "";
        
        result += MakeResultString(root.Left);
        result += root.Value;
        result += MakeResultString(root.Right);

        return result;
    }
}