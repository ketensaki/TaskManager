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
        public int Id { get; private set; }
        public string? title { get; private set; }
        public TaskStatus status { get; private set; }
        public TaskStatus Status{get{return status;} set{status = value;}}
        private int? priority;
        public int? Priority { get { return priority; } set { priority = value; } }
        public DateTime createdAt { get; private set; }

        public TaskItem(string? title, TaskStatus status, int Priority)
        {
            this.title = title;
            this.status = status;
            SetPriority(Priority);
            this.Id = ++idCount;
            this.createdAt = DateTime.Now;
        }
        public override string ToString()
        {
            return $"#{this.Id} | {title} | {status} | Priority: {Priority} | {createdAt}";
        }

        public void SetPriority(int p)
        {

            if (p < 1 || p > 5)
                throw new ArgumentOutOfRangeException();
            Priority = p;

        }

    }
}