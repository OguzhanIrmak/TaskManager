using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TaskTurner.Models;

namespace TaskTurner.ViewModels
{
    public class NewTaskViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private TaskImportance _selectedImportance;
        private DateTime? _dueDate;

        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(); }
        }

        public TaskImportance SelectedImportance
        {
            get => _selectedImportance;
            set { _selectedImportance = value; OnPropertyChanged(); }
        }

        public DateTime? DueDate
        {
            get => _dueDate;
            set { _dueDate = value; OnPropertyChanged(); }
        }

        public ObservableCollection<TaskImportance> Importances { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
