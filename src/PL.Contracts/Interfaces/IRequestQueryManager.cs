using PL.Contracts.Dtos;

namespace PL.Contracts.Interfaces;

/// <summary>
/// Менеджер запросов на чтение к сущности запись на ремонт.
/// </summary>
public interface IRequestQueryManager
{
    /// <summary>
    /// Получить список записей на ремонт.
    /// </summary>
    /// <param name="page">Страница.</param>
    /// <param name="pageSize">Количество записей.</param>
    /// <param name="dateFrom">Дата начала.</param>
    /// <param name="dateTo">Дата окочания.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    /// <returns><see cref="IEnumerable{ExistsRequestDto}"/></returns>
    Task<IEnumerable<ExistsRequestDto>> GetRequestsAsync(int page, int pageSize, DateTimeOffset dateFrom, DateTimeOffset dateTo,
        CancellationToken cancellationToken);
    
    /// <summary>
    /// Получить запись на ремонт.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    /// <returns><see cref="ExistsRequestDto"/></returns>
    Task<ExistsRequestDto> GetRequestAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Получить пустые слоты на ремонт.
    /// </summary>
    /// <param name="currentDate">Дата свободных слотов.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    /// <returns><see cref="IEnumerable{DateTimeOffset}"/></returns>
    Task<IEnumerable<DateTimeOffset>> GetEmptySlotsAsync(DateTimeOffset currentDate, CancellationToken cancellationToken);
}