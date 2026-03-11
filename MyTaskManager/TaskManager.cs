using System.Data.Common;

namespace csharpik
{
    class TaskManager
    {
        private List<TaskItem> tasks = new();

        public void AddTask(TaskItem task)
        {
            tasks.Add(task);
        }

        public void CreateTask()
        {


            try
            {
                ConsoleHelper.PrintWarning("\n0 - возврат в меню.\n");
                System.Console.WriteLine("Введите название задачи");
                string? name = Console.ReadLine();

                if (name == "0")
                {
                    ConsoleHelper.PrintWarning("Возврат...");
                    return;
                }

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentNullException();

                System.Console.WriteLine("Введите приоритет задачи. (1-5)");
                int priority = Convert.ToInt32(System.Console.ReadLine());

                if (priority == 0)
                {
                    ConsoleHelper.PrintWarning("Возврат...");
                    return;
                }

                TaskItem task = new TaskItem(name, TaskStatus.New, priority);
                AddTask(task);

                ConsoleHelper.PrintSuccess("Задача создана.");
            }

            catch (ArgumentNullException) { ConsoleHelper.PrintError("Вы не ввели имя!"); }
            catch (ArgumentOutOfRangeException) { ConsoleHelper.PrintError("Приоритет должен быть от 1 до 5."); }
            catch (System.FormatException) { ConsoleHelper.PrintError("Не верный формат ввода."); }

            Menu.BackToMenu();
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
            Menu.BackToMenu();
        }


        public TaskItem? FindTask()
        {
            int id = 0;
            TaskItem? task = null;
            try
            {
                System.Console.WriteLine("Введите номер задачи задачи котрую хотите выбрать.");
                id = Convert.ToInt32(Console.ReadLine());
                task = tasks.FirstOrDefault(t => t.Id == id);

                if (task == null)
                {
                    throw new ArgumentOutOfRangeException();
                }

                ConsoleHelper.PrintSuccess($"#{task.Id} | {task.title} | {task.status} | Priority: {task.Priority} | {task.createdAt}");

            }
            catch (ArgumentOutOfRangeException) { ConsoleHelper.PrintError($"Задачи №{id} нету."); }
            catch (FormatException) { ConsoleHelper.PrintError("Не верный формат ввода."); }
            return task;
        }

        public void DeleteTask(TaskItem task)
        {

            ConsoleHelper.PrintWarning("Вы уверены что хотите удалить эту задачу?");
            System.Console.Write("[y/n]");
            string verification = Console.ReadLine()!;
            verification = verification.ToLower();
            if (verification == "y" || verification == "д")
            {
                tasks.Remove(task);
                ConsoleHelper.PrintSuccess("Задача удалена.");
                Menu.BackToMenu();
            }
            else if (verification == "n" || verification == "н")
            {
                Menu.BackToMenu();
            }
            else
            {
                ConsoleHelper.PrintError("Не верный формат ввода.");
                Menu.BackToMenu();
            }

        }

    }
}
