using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using TaskTurner.DataService;
using TaskTurner.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TaskTurner.ViewModels
{
    internal class TaskViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan Timer { get; set; }

        public TaskState TaskState { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public TaskImportance TaskImportance { get; set; }
        public ObservableCollection<TaskCheckList> TaskCheckList { get; set; }

        //Task Importance Properties
        public ObservableCollection<TaskImportance> Importances { get; set; }
        private TaskImportance _selectedImportance;
        public TaskImportance SelectedImportance
        {
            get => _selectedImportance;
            set
            {
                _selectedImportance = value;
                OnPropertyChanged(nameof(SelectedImportance));
            }
        }

        public ICommand IAddNewTask => new RelayCommand(AddNewTask);


        // This is used to interact with the underlying data storage.
        private readonly TaskDataService _taskDataService;

        //Private field holding the collection of task models.
        // ObservableCollection is used because it provides notifications when items get added removed or the entire list is refreshed.
        private ObservableCollection<Task> _tasks;

        //Event declaration for PropertyChanged.
        // This is used in the context of INotifyPropertyChanged to notify the UI when a property value changes
       


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
        public void AddNewTask()
        {

            Task newTask = new Task
            {
                Title = this.Title,
                Description = this.Description,
                Id=_taskDataService.GenereateNewTaskId(),
                IsCompleted = false,
                DueDate = this.DueDate,
                StartDate=DateTime.Now,
                TaskCategory=TaskCategory.Education,
                TaskCheckList=this.TaskCheckList,
                TaskImportance=this.SelectedImportance,
                TaskState=TaskState.Late,
                //Timer=new TimeSpan(0),
                Timer=this.Timer,

            };
            _taskDataService.AddTask(newTask);
           

            //Remove All Data From Fields
            ClearFields();
            LoadTasks();
        }

        private void ClearFields()
        {
            Title = "";
            Description = "";
            DueDate= DateTime.Now;
            TaskCheckList.Clear();
            SelectedImportance=Importances.FirstOrDefault();

            UpdateForm();
           
        }
        private void UpdateForm()
        {
            OnPropertyChanged(Title);
            OnPropertyChanged(Description);
            OnPropertyChanged(nameof(DueDate));
            OnPropertyChanged(nameof(TaskCheckList));
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
            TaskCheckList = new ObservableCollection<TaskCheckList>();
            Importances = new ObservableCollection<TaskImportance>(Enum.GetValues(typeof(TaskImportance)).Cast<TaskImportance>());
            DueDate= DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    
    
}
