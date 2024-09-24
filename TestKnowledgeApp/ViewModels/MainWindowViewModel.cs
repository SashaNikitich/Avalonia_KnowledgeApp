using ReactiveUI;
using TestKnowledgeApp.Interfaces;

namespace TestKnowledgeApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _contentViewModel;
    private readonly IAuthService _authService;
    
    public MainWindowViewModel(IAuthService authService)
    {
        _authService = authService;
        ContentViewModel = new LoginViewModel(this, authService);
    }

    public ViewModelBase ContentViewModel
    {
        get => _contentViewModel;
        set => this.RaiseAndSetIfChanged(ref _contentViewModel, value);
    }
}