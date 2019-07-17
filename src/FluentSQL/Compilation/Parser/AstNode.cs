using System.Collections.Generic;

namespace FluentSQL.Compilation.Parser
{
    public class AstNode
    {
        public AstNode()
        {
            ChildNodes = new List<AstNode>();
        }

        public IList<AstNode> ChildNodes { get; }
    }
}
