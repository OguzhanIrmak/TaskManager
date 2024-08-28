using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TaskTurner.DataService;
using TaskTurner.Models;

namespace TaskTurner.ViewModels
{
    internal class TaskViewModel : INotifyPropertyChanged
    {
        // This is used to interact with the underlying data storage.
        private readonly TaskDataService _taskDataService;

        //Private field holding the collection of task models.
        // ObservableCollection is used because it provides notifications when items get added removed or the entire list is refreshed.
        private ObservableCollection<Task> _tasks;

        //Event declaration for PropertyChanged.
        // This is used in the context of INotifyPropertyChanged to notify the UI when a property value changes
        public event PropertyChangedEventHandler PropertyChanged;


        // Public property for tasks.
        //Provides access to the _tasks field and notifies the UI when the collections changes
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));   
            }
        }

        //Load Task : This method loads the list of task from the TaskDataService and updates the task collection.
        // The task collection is bound to the view, so updating this collection will update the UI accordingly.
        private void LoadTasks()
        {
            var TaskList=_taskDataService.LoadTasks();
            Tasks = new ObservableCollection<Task>(TaskList);
        }
        //Responsible for adding a new task.
        public void AddNeewTask(Task newtask)
        {
            _taskDataService.AddTask(newtask);
            LoadTasks();
        }

        public void UpdateTask(Task updateTask)
        {
            _taskDataService.UpdateTask(updateTask);
            LoadTasks();
        }
        public void DeleteTask(int taskId)
        {
            _taskDataService.DeleteTasks(taskId);
            LoadTasks();
        }

        //Constructor for the TaskViewModel.
        //Initializes the TaskDataService and load tasks.
        public TaskViewModel()
        {
           _taskDataService = new TaskDataService(); // initializing the TaskDataService.
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
