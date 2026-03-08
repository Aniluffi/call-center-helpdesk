using CallCenterHelpdesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Models
{
    /// <summary>
    /// пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// номер пользователя
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// почта
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// пароль
        /// </summary>
        public string PasswordHash { get; set; }

        public UserRoleEnum Role { get; set; } 

        public Guid? OwnerId { get; set; }

        public User? Owner { get; set; }

        public List<User> Users { get; set; }

        public List<Request> Requests { get; set; }

        public List<MailOption>? MailOptions { get; set; }

        public List<APIOption> APIOptions { get; set; }
    }
}
