using System.Data.Common;
using System.Net;

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

        public void ChangeStatus(TaskItem task)
        {
            System.Console.WriteLine("Какой статус вы хотите установить?");
            string[] statuses = {"1 - New",
            "2 - InProgress",
            "3 - Done",
            "4 - Cancelled"};
            foreach (string el in statuses)
            {
                System.Console.WriteLine(el);
            }

            int NewStatus = Convert.ToInt32(Console.ReadLine());

            switch (NewStatus)
            {
                case 1:
                    task.Status = TaskStatus.New;
                    ConsoleHelper.PrintSuccess("Статус изменен.");
                    Menu.BackToMenu();
                    break;
                case 2:
                    task.Status = TaskStatus.InProgress;
                    ConsoleHelper.PrintSuccess("Статус изменен");
                    Menu.BackToMenu();
                    break;
                case 3:
                    task.Status = TaskStatus.Done;
                    ConsoleHelper.PrintSuccess("Статус изменен");
                    Menu.BackToMenu();
                    break;
                case 4:
                    task.Status = TaskStatus.Cancelled;
                    ConsoleHelper.PrintSuccess("Статус изменен");
                    Menu.BackToMenu();
                    break;

                default:
                    ConsoleHelper.PrintError("Ввод некоректный.");
                    Menu.BackToMenu();
                    break;

            }
        }

        public void ChangePriority(TaskItem task)
        {

            try
            {
                System.Console.WriteLine("Введите новый приоритет от 1 до 5");
                int newPriority = Convert.ToInt32(Console.ReadLine());

                if (newPriority < 1 || newPriority > 5)
                    throw new ArgumentOutOfRangeException();

                task.Priority = newPriority;
                ConsoleHelper.PrintSuccess("Приоритет изменен.");
                
            }
            catch (ArgumentOutOfRangeException){ConsoleHelper.PrintError("Не верный приоритет.");}
            catch (FormatException){ConsoleHelper.PrintError("Не верный формат ввода.");}

            Menu.BackToMenu();
        }

    }
}
