using System.Collections.Generic;

using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Tests.Compilation.Parser.Assertions;

namespace FluentSQL.Tests.Compilation.Parser.Extensions
{
    public static class AstNodeExtensions
    {
        public static AstNodeAssertions Should(this AstNode instance)
        {
            return new AstNodeAssertions(instance);
        }

        public static IEnumerable<AstNode> Flatten(this AstNode instance)
        {
            yield return instance;

            foreach (AstNode childNode in instance.ChildNodes)
            {
                foreach (AstNode node in childNode.Flatten())
                {
                    yield return node;
                }
            }
        }
    }
}
