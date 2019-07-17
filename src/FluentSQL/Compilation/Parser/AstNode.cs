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

    public class FromNode : AstNode
    {
        public FromNode(string @alias)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }

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

    public class UnionAllNode : AstNode
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
