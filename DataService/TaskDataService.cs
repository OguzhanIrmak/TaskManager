using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using TaskTurner.Models;

namespace TaskTurner.DataService
{
    public class TaskDataService
    {
        private readonly string _filePath;
        private readonly string folderName = "TaskTurner";
        private readonly string fileName = "tasks.json";

        public TaskDataService()
        {
            // get the path to the app data
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //get the folder of the application in roaming
            string appFolder = Path.Combine(appDataPath, folderName);
            // Get the data folder inside the app
            string dataFolder = Path.Combine(appFolder, "data");

            // Check if the data folder exists.
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Define the path to the json file.
            _filePath = Path.Combine(dataFolder, fileName);

            //Ensure the json file exists.
            InitializeFile();
        }
        private void InitializeFile()
        {
            // Check if the file exists
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, JsonConvert.SerializeObject(new List<Task>()));
            }

            //For Debug purposes
            Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),folderName));
        }

        public List<Task> LoadTasks()
        {
            // Read and serialize the Json file.
            string fileContent=File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Task>>(fileContent);
        }
        public void SaveTasks(List<Task> tasks)
        {
            string json=JsonConvert.SerializeObject(tasks, Formatting.Indented); 
            File.WriteAllText(_filePath, json);

        }

        public void AddTask(Task newTask)
        {
            // Generating a new ıd number
            newTask.Id=GenereateNewTaskId();
            // Loading the task from the json file.
            var task = LoadTasks();
            // Adding the new task to the returned string (json string)
            task.Add(newTask);
            //Saving the new json string
            SaveTasks(task);

        }

        public void UpdateTask(Task updateTask)
        {  
            //Loading the tasks from the json file.
            var tasks = LoadTasks();
            //Checking for the id that matches the updateTask id
            var taskIndex=tasks.FindIndex(task=> task.Id==updateTask.Id);

            if (taskIndex != -1)
            {
                tasks[taskIndex]=updateTask;
                SaveTasks(tasks);
            }
        }
        

        public void DeleteTasks(int taskId)
        {
            // Loading the json string
            var tasks=LoadTasks();
            //Checking through for the matching ID,then removing it.
            tasks.RemoveAll(task => task.Id==taskId);
            //Saving the file.
            SaveTasks(tasks);
        }


        // Generate a new task ıd by getting the max ID and adding 1 to it.
        public int GenereateNewTaskId()
        {
            var tasks = LoadTasks();

            if (!tasks.Any())
            {
                return 1;
            }
            int maxId = tasks.Max(task => task.Id);
            return maxId + 1;
        }

    }
}
