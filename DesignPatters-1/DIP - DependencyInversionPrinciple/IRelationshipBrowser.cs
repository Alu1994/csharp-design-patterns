using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatters_1.DIP___DependencyInversionPrinciple
{
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
}
