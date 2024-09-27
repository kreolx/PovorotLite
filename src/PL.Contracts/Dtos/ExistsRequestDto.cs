namespace PL.Contracts.Dtos;

/// <summary>
/// Модель существующей записи на ремонт.
/// </summary>
/// <param name="Id">Идентификатор записи.</param>
/// <param name="CarModel">Марка авто.</param>
/// <param name="Phone">Телефон.</param>
/// <param name="Description">Описание ремонта.</param>
/// <param name="RequestedAt">Время ремонта.</param>
/// <param name="CreatedAt">Дата создания записи.</param>
/// <param name="UpdatedAt">Дата обновления записи.</param>
public record ExistsRequestDto(Guid Id, string CarModel, string Phone, string Description, DateTimeOffset RequestedAt, 
    DateTimeOffset CreatedAt, DateTimeOffset? UpdatedAt)
    : BaseRequestDto(CarModel, Phone, Description, RequestedAt);