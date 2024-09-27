using PL.Contracts.Dtos;

namespace PL.Contracts.Interfaces;


/// <summary>
/// Менеджер для работы с командами над сущностью записи на ремонт.
/// </summary>
public interface IRequestCommandManager
{
    /// <summary>
    /// Добавление записи на ремонт.
    /// </summary>
    /// <param name="addRequest">Дто с данными запроса.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task AddRequestAsync(AddRequestDto addRequest, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление записи на ремонт.
    /// </summary>
    /// <param name="id">Идентификатор записи.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task DeleteRequestAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновление записи на ремонт.
    /// </summary>
    /// <param name="addRequestDto">Дто с данными запроса.</param>
    /// <param name="cancellationToken">Асинхронный токен отмены.</param>
    Task UpdateRequestAsync(UpdateAddRequestDto addRequestDto, CancellationToken cancellationToken);
}