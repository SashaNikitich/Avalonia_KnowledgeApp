using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;

namespace TestKnowledgeApp.Models.UIModels;

public class LoginModel : ReactiveValidationObject
{
    public LoginModel()
    {
        this.ValidationRule(
            viewModel => viewModel.Login, 
            name => !string.IsNullOrWhiteSpace(name),
            "Login shouldn't be null or white space.");
        
        this.ValidationRule(
            viewModel => viewModel.Password, 
            name => !string.IsNullOrWhiteSpace(name),
            "Password shouldn't be null or white space.");
    }
    
    private string _login = string.Empty;
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }

    private string _password = string.Empty;
    public string Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }
}