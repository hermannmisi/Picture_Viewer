

namespace FileOperations
{
    public class UserSettings
    {

        public bool FlatButton { get; set; } = false;

        public bool BetaVersion { get; set; } = false;

        public bool ShowNews { get; set; } = true;

        public bool ReceiveNews { get; set; } = true;

        public int LastNewsCounter { get; set; } = 0;

        public string NewsCategories { get; set; } = "main,beta,news";

        public bool AutoUpdate { get; set; } = true;

        public string Email { get; set; } = string.Empty;
    }
}