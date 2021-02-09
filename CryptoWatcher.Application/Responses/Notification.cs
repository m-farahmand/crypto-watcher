﻿using System;
using CryptoWatcher.Domain.Types;

namespace CryptoWatcher.Application.Responses
{
    public class Notification
    {
        public Guid NotificationId { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime? SentTime { get; set; }
        public DateTime Time { get; set; }
        public NotificationStatus NotificationStatus  { get; set; }
    }
}
