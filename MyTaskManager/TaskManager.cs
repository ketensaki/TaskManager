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
            try
            {

                System.Console.WriteLine("Введите приоритет задачи от 1 до 5");
                int propierty = Convert.ToInt32(Console.ReadLine());
                if (propierty < 1 || propierty > 5)
                {
                    throw new ArgumentOutOfRangeException(nameof(propierty), "Приоритет не верный!");
                }

                TaskItem tasks = new TaskItem(name, TaskStatus.New, propierty);
                AddTask(tasks);
            }
            catch (System.FormatException) { System.Console.WriteLine("Неверный формат ввода."); }
            catch (ArgumentOutOfRangeException ex) { System.Console.WriteLine(ex.Message); }
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
