#pragma warning disable 1591
namespace FluentSQL.Compilation
{
    public class Node
    {
    }

    public sealed class Union : Node
    {
        public Union(Node first, Node second)
        {
            First = first;
            Second = second;
        }

        private Node First { get; }
        private Node Second { get; }
    }
    
    public sealed class UnionAll : Node
    {
        public UnionAll(Node first, Node second)
        {
            First = first;
            Second = second;
        }

        private Node First { get; }
        private Node Second { get; }
    }
}
