using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.UserAggregate.ValueObjects;

namespace TommieDinner.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(
        UserId userId,
        string FirstName,
        string LastName,
        string Email,
        string Password, //hash this
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(userId)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.Password = Password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User CreateUnique(
        string FirstName,
        string LastName,
        string Email,
        string Password)
    {
        return new(
            UserId.CreateUnique(),
            FirstName,
            LastName,
            Email,
            Password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
