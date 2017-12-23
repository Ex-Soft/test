namespace TreeLibrary.BinaryTree
{
    public class Node
    {
        public string Name { get; set; }
        public Node Parent { get; set; }
        public Node NodeLeft { get; set; }
        public Node NodeRight { get; set; }

        public Node(string name = "", Node parent = null, Node nodeLeft = null, Node nodeRight = null)
        {
            Name = name;
            Parent = parent;
            NodeLeft = nodeLeft;
            NodeRight = nodeRight;
        }

        public bool IsRoot => Parent == null;

        public override string ToString()
        {
            return $"{{Name:\"{(!string.IsNullOrWhiteSpace(Name) ? Name : "null")}\", Parent:\"{(Parent != null ? Parent.Name : "null")}\", Left:\"{(NodeLeft != null ? NodeLeft.Name : "null")}\", Right:\"{(NodeRight != null ? NodeRight.Name : "null")}\"}}";
        }

        public int Level
        {
            get
            {
                var level = 0;
                var parent = this;

                while ((parent = parent.Parent) != null)
                    ++level;

                return level;
            }
        }
    }
}
