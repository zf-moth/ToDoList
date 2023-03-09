namespace ToDoList
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? FinishedDate { get; set; }

        public TodoItem(int id, string title, DateTime createdDate)
        {
            Id = id;
            Title = title;
            CreatedDate = createdDate;
        }
    }
    public enum Priority { normal, low, high, urgent }
}
