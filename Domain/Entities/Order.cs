using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public sealed class Order : BaseEntity
{
    public ContactInfo Sender { get; set; } = null!;
    public ContactInfo Receiver { get; set; } = null!;
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}

[Owned]
public sealed record ContactInfo
{
    public string Name { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
}