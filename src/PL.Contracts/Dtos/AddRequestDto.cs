namespace PL.Contracts.Dtos;

/// <summary>
/// Модель запроса на добавление записи на ремонт.
/// </summary>
/// <param name="CarModel">Марка авто.</param>
/// <param name="Phone">Телефон.</param>
/// <param name="Description">Описание ремонта.</param>
/// <param name="RequestedAt">Время ремонта.</param>
public record AddRequestDto(string CarModel, string Phone, string Description, DateTimeOffset RequestedAt)
    : BaseRequestDto(CarModel, Phone, Description, RequestedAt);