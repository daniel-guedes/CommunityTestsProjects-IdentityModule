﻿using LoginModule.Domain.Interfaces;

namespace LoginModule.Domain.Notifications
{
	public class Notifier : INotifier
	{
		private List<Notification> _notifications;

        public Notifier()
        {
			_notifications = new List<Notification>();
        }

        public List<Notification> GetNotifications()
		{
			return _notifications;
		}

		public void Handle(Notification notification)
		{
			_notifications.Add(notification);
		}

		public bool HaveNotification()
		{
			return _notifications.Any();

		}
	}
}
