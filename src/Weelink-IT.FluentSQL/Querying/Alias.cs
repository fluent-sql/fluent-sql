namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class Alias
    {
        public Alias(string name)
        {
            Name = name;
        }

        private string Name { get; }
    }
}
