using System.Configuration;

namespace Common
{
    public static class Config
    {
        public static string SqlAdalClientId => ConfigurationManager.AppSettings["SqlAdal:ClientId"];

        public static int CommandTimeoutSec
        {
            get
            {
                var s = ConfigurationManager.AppSettings["DB:CommandTimeoutSec"];
                int timeout;
                if (!int.TryParse(s, out timeout))
                {
                    timeout = 30;
                }
                return timeout;
            }
        }

        public static string Environment
        {
            get { return ConfigurationManager.AppSettings["ENV"]; }
        }
    }
}