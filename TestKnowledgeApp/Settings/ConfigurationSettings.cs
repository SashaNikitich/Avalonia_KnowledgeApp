using TestKnowledgeApp.Interfaces;

namespace TestKnowledgeApp.Settings;

public class ConfigurationSettings : IConfigurationSettings
{
    public string AuthServiceBaseUrl { get; set; }
}