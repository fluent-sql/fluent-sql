namespace FluentSQL.Compilation.Parser
{
    public sealed class FromNode : AstNode
    {
        public FromNode()
            : this(null)
        {
        }

        public FromNode(string alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}
