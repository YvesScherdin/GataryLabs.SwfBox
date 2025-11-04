using System;
using System.Collections.Generic;
using System.Linq;

namespace GataryLabs.Collections.Extensions
{
    internal static class TreeNodeExtensions
    {
        internal static TreeNode<TData> AddChild<TData>(this TreeNode<TData> treeNode, TData data)
        {
            if (treeNode.Children == null)
                treeNode.Children = new List<TreeNode<TData>>();

            treeNode.Children.Add(new TreeNode<TData> { Data = data });

            return treeNode;
        }

        internal static TreeNode<TData> AddUniqueChild<TData>(this TreeNode<TData> treeNode, TData data)
        {
            if (treeNode.Children == null)
                treeNode.Children = new List<TreeNode<TData>>();

            if (!treeNode.Children.Any(x => Object.Equals(x.Data, data)))
                treeNode.Children.Add(new TreeNode<TData> { Data = data });

            return treeNode;
        }
    }
}
