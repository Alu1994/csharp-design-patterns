using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns_2.Example2
{
    
    // class Foo : Bar<Foo>
    public class PersonInfoBuilder<SELF> 
        : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }
}
