using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Models
{
    /// <summary>
    /// настройки для создания заявок через почту
    /// </summary>
    public class MailOption
    {
        /// <summary>
        /// номер
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// НОмер админа
        /// </summary>
        public Guid OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
