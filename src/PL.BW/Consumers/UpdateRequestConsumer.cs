using MassTransit;
using PL.Contracts.Dtos;
using PL.Contracts.Interfaces;
using PL.Events;

namespace PL.BW.Consumers;

internal sealed class UpdateRequestConsumer(IRequestCommandManager requestCommandManager) : IConsumer<Povorot.UpdateRequest.Requested>
{
    public async Task Consume(ConsumeContext<Povorot.UpdateRequest.Requested> context)
    {
        UpdateAddRequestDto requestDto = new(context.Message.RequestId, context.Message.CarModel, context.Message.Phone,
            context.Message.Description, context.Message.RequestedAt);
        await requestCommandManager.UpdateRequestAsync(requestDto, context.CancellationToken);
        await context.Publish(new Povorot.UpdateRequest.Responded(context.Message.CorrelationId));
    }
}