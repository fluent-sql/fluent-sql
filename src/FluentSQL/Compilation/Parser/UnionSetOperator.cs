﻿namespace FluentSQL.Compilation.Parser
{
    public class UnionSetOperator : SetOperator
    {
        public UnionSetOperator(AstNode first, AstNode second)
        {
            First = first;
            Second = second;
        }

        public AstNode First { get; }
        public AstNode Second { get; }
    }
}