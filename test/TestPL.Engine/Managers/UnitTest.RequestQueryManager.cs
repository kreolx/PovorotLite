using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PL.Engine.Managers;
using PL.Engine.Storage.DbContexts;
using PL.Engine.Storage.Models;

namespace TestPL.Engine.Managers;

public class UnitTest_RequestQueryManager
{
    [Fact]
    public async Task GetEmptySlotsAsync_should_return_all_EmptySlots()
    {
        var context = CreateDbContext();
        var currentDate = new DateTimeOffset(2024, 9, 27, 9, 0, 0, TimeSpan.FromHours(10));
        var manager = new RequestQueryManager(context);
        var emptySlotsEnumerable = await manager.GetEmptySlotsAsync(currentDate, default);
        var emptySlots = emptySlotsEnumerable.ToArray();
        emptySlots.Should().NotBeNullOrEmpty();
        emptySlots.Should().HaveCount(10);
    }
    
    [Fact]
    public async Task GetEmptySlotsAsync_should_return_all_EmptySlots_when_slots_exits()
    {
        var context = CreateDbContext();
        var currentDate = new DateTimeOffset(2024, 9, 27, 9, 0, 0, TimeSpan.FromHours(10));
        var requests = Enumerable.Range(10, 3).Select(i => new Request
        {
            Id = Guid.NewGuid(),
            Description = "bla-bla",
            CreatedAt = currentDate,
            RequestedAt = new DateTimeOffset(2024, 9, 27, i, 0, 0, TimeSpan.FromHours(10)),
            CarModel = "StepWgn",
            Phone = "bla",
        }).ToList();
        requests.Add(new Request
        {
            Id = Guid.NewGuid(),
            Description = "bla-bla",
            CreatedAt = currentDate,
            RequestedAt = new DateTimeOffset(2024, 9, 27, 10, 0, 0, TimeSpan.FromHours(10)),
            CarModel = "StepWgn",
            Phone = "bla",

        });
        requests.Add(new Request
        {
            Id = Guid.NewGuid(),
            Description = "bla-bla",
            CreatedAt = currentDate,
            RequestedAt = new DateTimeOffset(2024, 9, 26, 10, 0, 0, TimeSpan.FromHours(10)),
            CarModel = "StepWgn",
            Phone = "bla",

        });
        context.AddRange(requests);
        await context.SaveChangesAsync();
        var manager = new RequestQueryManager(context);
        var emptySlotsEnumerable = await manager.GetEmptySlotsAsync(currentDate, default);
        var emptySlots = emptySlotsEnumerable.ToArray();
        emptySlots.Should().NotBeNullOrEmpty();
        emptySlots.Should().HaveCount(7);
    }
    
    private static ApplicationDbContext CreateDbContext() =>
        new(new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options);

}