using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;

namespace UreticiTakip_Web.Classes
{
    public static class AppConfigurationManager
    {
        public static string ClientSecret
        {
            get
            {
                return Setting<string>("ClientSecret");
            }
        }

        private static T Setting<T>(string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }

        private static bool Setting(string name)
        {
            //bool value = ConfigurationManager.AppSettings[name] as bool;

            //if (value == null)
            //{
            //    throw new Exception(String.Format("Could not find setting '{0}',", name));
            //}

            return true;
        }
    }
}