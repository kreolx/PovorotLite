using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using PL.Contracts.Dtos;
using PL.Contracts.Interfaces;
using PL.Engine.Storage.DbContexts;

[assembly: InternalsVisibleTo("TestPL.Engine")]
namespace PL.Engine.Managers;

internal sealed class RequestQueryManager(ApplicationDbContext dbContext) : IRequestQueryManager
{
    public async Task<IEnumerable<ExistsRequestDto>> GetRequestsAsync(int page, int pageSize, DateTimeOffset dateFrom, DateTimeOffset dateTo,
        CancellationToken cancellationToken)
    {
        return await dbContext.Requests
            .AsNoTracking()
            .Where(x => x.RequestedAt >= dateFrom && x.RequestedAt <= dateTo)
            .OrderBy(x => x.RequestedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(x => new ExistsRequestDto(x.Id, x.CarModel, x.Phone, x.Description, x.RequestedAt, x.CreatedAt, x.UpdatedAt))
            .ToArrayAsync(cancellationToken);
    }

    public async Task<ExistsRequestDto> GetRequestAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException($"Request with id {id} not found");
        return new ExistsRequestDto(request.Id, request.CarModel, request.Phone, request.Description,
            request.RequestedAt, request.CreatedAt, request.UpdatedAt);
    }

    public async Task<IEnumerable<DateTimeOffset>> GetEmptySlotsAsync(DateTimeOffset currentDate, CancellationToken cancellationToken)
    {
        var startDate = new DateTimeOffset(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0, TimeSpan.FromHours(10));
        var endDate = new DateTimeOffset(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59, 999, TimeSpan.FromHours(10));
        var allTimes = Enumerable.Range(9, 10)
            .Select(x => new DateTimeOffset(currentDate.Year, currentDate.Month, currentDate.Day, x, 0, 0, TimeSpan.FromHours(10)))
            .ToArray();
        
        var exists = await dbContext.Requests
            .AsNoTracking()
            .Where(x => x.RequestedAt >= startDate && x.RequestedAt <= endDate)
            .Select(x => x.RequestedAt)
            .ToArrayAsync(cancellationToken);
        exists = exists.OrderBy(x => x).ToArray();
        var slots = allTimes.Except(exists).ToArray();
        return slots;
    }
}