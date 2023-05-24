using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

public sealed class Order : BaseEntity
{
    public ContactInfo Sender { get; set; } = null!;
    public ContactInfo Receiver { get; set; } = null!;
    [Range(0, 1000000)]
    public int Weight { get; set; }
    public DateTime DateTime { get; set; }
}

[Owned]
public sealed record ContactInfo
{
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(50)]
    public string City { get; set; } = null!;
    [MaxLength(50)]
    public string Address { get; set; } = null!;
}