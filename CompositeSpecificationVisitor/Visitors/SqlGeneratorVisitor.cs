using CompositeSpecificationVisitor.Composites;
using CompositeSpecificationVisitor.Leafs;
using System.Text;

namespace CompositeSpecificationVisitor.Visitors
{
    public class SqlGeneratorVisitor : ISpecificationVisitor
    {
        private long _value;
        private bool _hasNot;

        public SqlGeneratorVisitor(long value)
        {
            _value = value;
        }

        private StringBuilder _sqlBuilder = new StringBuilder();
        public string Sql
        {
            get
            {
                var value =
                    "SELECT 1 WHERE" +
                    _sqlBuilder.ToString();

                if (_hasNot)
                {
                    value = $"SELECT 1 WHERE 1 NOT IN ({value})";
                }

                return value;
            }
        }

        public void Visit(EvenNumbers specification)
        {
            _sqlBuilder.Append($" {_value}%2=0 ");
        }

        public void Visit(IsZeroSpecification specification)
        {
            _sqlBuilder.Append($" {_value}=0 ");
        }

        public void Visit(PositiveNumbers specification)
        {
            _sqlBuilder.Append($" {_value}>0 ");
        }

        public void Visit<T>(AndSpecification<T> specification)
        {
            _sqlBuilder.Append($"AND");
        }

        public void Visit<T>(OrSpecification<T> specification)
        {
            _sqlBuilder.Append($"OR");
        }

        public void Visit<T>(NotSpecification<T> specification)
        {
            _hasNot = true;
        }

    }
}
