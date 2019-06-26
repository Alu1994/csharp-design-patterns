namespace DesignPatters_1.Specification
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
}
