namespace PL.Contracts.Dtos;

/// <summary>
/// Модель на обновление записи.
/// </summary>
/// <param name="Id">Идентификатор записи.</param>
/// <param name="CarModel">Марка авто.</param>
/// <param name="Phone">Телефон.</param>
/// <param name="Description">Описание ремонта.</param>
/// <param name="RequestedAt">Время ремонта.</param>
public record UpdateAddRequestDto(Guid Id, string CarModel, string Phone, string Description, DateTimeOffset RequestedAt) 
    : AddRequestDto(CarModel, Phone, Description, RequestedAt);