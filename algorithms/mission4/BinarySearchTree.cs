namespace algorithms.mission4;

public class BinarySearchTree<T>
{
    private readonly IComparer<T> comparer;

    public TreeNode<T>? Root { get; private set; }

    public BinarySearchTree(IComparer<T>? comparer = null)
    {
        this.comparer = comparer ?? Comparer<T>.Default;
    }

    public void Insert(T value, Action<TreeStep<T>>? onStep = null)
    {
        Root = Insert(Root, value);

        onStep?.Invoke(new TreeStep<T>(Root));
    }

    public bool IsBalanced(Action<TreeStep<T>>? onStep = null)
    {
        return GetHeight(Root, onStep) != -1;
    }

    public List<T> GetBranches(Action<TreeStep<T>>? onStep = null)
    {
        var result = new List<T>();

        GetBranches(Root, result, onStep);

        return result;
    }

    private void GetBranches(TreeNode<T>? node, List<T> result, Action<TreeStep<T>>? onStep)
    {
        if (node == null)
        {
            return;
        }

        GetBranches(node.Left, result, onStep);

        bool hasOneChild = (node.Left == null) ^ (node.Right == null);

        if (hasOneChild)
        {
            result.Add(node.Value);
        }

        onStep?.Invoke(new TreeStep<T>(Root, node, hasOneChild));

        GetBranches(node.Right, result, onStep);
    }

    private TreeNode<T> Insert(TreeNode<T>? node, T value)
    {
        if (node == null)
        {
            return new TreeNode<T>(value);
        }

        int comparison = comparer.Compare(value, node.Value);

        if (comparison < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (comparison > 0)
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    private int GetHeight(TreeNode<T>? node, Action<TreeStep<T>>? onStep)
    {
        if (node == null)
        {
            return 0;
        }

        int leftHeight = GetHeight(node.Left, onStep);

        if (leftHeight == -1)
        {
            return -1;
        }

        int rightHeight = GetHeight(node.Right, onStep);

        if (rightHeight == -1)
        {
            return -1;
        }

        bool isBalanced = Math.Abs(leftHeight - rightHeight) <= 1;

        onStep?.Invoke(new TreeStep<T>(Root, node, isBalanced, leftHeight, rightHeight));

        if (!isBalanced)
        {
            return -1;
        }

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}
