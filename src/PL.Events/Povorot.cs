namespace PL.Events;

public sealed class Povorot
{
    public sealed class AddRequest
    {
        public record Requested(
            Guid CorrelationId,
            string CarModel,
            string Phone,
            string Description,
            DateTimeOffset RequestedAt);
        
        public sealed record Responded(Guid CorrelationId);
    }
    
    public sealed class UpdateRequest
    {
        public record Requested(
            Guid CorrelationId,
            Guid RequestId,
            string CarModel,
            string Phone,
            string Description,
            DateTimeOffset RequestedAt);
        
        public sealed record Responded(Guid CorrelationId);
    }

    public sealed class DeleteRequest
    {
        public record Requested(Guid CorrelationId, Guid RequestId);
        public record Responded(Guid CorrelationId);
    }
}
