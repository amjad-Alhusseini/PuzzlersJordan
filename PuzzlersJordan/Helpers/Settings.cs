using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using Xamarin.Forms;

namespace PuzzlersJordan.Helpers
{
    public sealed class Settings
    {
        private Settings() { }

        private static readonly Settings instance = new Settings();

        public static Settings Instance
        {
            get => instance;
        }

        public string ShopifyAccessToken
        {
            get => GetSettingValueFor(Constants.ShopifyAccessTokenConfigKey);
        }

        public string ShopifyStoreFrontUrl
        {
            get => GetSettingValueFor(Constants.ShopifyStoreFrontUrlConfigKey);
        }

        private string GetSettingValueFor(string key)
        {
            var type = this.GetType();
            var resource = "PuzzlersJordan.config.xml";
            using (var stream = type.GetTypeInfo().Assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                var doc = XDocument.Parse(reader.ReadToEnd());
                return doc.Element("config").Element(key).Value;
            }
        }
    }
}
