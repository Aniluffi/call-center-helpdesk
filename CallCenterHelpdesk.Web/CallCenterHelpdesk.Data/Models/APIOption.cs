using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Models
{
    /// <summary>
    /// настройки использования API для интеграции
    /// </summary>
    public class APIOption
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
        /// токен для использования API
        /// </summary>
        public Guid Token { get; set; } = Guid.NewGuid();

        public Guid OwnerId {  get; set; }

        public User Owner { get; set; }
    }
}
