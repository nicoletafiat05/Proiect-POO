using Proiect_POO.ValueObjects;

namespace Proiect_POO.Entities;

public class Donation
{
    public DonationId Id { get; }
    public UserId UserId { get; }
    public Money Amount { get; }
    public DateTime CreateAt{ get; }

    public Donation(DonationId id, UserId userId, Money amount)
    {
        Id = id;
        UserId = userId;
        Amount = amount;
        CreateAt = DateTime.Now;
    }
}