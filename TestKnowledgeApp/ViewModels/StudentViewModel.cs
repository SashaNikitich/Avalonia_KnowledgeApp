using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.Selection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
using ReactiveUI;
using TestKnowledgeApp.Models;

namespace TestKnowledgeApp.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    private bool _isPaneOpen;
    private ViewModelBase _currentViewModel;
    private ListItemTemplate _selectedListItem;
    
    public bool IsPaneOpen
    {
        get => _isPaneOpen;
        set => this.RaiseAndSetIfChanged(ref _isPaneOpen, value);
    }
    
    public ViewModelBase CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public ListItemTemplate SelectedListItem
    {
        get => _selectedListItem;
        set => this.RaiseAndSetIfChanged(ref _selectedListItem, value);
    }
    
    public SelectionModel<ListItemTemplate> Selection { get; }

    public ObservableCollection<ListItemTemplate> Items { get; }
    
    public void TriggerPane()
    {
        IsPaneOpen = !IsPaneOpen;
    }
    
    private void SelectionChanged(object? sender, SelectionModelSelectionChangedEventArgs e)
    {
        if (sender is null) return;

        var value = ((SelectionModel<ListItemTemplate>)sender).SelectedItem;

        var vm = Design.IsDesignMode
            ? Activator.CreateInstance(value.ModelType)
            : Ioc.Default.GetService(value.ModelType);

        if (vm is not ViewModelBase vmb) return;

        CurrentViewModel = vmb;
    }

    public StudentViewModel()
    {
        Items =
        [
            new ListItemTemplate(typeof(HomeViewModel), "HomeRegular", "Home"),
            new ListItemTemplate(typeof(TestViewModel), "TestCallRegular", "Tests"),
            new ListItemTemplate(typeof(HomeViewModel), "HomeRegular", "Home3")
        ];
        CurrentViewModel = new HomeViewModel();
        SelectedListItem = Items.First(vm => vm.ModelType == typeof(HomeViewModel));
        Selection = new SelectionModel<ListItemTemplate>();
        Selection.SelectionChanged += SelectionChanged;
    }
}
