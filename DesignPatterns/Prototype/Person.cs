namespace DesignPatterns.Prototype
{
    public class Person : IPrototype<Person>
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public Person(Person person)
        {
            Names = person.Names;
            Address = new Address(person.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Address)}: {Address}, {nameof(Names)}: {string.Join(" ", Names)}";
        }

        public Person DeepCopy()
        {
            return new Person(Names, Address.DeepCopy());
        }
    }
}
