using MaterialDesignThemes.Wpf;
using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            this._regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(m =>
            {
                if (m == null || string.IsNullOrWhiteSpace(m.NameSpace)) return;
                _regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(m.NameSpace, back =>
                {
                    _journal = back.Context.NavigationService.Journal;

                });
                
            });
            GoBackCommand = new DelegateCommand(() =>
            {
                if (_journal != null && _journal.CanGoBack)
                {
                    _journal.GoBack();
                }
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (_journal != null && _journal.CanGoForward)
                {
                    _journal.GoForward();
                }
            });

        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForwardCommand { get; set; }

        private ObservableCollection<MenuBar> _menuBars;
        private readonly IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _menuBars; }
            set { _menuBars = value; RaisePropertyChanged(); }
        }
        private void CreateMenuBar()
        {
            _menuBars.Add(new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            _menuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            _menuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            _menuBars.Add(new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingsView" });
        }

    }
}
