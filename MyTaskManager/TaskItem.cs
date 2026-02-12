namespace csharpik
{
    enum TaskStatus
    {
        New,
        InProgress,
        Done,
        Cancelled
    }

    class TaskItem
    {
        private static int idCount = 0;
        private int id;
        public string? title { get; private set; }
        public TaskStatus status { get; private set; }
        private int priority;
        public DateTime createdAt { get; private set; }

        public TaskItem(string? title, TaskStatus status, int priority)
        {
            this.id = ++idCount;
            this.title = title;
            this.status = status;
            this.priority = priority;
            this.createdAt = DateTime.Now;
        }
        public string ToString()
        {
            return $"#{this.id} | {title} | {status} | Priority: {priority} | {createdAt}";
        }


    }
}