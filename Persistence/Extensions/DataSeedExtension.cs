using Domain.Entities;
using Persistence.DataContext;

namespace Persistence.Extensions;

public static class DataSeed
{
    public static async Task SeedData(this Context context)
    {
        if (context.Orders.Any())
        {
            return;    
        }
        
        var orders = new List<Order>();
        for (int i = 1; i <= 10; i++)
        {
            orders.Add(new Order()
            {
                Id = i,
                Weight = i,
                DateTime = DateTime.Today.AddDays(-i),
                Sender = new ContactInfo()
                {
                    Name = $"Sender{i}",
                    City = $"Sender City {i}",
                    Address = $"Sender Address {i}"
                },
                Receiver = new ContactInfo()
                {
                    Name = $"Receiver{i}",
                    City = $"Receiver City {i}",
                    Address = $"Receiver Address {i}"
                }
            });
        }

        foreach (var order in orders)
        {
            await context.AddAsync(order);
        }

        await context.SaveChangesAsync();
    }
}