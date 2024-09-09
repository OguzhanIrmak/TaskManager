using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaskTurner.ViewModels;
using TaskTurner.Models;

namespace TaskTurner.Views
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
       

        public NewTaskWindow()
        {
            InitializeComponent();

            DataContext = new TaskViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as TaskViewModel;

            if (viewModel != null)
            {
                var newTask = new Models.Task
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    TaskImportance = viewModel.SelectedImportance,
                    DueDate = viewModel.DueDate 
                };

                var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               // var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    mainWindow.AddTaskToList(newTask);
                }

                this.Close();
            }
        }

    }
}
