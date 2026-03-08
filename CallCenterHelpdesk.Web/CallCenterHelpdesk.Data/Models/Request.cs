using CallCenterHelpdesk.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallCenterHelpdesk.Data.Models
{
    /// <summary>
    /// заявка пользователя
    /// </summary>
    public class Request
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
        public string Discription { get; set; }

        /// <summary>
        /// почта человека который оставил заявку
        /// </summary>
        public string PersonEmail { get; set; }

        /// <summary>
        /// тип заявки
        /// </summary>
        public TypeRequestEnum Type {  get; set; }
        /// <summary>
        /// статус заявки
        /// </summary>
        public StatusRequestEnum Status { get; set; }
        /// <summary>
        /// номер оператора
        /// </summary>
        public Guid? UserId { get; set; }

        public User? User {  get; set; }

    }
}
