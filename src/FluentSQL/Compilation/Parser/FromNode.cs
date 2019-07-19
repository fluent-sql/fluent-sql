namespace FluentSQL.Compilation.Parser
{
    public class FromNode : AstNode
    {
        public FromNode(string @alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }
}