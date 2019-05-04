using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.Specification
{
    public class BetterFilter : IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> products, ISpecification<Product> specification)
        {
            foreach (var product in products)
                if (specification.IsSatisfied(product))
                    yield return product;
        }
    }
}
