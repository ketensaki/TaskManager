using System.Data.Common;

namespace csharpik
{
    class TaskManager
    {
        private List<TaskItem> tasks = new();

        public void AddTask(TaskItem task)
        {
            tasks?.Add(task);
        }

        public void CreateTask()
        {


            try
            {
                System.Console.WriteLine("Введите название задачи");
                string? name = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException();
                System.Console.WriteLine("Введите приоритет задачи. (1-5)");
                int priority = Convert.ToInt32(System.Console.ReadLine());
                TaskItem tasks = new TaskItem(name, TaskStatus.New, priority);
                AddTask(tasks);
            }
            catch (ArgumentNullException) {ConsoleHelper.PrintError("Вы не ввели имя!");}
            catch(ArgumentOutOfRangeException){ConsoleHelper.PrintError("Приоритет должен быть от 1 до 5.");}
            catch (System.FormatException) {ConsoleHelper.PrintError("Не верный формат ввода.");}
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


        public void FindTask()
        {
            int id = 0;
            try{
            System.Console.WriteLine("Введите номер задачи задачи котрую хотите найти.");
            id = Convert.ToInt32(Console.ReadLine());
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if(task == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            System.Console.WriteLine(task);
            } 
            catch(ArgumentOutOfRangeException){ConsoleHelper.PrintError($"Задачи №{id} нету.");}
            catch (FormatException) {ConsoleHelper.PrintError("Не верный формат ввода.");}
        }

    }
}
