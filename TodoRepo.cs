namespace ToDoList
{
    public class TodoRepo
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();

        public void Seed(int count)
        {
            Items.AddRange(Enumerable.Range(0, count).Select(i =>
            new TodoItem(i, $"Title {i}",DateTime.Now)
            {
                Description = $"Description #{i}",
                Priority = (Priority)(i % 4),
                DeadlineDate = DateTime.Today.AddDays(i)
            }));
        }
    }
}
