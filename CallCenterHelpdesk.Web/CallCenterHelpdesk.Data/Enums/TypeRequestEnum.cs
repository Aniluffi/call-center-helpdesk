using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Enums
{
    /// <summary>
    /// тип заявки 
    /// </summary>
    public enum TypeRequestEnum
    {
        /// <summary>
        /// создано вручную оператором
        /// </summary>
        Created = 0,
        /// <summary>
        /// создано автоматически через почту
        /// </summary>
        Mail = 1,
        /// <summary>
        /// создано автоматически через API
        /// </summary>
        API = 2,
    }
}
