using OpenClosedPrinciple.Specification;
using System;
using System.Collections.Generic;

namespace OpenClosedPrinciple.Combinator
{
    public class MultipleAndSpecification<T> : ISpecification<T>
    {
        IEnumerable<ISpecification<T>> specifications;

        public MultipleAndSpecification(IEnumerable<ISpecification<T>> specifications)
        {
            this.specifications = specifications ?? throw new ArgumentNullException(paramName: nameof(specifications));
        }

        public bool IsSatisfied(T t)
        {
            foreach(var specification in specifications)
                if (!specification.IsSatisfied(t))
                    return false;
            return true;
        }
    }
}