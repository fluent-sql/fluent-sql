using FluentSQL.Compilation.Parser;
using FluentSQL.Tests.Compilation.Parser.Assertions;

namespace FluentSQL.Tests.Compilation.Parser.Extensions
{
    public static class AstNodeExtensions
    {
        public static AstNodeAssertions Should(this AstNode instance)
        {
            return new AstNodeAssertions(instance);
        }
    }
}
