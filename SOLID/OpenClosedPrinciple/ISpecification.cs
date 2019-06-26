namespace OpenClosedPrinciple.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
