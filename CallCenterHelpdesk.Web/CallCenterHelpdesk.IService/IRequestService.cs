using CallCenterHelpdesk.IService.Models.RequestService.Request;
using CallCenterHelpdesk.IService.Models.RequestService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.IService
{
    /// <summary>
    /// сервис для работы с заявками 
    /// </summary>
    public interface IRequestService
    {
        /// <summary>
        /// метод создания заявки
        /// </summary>
        /// <returns></returns>
        Task<Guid> Create(RequestCreateRequest request);

        /// <summary>
        /// метод удаления заявки
        /// </summary>
        /// <returns></returns>
        Task<bool> Delete(RequestDeleteRequest request);

        /// <summary>
        /// получение детальной заявки
        /// </summary>
        /// <returns></returns>
        Task<RequestGetDateilResponse> GetDateil(RequestGetDateilRequest request);

        /// <summary>
        /// получение списка заявок
        /// </summary>
        /// <returns></returns>
        Task<RequestGetListResponse> GetList(RequestGetListRequest request);

        /// <summary>
        /// обновление статуса у задачи
        /// </summary>
        /// <returns></returns>
        Task<bool> Update(RequestUpdateRequest request);
    }
}
