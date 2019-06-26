namespace OpenClosedPrinciple.Specification
{
    public class GenderSpecification : ISpecification<Product>
    {
        private Gender gender;

        public GenderSpecification(Gender gender)
        {
            this.gender = gender;
        }

        public bool IsSatisfied(Product t)
        {
            return t.Gender == gender;
        }
    }
}
