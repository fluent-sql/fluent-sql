namespace FluentSQL.Compilation.Parser
{
    public class UnionAllSetOperator : SetOperator
    {
        public UnionAllSetOperator(AstNode first, AstNode second)
        {
            First = first;
            Second = second;
        }

        public AstNode First { get; }
        public AstNode Second { get; }
    }
}