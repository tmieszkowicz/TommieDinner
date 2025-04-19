using TommieDinner.Domain.Common.Enums;
using TommieDinner.Domain.Common.Models;
using TommieDinner.Domain.DinnerAggregate.ValueObjects;
using TommieDinner.Domain.GuestAggregate.ValueObjects;

namespace TommieDinner.Domain.DinnerAggregate.Entities;

public class Reservation : Entity<ReservationId>
{
    public int NumberOfGuests { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public Reservation(
        ReservationId reservationId,
        int numberOfGuests,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime) : base(reservationId)
    {
        NumberOfGuests = numberOfGuests;
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = DateTime.UtcNow;
        UpdatedDateTime = DateTime.UtcNow;
    }
    public static Reservation CreateUnique(
        int numberOfGuests,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime arrivalDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            numberOfGuests,
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime);
    }
}