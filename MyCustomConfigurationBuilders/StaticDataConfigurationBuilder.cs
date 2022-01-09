using Microsoft.Configuration.ConfigurationBuilders;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCustomConfigurationBuilders
{
    public class StaticDataConfigurationBuilder : KeyValueConfigBuilder
    {
        public override ICollection<KeyValuePair<string, string>> GetAllValues(string prefix)
        {
            return GetAllSettings().Where(ev => ev.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public override string GetValue(string key)
        {
            string value;
            return GetAllSettings().TryGetValue(key, out value) ? value : null;
        }

        private Dictionary<string, string> GetAllSettings()
        {
            return new Dictionary<string, string>
            {
                { "AppSettings_MyCustomSetting", "This data has been set using a custom configuration builder" }
            };
        }
    }
}
