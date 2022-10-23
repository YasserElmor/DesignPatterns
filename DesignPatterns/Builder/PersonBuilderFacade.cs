namespace DesignPatterns.Builder.Facade
{

    // this is a facade used to make use of other builders that inherit from it
    public class PersonBuilderFacade
    {
        protected Person person = new();

        public PersonJobBuilder Works => new(person);
        public PersonAddressBuilder Lives => new(person);

        // this provides implicit conversion from the PersonBuilderFacade type to the Person type
        // so that we don't have to chain a build method that returns the person after we're done building the instance
        public static implicit operator Person(PersonBuilderFacade pb)
        {
            return pb.person;
        }
    }

    public class PersonJobBuilder: PersonBuilderFacade
    {
        public PersonJobBuilder(Person person)
        {
            base.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int annualIncome)
        {
            person.AnnualIncome = annualIncome;
            return this;
        }
    }

    public class PersonAddressBuilder : PersonBuilderFacade
    {
        public PersonAddressBuilder(Person person)
        {
            base.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }
    }


        public class Person
    {
        // address
        public string? StreetAddress, PostCode, City;

        // employment
        public string? CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(City)}: {City},\n" +
                $"{nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }

    }
}
