using CallCenterHelpdesk.IService.Models.StatusService.Request;
using CallCenterHelpdesk.IService.Models.StatusService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.IService
{
    /// <summary>
    /// сервис для работы со статусами
    /// </summary>
    public interface IStatusService
    {
       
        /// <summary>
        /// получение спсика статусов
        /// </summary>
        /// <returns></returns>
        Task<StatusGetListResponse> GetList(StatusGetListRequest request);

    }
}
