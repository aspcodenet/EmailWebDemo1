namespace EmailWebDemo1.Services;

public interface IEmailSenderService
{
    void SendEmail(string fromName, string header, string message);
}