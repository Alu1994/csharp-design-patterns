namespace DesignPatterns_2.Example2
{
    public class Person
    {
        public string Name;
        public string Position;

        public Builder New
        {
            get
            {
                return new Builder();
            }
        }


        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    
}
