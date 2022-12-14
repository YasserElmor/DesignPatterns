using System.Text.Json.Serialization;

namespace DesignPatterns.Prototype
{
    public class Address : IPrototype<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        [JsonConstructorAttribute]
        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            HouseNumber = houseNumber;
        }

        public Address(Address address)
        {
            StreetName = address.StreetName;
            HouseNumber = address.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public Address DeepCopy()
        {
            return new Address(StreetName, HouseNumber);
        }
    }
}