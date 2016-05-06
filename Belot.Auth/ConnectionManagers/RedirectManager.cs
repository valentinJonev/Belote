using System;
using Belot.Auth.Core.Config;

namespace Belot.Auth.ConnectionManagers
{
    public class RedirectManager
    {
        private int firstLocaleId;
        private int secondLocaleId;

        public RedirectManager(int firstLocaleId, int secondLocaleId)
        {
            this.firstLocaleId = firstLocaleId;
            this.secondLocaleId = secondLocaleId;
        }

        // ~~ Load balance ~~
        public string GetCommonUrl()
        {
            ApiInstanceCollection instances = ApiInstanceSettings.Settings.Instances;
            string serviceUrl = instances[0].Url;
            int minLocaleDifference = int.MaxValue;

            for (int idx = 0; idx < instances.Count; idx++)
            {
                if (minLocaleDifference > GetLocaleDifference(instances[idx].LocaleId))
                {
                    serviceUrl = instances[idx].Url;
                    minLocaleDifference = GetLocaleDifference(instances[idx].LocaleId);
                }
            }

            return serviceUrl;
        }

        private int GetLocaleDifference(int localeId)
        {
            int firstDist = Math.Abs(this.firstLocaleId - localeId);
            int secondDist = Math.Abs(this.secondLocaleId - localeId);

            return Math.Max(firstDist, secondDist);
        }
    }
}