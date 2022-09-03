using CompositeSpecificationVisitor.Composites;
using CompositeSpecificationVisitor.Visitors;

namespace CompositeSpecificationVisitor.Leafs
{
    public class PositiveNumbers : Specification<long>
    {
        public override void Accept(ISpecificationVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override bool IsSatisfiedBy(long entity)
        {
            return entity > 0;
        }
    }
}