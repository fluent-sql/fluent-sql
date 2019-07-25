namespace FluentSQL.Compilation.Parser
{
    public sealed class UnionAllNode : AstNode
    {
        public UnionAllNode(AstNode first, AstNode second)
        {
            First = first;
            Second = second;
        }

        public AstNode First { get; }
        public AstNode Second { get; }
    }
}
