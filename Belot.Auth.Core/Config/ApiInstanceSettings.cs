using System.Configuration;

namespace Belot.Auth.Core.Config
{
    public class ApiInstanceSettings : ConfigurationSection
    {
        private static ApiInstanceSettings settings = ConfigurationManager.GetSection("ApiInstanceSettings") as ApiInstanceSettings;

        public static ApiInstanceSettings Settings
        {
            get
            {
                return settings;
            }
        }

        [ConfigurationProperty("Instances", IsRequired = true)]
        public ApiInstanceCollection Instances
        {
            get { return (ApiInstanceCollection)this["Instances"]; }
        }
    }
}
