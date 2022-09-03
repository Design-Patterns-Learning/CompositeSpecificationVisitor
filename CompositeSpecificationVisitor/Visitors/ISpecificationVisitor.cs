using CompositeSpecificationVisitor.Composites;
using CompositeSpecificationVisitor.Leafs;

namespace CompositeSpecificationVisitor.Visitors
{
    public interface ISpecificationVisitor
    {
        void Visit(EvenNumbers specification);
        void Visit(IsZeroSpecification specification);
        void Visit(PositiveNumbers specification);
        void Visit<T>(AndSpecification<T> specification);
        void Visit<T>(OrSpecification<T> specification);
        void Visit<T>(NotSpecification<T> specification);

    }
}