using System.Collections.Generic;
using System.Linq;

using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Tests.Compilation.Parser.Extensions;

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
                .ForCondition(x => x.Count == 0)
                .FailWith("Expected {context:astNode} to be empty, but found {0}", x => x);

            return new AndConstraint<AstNodeAssertions>(this);
        }

        public AndWhichConstraint<AstNodeAssertions, IEnumerable<T>> Contain<T>(string because = "", params object[] becauseArgs) where T : AstNode
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject.Flatten().OfType<T>())
                .ForCondition(x => x.Any())
                .FailWith("Expected {context:astNode} to contain elements of type {0}, but it contained {1}", x => typeof(T), x => x.Count());
            
            return new AndWhichConstraint<AstNodeAssertions, IEnumerable<T>>(this, Subject.Flatten().OfType<T>());
        }

        public AndWhichConstraint<AstNodeAssertions, T> ContainSingle<T>(string because = "", params object[] becauseArgs) where T : AstNode
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .Given(() => Subject.Flatten().OfType<T>())
                .ForCondition(x => x.Count() == 1)
                .FailWith("Expected {context:astNode} to contain a single element of type {0}, but it contained {1}", x => typeof(T), x => x.Count());

            return new AndWhichConstraint<AstNodeAssertions, T>(this, Subject.ChildNodes.OfType<T>());
        }
    }
}
