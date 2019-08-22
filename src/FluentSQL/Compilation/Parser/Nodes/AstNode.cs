using System.Collections.Generic;

namespace FluentSQL.Compilation.Parser.Nodes
{
    public class AstNode
    {
        protected AstNode(AstNode parent)
        {
            ChildNodes = new List<AstNode>();
            Parent = parent;
        }

        public AstNode Parent { get; }
        public IList<AstNode> ChildNodes { get; }
    }

    public class RootNode : AstNode
    {
        public RootNode()
            : base(null)
        {
        }
    }

    public class UnionAllNode : AstNode
    {
        public UnionAllNode(AstNode first, AstNode second)
            : base(null)
        {
            ChildNodes.Add(first);
            ChildNodes.Add(second);
        }
    }

    public class UnionNode : AstNode
    {
        public UnionNode(AstNode first, AstNode second)
            : base(null)
        {
            ChildNodes.Add(first);
            ChildNodes.Add(second);
        }
    }

    public class FromNode : AstNode
    {
        public FromNode(AstNode parent, string alias = null)
            : base(parent)
        {
            Alias = alias;
        }

        public string Alias { get; }
    }

    public class SelectNode : AstNode
    {
        public SelectNode(AstNode parent)
            : base(parent)
        {
        }
    }

    public class SchemaNode : AstNode
    {
        protected SchemaNode(string name)
            : base(null)
        {
            Name = name;
        }

        public string Name { get; }
   
        public override bool Equals(object obj)
        {
            return (obj is SchemaNode that) &&
                   string.Equals(Name, that.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class TableNode : AstNode
    {
        public TableNode(SchemaNode parent, string name, string alias)
            : base(parent)
        {
            Name = name;
            Alias = alias;
        }

        public string Name { get; }
        public string Alias { get; }
  
        public override bool Equals(object obj)
        {
            return (obj is TableNode that) &&
                   Parent.Equals(that.Parent) &&
                   string.Equals(Name, that.Name) &&
                   string.Equals(Alias, that.Alias);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode() + 31 * Parent.GetHashCode();
            }
        }
    }

    public class ColumnNode : AstNode
    {
        public ColumnNode(TableNode parent, string name, string alias)
            : base(parent)
        {
            Name = name;
            Alias = alias;
        }

        public string Name { get; }
        public string Alias { get; }

        public override bool Equals(object obj)
        {
            return (obj is ColumnNode that) &&
                   Parent.Equals(that.Parent) &&
                   string.Equals(Name, that.Name) &&
                   string.Equals(Alias, that.Alias);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Name.GetHashCode() + 31 * Parent.GetHashCode();
            }
        }
    }
}
