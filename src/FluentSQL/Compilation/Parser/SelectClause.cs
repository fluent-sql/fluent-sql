using System.Collections.Generic;

namespace FluentSQL.Compilation.Parser
{
    public class SelectClause : Clause
    {
        public SelectClause()
        {
            TargetSources = new List<AstNode>();
        }

        public IList<AstNode> TargetSources { get; }
    }
}