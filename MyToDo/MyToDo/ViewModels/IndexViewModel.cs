using MyToDo.Common.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class IndexViewModel : BindableBase
    {
        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            CreateTaskBars();
            CreatDefaultTestData();
        }

        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }
        void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar { Icon = "ClockFast", Content = "9", Title = "汇总", Target = "", Color = "#1abc9c" });
            TaskBars.Add(new TaskBar { Icon = "ClockCheckOutLine", Content = "10", Title = "已完成", Target = "", Color = "#2ecc71" });
            TaskBars.Add(new TaskBar { Icon = "ChartLineVariant", Content = "15", Title = "完成率", Target = "", Color = "#3498db" });
            TaskBars.Add(new TaskBar { Icon = "PlayListStar", Content = "78", Title = "备忘录", Target = "", Color = "#9b59b6" });
        }

        void CreatDefaultTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                toDoDtos.Add(new ToDoDto() { Content = "正在处理。。。", Title = "ToDo" + i });
                MemoDtos.Add(new MemoDto() { Content = "正在处理、、、", Title = "Memo" + i });
            }
        }
    }
}
