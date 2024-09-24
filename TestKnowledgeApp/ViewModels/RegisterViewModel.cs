using System;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using TestKnowledgeApp.Interfaces;
using TestKnowledgeApp.Models.Requests;
using TestKnowledgeApp.Models.UIModels;
using TestKnowledgeApp.Validators;

namespace TestKnowledgeApp.ViewModels;

public class RegisterViewModel : ViewModelBase
{
    private readonly IAuthService _authService;
    private RegisterModel _registerModel;
    private string _loginMessage;
    
    private readonly RegisterValidator _registerValidator;

    public RegisterModel RegisterModel
    {
        get => _registerModel;
        set => this.RaiseAndSetIfChanged(ref _registerModel, value);
    }

    public string RegisterMessage
    {
        get => _loginMessage;
        set => this.RaiseAndSetIfChanged(ref _loginMessage, value);
    }

    public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

    public RegisterViewModel(IAuthService authService)
    {
        _authService = authService;
        _registerModel = new RegisterModel();
        _registerValidator = new RegisterValidator();
        RegisterCommand = ReactiveCommand.CreateFromTask(OnRegisterAsync); 
    }

    public async Task OnRegisterAsync()
    {
        try
        {
            var results = await _registerValidator.ValidateAsync(RegisterModel);
            if (results.IsValid)
            {
                var request = new RegisterRequest
                {
                    Login = RegisterModel.Login,
                    Password = RegisterModel.Password
                };
                
                await _authService.RegisterAsync(request);
            }
            else
            {
                RegisterMessage = string.Join(Environment.NewLine, results.Errors.Select(e => e.ErrorMessage));
            }
        }
        catch (Exception e)
        {
            RegisterMessage = e.Message;
        }
    }
}