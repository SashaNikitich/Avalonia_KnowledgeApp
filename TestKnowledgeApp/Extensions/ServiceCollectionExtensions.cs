using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestKnowledgeApp.Interfaces;
using TestKnowledgeApp.Services;
using TestKnowledgeApp.Settings;
using TestKnowledgeApp.ViewModels;

namespace TestKnowledgeApp.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        var settings = config.GetRequiredSection("ConfigurationSettings").Get<ConfigurationSettings>();
        collection.AddSingleton<IConfigurationSettings, ConfigurationSettings>(_ => settings?? throw new InvalidOperationException());
        
        collection.AddTransient<IAuthService, AuthService>();
        collection.AddTransient<RegisterViewModel>();
        collection.AddTransient<MainWindowViewModel>();
        collection.AddTransient<StudentViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<LoginViewModel>();
        collection.AddTransient<TestViewModel>();
    }
}
