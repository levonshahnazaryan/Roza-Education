namespace Domain.Helpers
{
    public class AppSettings
    {
        public UserData UserData { get; set; }
        public EmailSettings EmailSettings { get; set; }
    }
    public class UserData
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool EnableSsl { get; set; }
        public string GetEmail { get; set; }
    }
}