using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Tests.Compilation.Parser.Assertions;

namespace FluentSQL.Tests.Compilation.Parser.Extensions
{
    public static class FromNodeExtensions
    {
        public static FromNodeAssertions Should(this FromNode instance)
        {
            return new FromNodeAssertions(instance);
        }
    }
}
