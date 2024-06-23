namespace BlazorToDoTasks.Client.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string  Title{ get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Done{ get; set; }
    }
}
