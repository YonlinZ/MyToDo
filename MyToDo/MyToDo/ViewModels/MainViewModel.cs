﻿using MyToDo.Common.Models;
using Prism.Mvvm;
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
        public MainViewModel()
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
        }

        

        private ObservableCollection<MenuBar> menuBars;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }
        private void CreateMenuBar()
        {
            menuBars.Add(new MenuBar {Icon ="Home", Title ="首页",   NameSpace="IndexView" });
            menuBars.Add(new MenuBar {Icon ="NotebookOutline", Title ="待办事项",   NameSpace="ToDoView" });
            menuBars.Add(new MenuBar {Icon ="NotebookPlus", Title ="备忘录",   NameSpace="MemoView" });
            menuBars.Add(new MenuBar {Icon ="Cog", Title ="设置",   NameSpace="SettingsView" });
        }

    }
}