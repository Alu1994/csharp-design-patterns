using System.Linq;
using static System.Console;

namespace DependencyInversionPrinciple
{
    // high-level
    public class ResearchWrong
    {
        public ResearchWrong(RelationshipsWrong relationships)
        {
            var relations = relationships.Relations;
            foreach (var r in relations.Where(x => x.Item1.Name == "John" && x.Item2 == Relationship.Parent))
            {
                WriteLine($"John has a child called {r.Item3.Name}");
            }
        }

        public static void Search()
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new RelationshipsWrong();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new ResearchWrong(relationships);
        }
    }
}
