using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using ReactiveUI;

namespace ItemsControlSwitchPanel.ViewModels
{
    public class MainWindowViewModel : ViewModelBase ,IActivatableViewModel
    {
        private bool _toggleItemsPanel;
        public bool ToggleItemsPanel
        {
            get => _toggleItemsPanel;
            set => this.RaiseAndSetIfChanged(ref _toggleItemsPanel, value);
        }

        public ObservableCollection<string> StringCollection { get; set; }
        public MainWindowViewModel()
        {
            _toggleItemsPanel = true;
            StringCollection = new ObservableCollection<string>()
            {
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2",
                "Test1",
                "Test2"
            };
        }

        public ViewModelActivator Activator { get; } = new();
    }
}