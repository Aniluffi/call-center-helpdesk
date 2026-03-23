using CallCenterHelpdesk.Data;
using CallCenterHelpdesk.Data.Enums;
using CallCenterHelpdesk.Data.Models;
using CallCenterHelpdesk.IService;
using CallCenterHelpdesk.IService.Models.RequestService.Request;
using CallCenterHelpdesk.IService.Models.RequestService.Response;
using Microsoft.EntityFrameworkCore;

namespace CallCenterHelpdesk.Service
{
    /// <summary>
    /// сервис для создания запросов с описанием проблем которые описали люди
    /// </summary>
    public class RequestService : IRequestService
    {
        private readonly DbContextOptions<DataContext> _contextOptions;

        public RequestService(DbContextOptions<DataContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        /// <summary>
        /// Создание новой заявки
        /// </summary>
        public async Task<Guid> Create(RequestCreateRequest request)
        {
            using var db = new DataContext(_contextOptions);

            var newRequest = new Request
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Discription = request.Discription,
                PersonContact = request.PersonContact,
                Status = StatusRequestEnum.New, // По умолчанию новая
            };

            await db.Requests.AddAsync(newRequest);
            await db.SaveChangesAsync();

            return newRequest.Id;
        }

        /// <summary>
        /// Удаление заявки
        /// </summary>
        public async Task<bool> Delete(RequestDeleteRequest request)
        {
            using var db = new DataContext(_contextOptions);

            var dbRequest = await db.Requests.FindAsync(request.Id);
            if (dbRequest == null) return false;

            db.Requests.Remove(dbRequest);
            await db.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Получение детальной информации о заявке (включая данные оператора)
        /// </summary>
        public async Task<RequestGetDateilResponse> GetDateil(RequestGetDateilRequest request)
        {
            using var db = new DataContext(_contextOptions);

            var result = await db.Requests
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result == null) return null;

            return new RequestGetDateilResponse
            {
                Id = result.Id,
                Title = result.Title,
                Discription = result.Discription,
                PersonContact = result.PersonContact,
                Status = result.Status,
            };
        }

        /// <summary>
        /// Получение списка с фильтрацией
        /// </summary>
        public async Task<RequestGetListResponse> GetList(RequestGetListRequest request)
        {
            using var db = new DataContext(_contextOptions);

            var query = db.Requests.AsNoTracking().AsQueryable();

            // Фильтрация по статусу
            if (request.Statuses != null && request.Statuses.Any())
            {
                query = query.Where(x => request.Statuses.Contains(x.Status));
            }

            // Поиск по заголовку или почте
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(x => x.Title.Contains(request.Search)
                            || x.PersonContact.Contains(request.Search));
            }

            var items = await query.ToListAsync();

            return new RequestGetListResponse
            {
                Requests = items // Предполагаем, что в Response есть список
            };
        }

        /// <summary>
        /// Обновление данных заявки
        /// </summary>
        public async Task<bool> Update(RequestUpdateRequest request)
        {
            using var db = new DataContext(_contextOptions);

            var dbRequest = await db.Requests.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (dbRequest == null) return false;

            // Обновляем только те поля, которые пришли в запросе
            dbRequest.Title = request.Title;
            dbRequest.Discription = request.Discription;
            dbRequest.Status = request.Status;
            dbRequest.PersonContact = request.PersonContact;

            await db.SaveChangesAsync();
            return true;
        }
    }
}
