using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTurner.Models
{
    public class Task
    {
        public int Id { get; set; }
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
    }
    public enum TaskState
    {
        /// <summary>
        /// The Task is still in progress.
        /// </summary>
        InProgress,
        /// <summary>
        /// The Task has been marked as completed.
        /// </summary>
        Completed,
        /// <summary>
        /// The Task hasn't been started yet.
        /// </summary>
        NotStarted,
        /// <summary>
        /// The Task is Late.
        /// </summary>
        Late,
        /// <summary>
        /// The Task has been archived.
        /// </summary>
        Archived,
        /// <summary>
        /// The Task has been marked as deleted.
        /// </summary>
        Deleted
    }
    public enum TaskCategory
    {
        /// <summary>
        /// Tasks related to your job,like meeting,project deadlines or professional development activities.
        /// </summary>
        Work,
        /// <summary>
        /// Daily routines, hobbies, or personal goals.
        /// </summary>
        Personal,
        /// <summary>
        /// Household chores, repairs, or home improvement projects.
        /// </summary>
        Home,
        /// <summary>
        /// Exercise routines, meal planning, doctor's appointments, or meditation.
        /// </summary>
        HealthWelbeing,
        /// <summary>
        /// Budgeting, bill payments, and financial planning.
        /// </summary>
        Finance,
        /// <summary>
        /// Grocery lists, clothing, or other shopping needs.
        /// </summary>
        Shopping,
        /// <summary>
        /// Family gatherings, social events, or activities with friends.
        /// </summary>
        SocailFamily,
        /// <summary>
        /// Study sessions, assignments, or educational goals.
        /// </summary>
        Education,
        /// <summary>
        /// Study sessions, assignments, or educational goals.
        /// </summary>
        Travel,
        /// <summary>
        /// Planning for trips, packing lists, or travel itineraries.
        /// </summary>
        Errands,
        /// <summary>
        /// Time set aside for hobbies or leisure activities.
        /// </summary>
        HobbiesLeisure,
        /// <summary>
        /// Community service or volunteering activities.
        /// </summary>
        VolunteeringCommunity,
        /// <summary>
        /// Special dates and celebrations.
        /// </summary>
        BirthdayAnniversaries,
        /// <summary>
        /// Larger tasks that might span over multiple days or weeks.
        /// </summary>
        Projects,
        /// <summary>
        /// Objectives or goals that you're working towards over a longer period.
        /// </summary>
        LongTermGoals
    }
    public enum TaskImportance
    {
        /// <summary>
        /// Low importance. Suitable for task that are not urgent and can be deffered.
        /// </summary>
        Low,
        /// <summary>
        /// Medium importance. For tasks that are of regular priority.
        /// </summary>
        Medium,
        /// <summary>
        /// High importance. Tasks that need to be completed soon but are not critical.
        /// </summary>
        High,
        /// <summary>
        /// Critical importance. These tasks have the highest priority and often have tight deadlines or significant consequences if not completed in time.
        /// </summary>
        Critical
    }
}
