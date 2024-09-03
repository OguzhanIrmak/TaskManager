using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskTurner.Views;

namespace TaskTurner.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);
        private void OpenNewWindow()
        {
           NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Show();
        }

        public ICommand IAddNewTask {  get; set; }

        private ObservableCollection<TaskListItemViewModel> TaskList {  get; set; }
        

        public MainWindowViewModel()
        {
            TaskList = new ObservableCollection<TaskListItemViewModel>();
            IAddNewTask = new RelayCommand(AddNewTask);
        }
        private void AddNewTask()
        {
            
        }


        protected virtual void OnPrppertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
