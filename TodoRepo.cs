namespace ToDoList
{
    public class TodoRepo
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();

        public void AddNew(TodoItem item)
        {
            item.CreatedDate = DateTime.Now;
            item.Id = GetMaxId() + 1;   
            Items.Add(item);
        }

        public void Seed(int count)
        {
            Items.AddRange(Enumerable.Range(GetMaxId() + 1, count).Select(i =>
            new TodoItem(i, $"Title {i}",DateTime.Now)
            {
                Description = $"Description #{i}",
                Priority = (Priority)(i % 4),
                DeadlineDate = DateTime.Today.AddDays(i)
            }));
        }

        private int GetMaxId()
        {
            return Items.Any() ? Items.Max(x => x.Id) : 0;
        }
    }
}
