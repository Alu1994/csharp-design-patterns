using System.Collections.Generic;

namespace DesignPatters_1.Specification
{
    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }
}
