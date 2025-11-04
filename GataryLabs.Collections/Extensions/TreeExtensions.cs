namespace GataryLabs.Collections.Extensions
{
    internal static class TreeExtensions
    {
        internal static Tree<TData> SetRootData<TData>(this Tree<TData> tree, TData data)
        {
            tree.Root = new TreeNode<TData> { Data = data };
            return tree;
        }
    }
}
