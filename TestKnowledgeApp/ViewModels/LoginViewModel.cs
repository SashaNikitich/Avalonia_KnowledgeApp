using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using TestKnowledgeApp.Interfaces;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.UIModels;
using TestKnowledgeApp.Validators;

namespace TestKnowledgeApp.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private readonly MainWindowViewModel _window;
    private LoginModel _loginModel;
    private string _loginMessage;
    
    private readonly LoginValidator _loginValidator;

    [Required]
    public LoginModel LoginModel
    {
        get => _loginModel;
        set => this.RaiseAndSetIfChanged(ref _loginModel, value);
    }

    public string LoginMessage
    {
        get => _loginMessage;
        set => this.RaiseAndSetIfChanged(ref _loginMessage, value);
    }

    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public LoginViewModel(MainWindowViewModel window, IAuthService authService)
    {
        _loginMessage = string.Empty;
        _window = window;
        _authService = authService;
        _loginModel = new LoginModel();
        _loginValidator = new LoginValidator();
        LoginCommand = ReactiveCommand.CreateFromTask(OnLoginAsync); 
    }
    
    public async Task OnLoginAsync()
    {
        try
        {
            var results = await _loginValidator.ValidateAsync(LoginModel);
            if (results.IsValid)
            {
                var request = new LoginRequest
                {
                    Login = LoginModel.Login,
                    Password = LoginModel.Password
                };
                
                // await _authService.LoginAsync(request);
            }
            else
            {
                LoginMessage = string.Join(Environment.NewLine, results.Errors.Select(e => e.ErrorMessage));
            }

            _window.ContentViewModel = new StudentViewModel();
        }
        catch (Exception e)
        {
            LoginMessage = e.Message;
        }
    }
    
    public void NavigateToRegisterPage()
    {
        _window.ContentViewModel = new RegisterViewModel(_authService);
    }
}
