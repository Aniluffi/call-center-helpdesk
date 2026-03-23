using CallCenterHelpdesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.IService.Models.RequestService.Request
{
    public class RequestGetListRequest
    {
        /// <summary>
        /// поиск
        /// </summary>
        public string? Search { get; set; }

        /// <summary>
        /// фильтр по статусам
        /// </summary>
        public List<StatusRequestEnum> Statuses { get; set; } = new List<StatusRequestEnum>();
    }
}
