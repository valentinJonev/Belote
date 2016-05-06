using System;
using System.Configuration;

namespace Belot.Auth.Core.Config
{
    [ConfigurationCollection(typeof(ApiInstanceElement))]
    public class ApiInstanceCollection : ConfigurationElementCollection
    {

        internal const string PropertyName = "Instance";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName,
              StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool IsReadOnly()
        {
            return false;
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ApiInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApiInstanceElement)(element)).Id;
        }

        public ApiInstanceElement this[int idx]
        {
            get { return (ApiInstanceElement)BaseGet(idx); }
        }
    }
}
