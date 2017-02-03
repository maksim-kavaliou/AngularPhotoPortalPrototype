using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.Infrastructure.Common
{
    public class CommonConfigurationManager : IConfigurationManager
    {
        public string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }
    }
}
