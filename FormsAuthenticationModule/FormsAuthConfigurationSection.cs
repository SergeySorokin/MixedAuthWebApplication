using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Mvolo.Modules
{
    public class FormsAuthConfigurationSection : ConfigurationSection
    {
        public const String ConfigurationSectionName = "formsAuthenticationWrapper";

        private static ConfigurationPropertyCollection _properties;

        private static readonly ConfigurationProperty _propEnabled =
            new ConfigurationProperty(
            "enabled",
            typeof(bool),
            true);

        private static readonly ConfigurationProperty _propUseIISUser =
            new ConfigurationProperty(
            "useIISUser",
            typeof(bool),
            true);

        static FormsAuthConfigurationSection() 
        {
            _properties = new ConfigurationPropertyCollection();

            _properties.Add(_propEnabled);
            _properties.Add(_propUseIISUser);
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _properties;
            }
        }

        [ConfigurationProperty("enabled", DefaultValue = true)]
        public bool Enabled
        {
            get
            {
                return (bool)base[_propEnabled];
            }
            set
            {
                base[_propEnabled] = value;
            }
        }

        [ConfigurationProperty("useIISUser", DefaultValue = true)]
        public bool UseIISUser
        {
            get
            {
                return (bool)base[_propUseIISUser];
            }
            set
            {
                base[_propUseIISUser] = value;
            }
        }

    }
}
