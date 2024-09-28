using MassTransit;
using PL.Contracts.Interfaces;
using PL.Events;

namespace PL.BW.Consumers;

internal sealed class DeleteRequestConsumer(IRequestCommandManager requestCommandManager) : IConsumer<Povorot.DeleteRequest.Requested>
{
    public async Task Consume(ConsumeContext<Povorot.DeleteRequest.Requested> context)
    {
        await requestCommandManager.DeleteRequestAsync(context.Message.RequestId, context.CancellationToken);
        await context.Publish(new Povorot.DeleteRequest.Responded(context.Message.CorrelationId));
    }
}