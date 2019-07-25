namespace FluentSQL.Tests.Examples.Builders
{
    public class ExampleModelBuilder : TestDataBuilder<ExampleModel>
    {
        protected override ExampleModel OnBuild()
        {
            return new ExampleModel();
        }
    }
}
