using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Enums
{
    /// <summary>
    /// статус заявки
    /// </summary>
    public enum StatusRequestEnum
    {
        /// <summary>
        /// только созданная
        /// </summary>
        New,
        /// <summary>
        /// обрабаьывается
        /// </summary>
        InProgress,
        /// <summary>
        /// Завершена
        /// </summary>
        Resolved,
        /// <summary>
        /// отменена
        /// </summary>
        Cansel
    }
}
