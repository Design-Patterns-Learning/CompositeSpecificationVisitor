using CompositeSpecificationVisitor.Visitors;

namespace CompositeSpecificationVisitor
{
    public interface ISpecification<T>
    {
        public bool IsSatisfiedBy(T entity);
        public void Accept(ISpecificationVisitor visitor);
    }
}
