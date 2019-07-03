namespace FluentSQL.Compilation.Parser
{
    public abstract class AstNode
    {
        public abstract void Compile(QueryCompiler compiler);
    }
}
