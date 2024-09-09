using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskTurner.ViewModels
{
    public class TaskListItemViewModel
    {
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Importance { get; set; }
        public string DueDate { get; set; }

        public TaskListItemViewModel(Models.Task task)
        {
            Title = task.Title;
            Description = task.Description;
            Importance = task.TaskImportance.ToString();
           // DueDate = task.DueDate;
        }
    }

    
}
