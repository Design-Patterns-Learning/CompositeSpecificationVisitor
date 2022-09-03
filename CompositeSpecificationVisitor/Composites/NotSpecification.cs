using CompositeSpecificationVisitor.Visitors;

namespace CompositeSpecificationVisitor.Composites
{
    public class NotSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _targetSpec;

        public NotSpecification
            (ISpecification<T> targetSpec)
        {
            _targetSpec = targetSpec;
        }

        public override void Accept(ISpecificationVisitor visitor)
        {
            visitor.Visit(this);

            _targetSpec.Accept(visitor);
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return !_targetSpec.IsSatisfiedBy(entity);
        }
    }
}