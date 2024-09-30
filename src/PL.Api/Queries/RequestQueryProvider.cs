using PL.Engine.Storage.DbContexts;
using PL.Engine.Storage.Models;

namespace PL.Api.Queries;

public class RequestQueryProvider
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Request> GetRequests([Service] ApplicationDbContext context) =>
        context.Requests;
}