using MassTransit;
using PL.Contracts.Dtos;
using PL.Contracts.Interfaces;
using PL.Events;

namespace PL.BW.Consumers;

internal sealed class AddRequestConsumer(IRequestCommandManager requestManager) : IConsumer<Povorot.AddRequest.Requested>
{
    public async Task Consume(ConsumeContext<Povorot.AddRequest.Requested> context)
    {
        AddRequestDto requestDto = new AddRequestDto(context.Message.CarModel, context.Message.Phone, context.Message.Description, context.Message.RequestedAt);
        await requestManager.AddRequestAsync(requestDto, context.CancellationToken);
        await context.Publish(new Povorot.AddRequest.Responded(context.Message.CorrelationId));
    }
}