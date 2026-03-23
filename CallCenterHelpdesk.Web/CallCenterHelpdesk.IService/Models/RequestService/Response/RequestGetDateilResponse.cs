using CallCenterHelpdesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.IService.Models.RequestService.Response
{
    public class RequestGetDateilResponse
    {
        /// <summary>
        /// номер заявки
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// тема
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Описание проблемы
        /// </summary>
        public string? Discription { get; set; }

        /// <summary>
        /// почта человека который оставил заявку
        /// </summary>
        public string PersonContact { get; set; }

        /// <summary>
        /// статус заявки
        /// </summary>
        public StatusRequestEnum Status { get; set; }
    }
}
