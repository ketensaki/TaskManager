namespace csharpik
{
    class TaskManager
    {
        private List<TaskItem>? tasks = new();

        public void AddTask(TaskItem task)
        {
            tasks?.Add(task);
        }

        public void CreateTask()
        {
            System.Console.WriteLine("Введите название задачи");
            string name = Console.ReadLine();

            try{
            System.Console.WriteLine("Введите приоритет задачи. (1-5)");
            int priority = Convert.ToInt32(System.Console.ReadLine());
            TaskItem tasks = new TaskItem(name, TaskStatus.New, priority);
            AddTask(tasks);
            }
            catch(ArgumentOutOfRangeException ex){System.Console.WriteLine(ex.Message);}
        }

        public List<TaskItem> ListTasks()
        {
            return tasks;
        }
        public void printList()
        {
            foreach (TaskItem el in tasks)
            {
                System.Console.WriteLine(el.ToString());
            }
        }
        
    }
}
