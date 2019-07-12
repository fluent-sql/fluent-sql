using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Tests.Compilation.Parser.Assertions
{
    public class AstNodeAssertions : ReferenceTypeAssertions<AstNode, AstNodeAssertions>
    {
        public AstNodeAssertions(AstNode instance)
        {
            Subject = instance;
        }

        protected override string Identifier
        {
            get { return "astNode"; }
        }

        public AndConstraint<AstNodeAssertions> BeEmpty(string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject.ChildNodes)
                .ForCondition(astNodes => astNodes.Count == 0)
                .FailWith("Expected {context:astNode} to be empty, but found {0}", astNodes => astNodes);

            return new AndConstraint<AstNodeAssertions>(this);
        }
    }
}
