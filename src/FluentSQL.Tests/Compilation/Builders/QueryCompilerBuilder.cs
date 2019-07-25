using System;

using FluentSQL.Compilation;
using FluentSQL.Compilation.Parser.Nodes;

namespace FluentSQL.Tests.Compilation.Builders
{
    public class QueryCompilerBuilder : TestDataBuilder<QueryCompiler>
    {
        private Func<AstNode, string> Compiler { get; set; }

        protected override void OnPreBuild()
        {
            if (Compiler == null)
            {
                ThatCompiles(_ => { });
            }
        }

        protected override QueryCompiler OnBuild()
        {
            return new QueryCompilerStub(this);
        }

        public QueryCompilerBuilder ThatCompiles(Func<AstNode, string> compiler)
        {
            Compiler = compiler;
            return this;
        }

        public QueryCompilerBuilder ThatCompiles(Action<AstNode> compiler)
        {
            return ThatCompiles(x =>
            {
                compiler(x);
                return string.Empty;
            });
        }

        private class QueryCompilerStub : QueryCompiler
        {
            public QueryCompilerStub(QueryCompilerBuilder builder)
            {
                Builder = builder;
            }

            private QueryCompilerBuilder Builder { get; }

            public override CompilationResult Compile(AstNode node)
            {
                string sql = Builder.Compiler(node);

                return new CompilationResult(sql);
            }
        }
    }
}
