using Amazon.SecretsManager;
using Amazon.SecretsManager.Extensions.Caching;
using Microsoft.Configuration.ConfigurationBuilders;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomConfigurationBuilders
{
    public class ConfigurationBuilderUsingSecretsManager : KeyValueConfigBuilder
    {
        private IAmazonSecretsManager secretsManager;
        private SecretsManagerCache cache;

        public ConfigurationBuilderUsingSecretsManager()
        {
            Debug.WriteLine("ConfigurationBuilderUsingSecretsManager has been instantiated");

            // I'm not passing anything into AmazonSecretsManagerClient with the intent
            // that it gets credentials and configuration using its own rules

            secretsManager = new AmazonSecretsManagerClient();
            cache = new SecretsManagerCache(secretsManager);
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);

            // We seem to end up in an infinite loop if we try to instantiate it
            // here instead, same already happens if we use the constructor or LazyInitialize() below

            // secretsManager = new AmazonSecretsManagerClient();
            // cache = new SecretsManagerCache(secretsManager);
        }

        protected override void LazyInitialize(string name, NameValueCollection config)
        {
            base.LazyInitialize(name, config);

            // We seem to end up in an infinite loop if we try to instantiate it
            // here instead, same already happens if we use the constructor or Initialize()

            // secretsManager = new AmazonSecretsManagerClient();
            // cache = new SecretsManagerCache(secretsManager);
        }

        public override ICollection<KeyValuePair<string, string>> GetAllValues(string prefix)
        {
            // Don't need to implement because we'll never get here (unless initialization is done in LazyInitialize)
            throw new NotImplementedException();
        }

        public override string GetValue(string key)
        {
            // Don't need to implement because we'll never get here (unless initialization is done in LazyInitialize)
            throw new NotImplementedException();
        }
    }
}
