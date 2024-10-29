using LoginModule.Domain.Notifications;

namespace LoginModule.Domain.Interfaces
{
	public interface INotifier
	{
		bool HaveNotification();
		List<Notification> GetNotifications();
		void Handle(Notification notification);
	}
}
