using CallCenterHelpdesk.Data.Enums;
using CallCenterHelpdesk.IService;
using CallCenterHelpdesk.IService.Models.StatusService;
using CallCenterHelpdesk.IService.Models.StatusService.Request;
using CallCenterHelpdesk.IService.Models.StatusService.Response;
using Microsoft.EntityFrameworkCore;

namespace CallCenterHelpdesk.Service
{
    public class StatusService : IStatusService
    {
        // Несмотря на то, что для Enum БД не нужна, оставляем поле для соответствия интерфейсу
        public readonly DbContextOptions _contextOptions;

        public StatusService(DbContextOptions contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// Получение списка статусов из перечисления StatusRequestEnum
        /// </summary>
        public async Task<StatusGetListResponse> GetList(StatusGetListRequest request)
        {
            // Получаем все значения из Enum
            var statuses = Enum.GetValues(typeof(StatusRequestEnum))
                .Cast<StatusRequestEnum>()
                .Select(s => new StatusGetListItem // Предположим, такая модель есть в DTO
                {
                    Id = (int)s,
                    Name = GetDisplayName(s),
                })
                .ToList();

            var response = new StatusGetListResponse
            {
                Items = statuses
            };

            return await Task.FromResult(response);
        }

        /// <summary>
        /// Вспомогательный метод для маппинга названий (можно расширить через DisplayAttribute)
        /// </summary>
        private string GetDisplayName(StatusRequestEnum status)
        {
            return status switch
            {
                StatusRequestEnum.New => "Новая",
                StatusRequestEnum.InProgress => "В обработке",
                StatusRequestEnum.Resolved => "Завершена",
                StatusRequestEnum.Cansel => "Отменена",
                _ => status.ToString()
            };
        }
    }
}
