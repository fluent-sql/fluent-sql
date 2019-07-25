﻿namespace FluentSQL.Compilation.Parser.Nodes
{
    public sealed class UnionNode : AstNode
    {
        public UnionNode(AstNode first, AstNode second)
        {
            First = first;
            Second = second;
        }

        public AstNode First { get; }
        public AstNode Second { get; }
    }
}