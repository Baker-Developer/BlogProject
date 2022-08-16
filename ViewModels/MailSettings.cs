namespace BlogProject.ViewModels
{
    public class MailSettings
    {
        // Configure And Use A STMP Server 
        // From Google For Example
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
