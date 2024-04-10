namespace Lab2_PWA_Juegos.Services_Email
{
    public interface IEmailService
    {
        void SendEmail(string emailTo, string recepientName, string subject, string body);
    }
}
