using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPatterns_2.Example2
{
    internal class Start
    {
        static void Mains(string[] args)
        {
            var me = new Person().New
                .Called("Matheus")
                .WorkAsA("Veiga")
                .Build();

            PersonJobBuilder<Person.Builder> personInfo = new Person().New.Called("Matheuss");

            Person.Builder personJob = new Person().New.Called("Matheuss").WorkAsA("Veigas");

            Person personBuilder = new Person().New.Called("Matheuss").WorkAsA("Veigas").Build();

            // person
            WriteLine(me);
        }
    }
}
