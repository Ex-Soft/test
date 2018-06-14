using System.Collections.Generic;

namespace TestTree.Models
{
    public class TreeNode
    {
        public int id { get; set; }
        public int? parentId { get; set; }
        public bool leaf { get; set; }
        public string text { get; set; }
        public string cls { get; set; }
        public List<TreeNode> children { get; set; }
    }
}