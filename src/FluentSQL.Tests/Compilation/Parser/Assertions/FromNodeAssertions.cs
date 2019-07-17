using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Tests.Compilation.Parser.Assertions
{
    public class FromNodeAssertions : ReferenceTypeAssertions<FromNode, FromNodeAssertions>
    {
        public FromNodeAssertions(FromNode instance)
        {
            Subject = instance;
        }

        protected override string Identifier
        {
            get { return "FromNode"; }
        }

        public AndConstraint<FromNodeAssertions> HaveAlias(string alias, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject.Alias)
                .ForCondition(x => x == alias)
                .FailWith("Expected {context:FromNode} to have alias {0}, but it had {1}", x => alias, x => x);

            return new AndConstraint<FromNodeAssertions>(this);
        }
    }
}
