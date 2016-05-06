using System.Configuration;

namespace Belot.Auth.Core.Config
{
    public class ApiInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("Id", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int Id
        {
            get
            {
                return (int)this["Id"];
            }
        }

        [ConfigurationProperty("LocaleId", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int LocaleId
        {
            get
            {
                return (int)this["LocaleId"];
            }
        }

        [ConfigurationProperty("Url", IsRequired = true)]
        public string Url
        {
            get
            {
                return this["Url"].ToString();
            }
        }
    }
}
