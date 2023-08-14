
namespace EventBooking.Domain.Interfaces
{
    public interface IEmailSenderNotification
    {
        Task EmailSender(string ToEmail, string Subject, string Body);
    }
}