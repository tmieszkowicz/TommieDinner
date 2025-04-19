using TommieDinner.Domain.Common.Models;

namespace TommieDinner.Domain.Common.ValueObjects;

public class Location : ValueObject
{
    public string Name { get; private set; }
    public string Address { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
    public Location(string name, string address, decimal latitude, decimal longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }
    public static Location CreateNew(string name, string address, decimal latitude, decimal longitude)
    {
        return new Location(name, address, latitude, longitude);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}