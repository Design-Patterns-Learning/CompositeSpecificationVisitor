using CompositeSpecificationVisitor.Leafs;

namespace CompositeSpecificationVisitor.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var rule = GetRules();

            var result = rule.IsSatisfiedBy(10);

            var visitor =
                new Visitors.SqlGeneratorVisitor(10);

            rule.Accept(visitor);

            var sql = visitor.Sql;
        }
        private static ISpecification<long> GetRules()
        {
            var rule = 
                new EvenNumbers().And(new PositiveNumbers());

            return
                rule.Or(new IsZeroSpecification());
                
        }
    }
}