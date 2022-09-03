using CompositeSpecificationVisitor.Visitors;

namespace CompositeSpecificationVisitor.Composites
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _leftSpec;
        private readonly ISpecification<T> _rightSpec;

        public AndSpecification
            (ISpecification<T> leftSpec, ISpecification<T> rightSpec)
        {
            _leftSpec = leftSpec;
            _rightSpec = rightSpec;
        }

        public override void Accept(ISpecificationVisitor visitor)
        {
            _leftSpec.Accept(visitor);

            visitor.Visit(this);

            _rightSpec.Accept(visitor);
        }

        public override bool IsSatisfiedBy(T entity)
        {
            return _leftSpec.IsSatisfiedBy(entity) &&
                   _rightSpec.IsSatisfiedBy(entity);
        }

    }
}