// inheriting a fluent builder with recursive generics
namespace DesignPatterns.Builder
{

    // the generic type SELF has to be a type that inherits from the PersonInfoBuilder<SELF> class
    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            _person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkingAsA(string position)
        {
            _person.Position = position;
            return (SELF)this;
        }
    }

    public abstract class PersonBuilder
    {
        protected Person _person = new();

        public Person Build()
        {
            return _person;
        }
    }

    public class Person
    {
        public string Name { get; set; } = "";
        public string Position { get; set; } = "";
        public class Builder : PersonJobBuilder<Builder>
        {
        }
        public static Builder New => new();


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }


}
