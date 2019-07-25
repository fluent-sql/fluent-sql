namespace FluentSQL.Compilation.Parser.Nodes
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
