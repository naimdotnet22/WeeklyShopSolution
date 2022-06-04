
using System;

namespace zModelEntities.Models.NotificationModels
{
    public class Notificattion
    {
        public int Id { get; set; }
        public string Notification { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime NotifyDate { get; set; } = DateTime.Now;
    }
}
