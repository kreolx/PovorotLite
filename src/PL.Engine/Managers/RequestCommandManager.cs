using Microsoft.EntityFrameworkCore;
using PL.Contracts.Dtos;
using PL.Contracts.Interfaces;
using PL.Engine.Storage.DbContexts;
using PL.Engine.Storage.Models;

namespace PL.Engine.Managers;

internal sealed class RequestCommandManager(ApplicationDbContext dbContext) : IRequestCommandManager
{
    public async Task AddRequestAsync(AddRequestDto addRequest, CancellationToken cancellationToken)
    {
        ValidateRequest(addRequest);
        var request = new Request
        {
            Id = Guid.NewGuid(),
            Description = addRequest.Description,
            CarModel = addRequest.CarModel,
            RequestedAt = addRequest.RequestedAt,
            Phone = addRequest.Phone,
            CreatedAt = DateTimeOffset.UtcNow,
        };
        dbContext.Requests.Add(request);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteRequestAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = await dbContext.Requests.FirstOrDefaultAsync(d => d.Id == id, cancellationToken)
            ?? throw new KeyNotFoundException($"Request with id {id} not found");
        dbContext.Requests.Remove(request);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRequestAsync(UpdateAddRequestDto addRequestDto, CancellationToken cancellationToken)
    {
        ValidateRequest(addRequestDto);
        var request = await dbContext.Requests.FirstOrDefaultAsync(d => d.Id == addRequestDto.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Request with id {addRequestDto.Id} not found");
        request.Description = addRequestDto.Description;
        request.CarModel = addRequestDto.CarModel;
        request.Phone = addRequestDto.Phone;
        request.RequestedAt = addRequestDto.RequestedAt;
        request.UpdatedAt = DateTimeOffset.UtcNow;
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    private void ValidateRequest(BaseRequestDto addRequest)
    {
        if (addRequest.RequestedAt.Minute > 0)
        {
            throw new ArgumentException("RequestedAt must be at 00:00", nameof(addRequest.RequestedAt));
        }
        if (addRequest.RequestedAt.Hour is < 9 or > 18)
        {
            throw new ArgumentException("RequestedAt must be between 9:00 and 18:00", nameof(addRequest.RequestedAt));
        }
        if (DateTimeOffset.UtcNow.AddDays(13) < addRequest.RequestedAt)
        {
            throw new ArgumentException("RequestedAt must be less than 13 days from now", nameof(addRequest.RequestedAt));
        }
    }
}