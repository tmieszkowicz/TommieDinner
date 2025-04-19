using TommieDinner.Application.Common.Interfaces.Services;

namespace TommieDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}