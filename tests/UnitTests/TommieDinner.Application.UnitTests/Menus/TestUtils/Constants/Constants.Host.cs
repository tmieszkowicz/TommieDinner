using TommieDinner.Domain.HostAggregate.ValueObjects;

namespace TommieDinner.Application.UnitTests.Menus.TestUtils.Constants;

public static partial class Constants
{
    public static class Host
    {
        public static readonly HostId Id = HostId.CreateUnique("Host Id");
    }
}