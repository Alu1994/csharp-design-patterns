using System.Collections.Generic;
using System.Linq;

namespace DesignPatters_1.DIP___DependencyInversionPrinciple
{
    // low-level
    public class RelationshipsWrong
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public List<(Person, Relationship, Person)> Relations => relations;
    }
}
