using System;
using System.Reactive.Disposables;
using Avalonia;
using Avalonia.Data;
using Avalonia.ReactiveUI;
using ReactiveUI;
using TestKnowledgeApp.ViewModels;

namespace TestKnowledgeApp.Views;

public partial class LoginView : ReactiveUserControl<LoginViewModel>
{
    public LoginView()
    {
        InitializeComponent();
    }
}
