using System.Collections.Generic;

namespace GataryLabs.Collections
{
    public class TreeNode<TData>
    {
        public TData Data { get; set; }
        public IList<TreeNode<TData>> Children { get; set; }
    }
}