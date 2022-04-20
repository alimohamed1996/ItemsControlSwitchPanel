using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ItemsControlSwitchPanel.ViewModels;
using ReactiveUI;
using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.Mixins;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;

namespace ItemsControlSwitchPanel.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private ItemsControl _itemsControl => this.FindControl<ItemsControl>("ItemsControlTest");
        private TextBlock _trackTextBlock => this.FindControl<TextBlock>("TrackTextBlock");
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                this.WhenAnyValue(x => x.ViewModel.ToggleItemsPanel)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(toggle =>
                    {
                        if (toggle)
                        {
                            var wrapPanel = _itemsControl.FindResource("WrapPanelTemplate") as ItemsPanelTemplate;
                            _itemsControl.ItemsPanel = wrapPanel;
                            // _itemsControl.SetValue(ItemsControl.ItemsPanelProperty, wrapPanel);
                            // _itemsControl.ItemsPanel = new FuncTemplate<IPanel>(() => wrapPanel.Build());
                        }
                        else
                        {
                            var stackPanel = _itemsControl.FindResource("StackPanelTemplate") as ItemsPanelTemplate;
                            _itemsControl.ItemsPanel = stackPanel;
                            // _itemsControl.SetValue(ItemsControl.ItemsPanelProperty, stackPanel);
                            // _itemsControl.ItemsPanel = new FuncTemplate<IPanel>(stackPanel.Build);
                            // _itemsControl.ItemsPanel = new FuncTemplate<IPanel>(() => stackPanel.Build());
                        }
                    }).DisposeWith(d);
                Observable.FromEventPattern<AvaloniaPropertyChangedEventArgs>(
                        h => _itemsControl.PropertyChanged += h,
                        h => _itemsControl.PropertyChanged -= h)
                    .Subscribe(x =>
                    {
                        if (x.EventArgs.Property.Name.Equals("ItemsPanel"))
                        {
                            Trace.WriteLine("Changed");
                        }
                    });
            });;
        }
    }
}