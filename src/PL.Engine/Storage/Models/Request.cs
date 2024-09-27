namespace PL.Engine.Storage.Models;
/// <summary>
/// Сущность записи на ремонт.
/// </summary>
public record Request
{
    /// <summary>
    /// Идентификатор запроса.
    /// </summary>
    public Guid Id { get; init; }
    /// <summary>
    /// Время ремонта.
    /// </summary>
    public DateTimeOffset RequestedAt{ get; set; }
    /// <summary>
    /// Марка автомобиля.
    /// </summary>
    public string CarModel { get; set; } = default!;
    /// <summary>
    /// Телефон.
    /// </summary>
    public string Phone { get; set; } = default!;
    /// <summary>
    /// Описание ремонта.
    /// </summary>
    public string Description { get; set; } = default!;
    /// <summary>
    /// Время создания запроса.
    /// </summary>
    public DateTimeOffset CreatedAt{ get; init; }
    /// <summary>
    /// Время обновления запроса.
    /// </summary>
    public DateTimeOffset? UpdatedAt{ get; set; }
}