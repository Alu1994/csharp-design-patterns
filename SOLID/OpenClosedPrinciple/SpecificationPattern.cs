using OpenClosedPrinciple.Combinator;
using System;
using static System.Console;

namespace OpenClosedPrinciple.Specification
{
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large, Yuge
    }

    public enum Gender
    {
        Female, Male
    }

    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;
        public Gender Gender;

        public Product(string name, Color color, Size size, Gender gender)
        {
            if (name == null)
                throw new ArgumentNullException(paramName: nameof(name));

            Name = name;
            Color = color;
            Size = size;
            Gender = gender;
        }
    }

    public class OpenClosedPrinciple_Inheritance_SpecificationPattern
    {
        static void Main_s(string[] args)
        {
            var apple = new Product("Apple", Color.Blue, Size.Small, Gender.Male);
            var tree = new Product("Tree", Color.Green, Size.Large, Gender.Female);
            var house = new Product("House", Color.Blue, Size.Large, Gender.Male);

            Product[] products = { apple, tree, house };

            var bf = new BetterFilter();
            WriteLine("[1 filter] - Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                WriteLine($" - {p.Name} is green");
            }

            WriteLine("[And] - Large blue items");
            foreach (var p in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                WriteLine($" - {p.Name} is big and blue");
            }

            WriteLine("[Or] - Large blue items");
            foreach (var p in bf.Filter(products, new OrSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            {
                WriteLine($" - {p.Name} is big or blue or maybe both kk");
            }


            var colorSpec = new ColorSpecification(Color.Blue);
            var sizeSpec = new SizeSpecification(Size.Large);
            var genderSpec = new GenderSpecification(Gender.Male);
            var multiSpec = new MultipleAndSpecification<Product>(new ISpecification<Product>[] { colorSpec, sizeSpec, genderSpec });
            WriteLine("[MultipleAnd] - Large, blue and male items");
            foreach (var p in bf.Filter(products, multiSpec))
            {
                WriteLine($" - {p.Name} is big, blue and male");
            }
        }
    }
}