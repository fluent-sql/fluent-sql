namespace FluentSQL.Compilation.Parser
{
    public class SelectNode : DataManipulationStatemeentNode
    {
        public SelectNode()
        {
            Where = new WhereClause();
            From = new FromClause();
            OrderBy = new OrderByClause();
            Having = new HavingClause();
            Select = new SelectClause();
            GroupBy = new GroupByClause();
            Limit = new LimitClause();
            Distinct = new DistinctClause();
        }

        public override void Compile(QueryCompiler compiler)
        {
            throw new System.NotImplementedException();
        }

        public WhereClause Where { get; }
        public FromClause From { get; }
        public OrderByClause OrderBy { get; }
        public HavingClause Having { get; }
        public SelectClause Select { get; }
        public GroupByClause GroupBy { get; }
        public LimitClause Limit { get; }
        public DistinctClause Distinct { get; }
    }
}