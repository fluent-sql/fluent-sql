namespace FluentSQL.Compilation.Parser
{
    public class UnionNode : AstNode
    {
        public UnionNode(AstNode first, AstNode second)
        {
            First = first;
            Second = second;
        }

        public AstNode First { get; }
        public AstNode Second { get; }
    }
}