namespace csharpik
{
    class TaskMenu
    {
        public void TaskConsoleMenu(TaskManager taskManager, TaskItem task)
        {
            string[] menu = {
            "1 - Удалить задачу.",
            "2 - Изменить статус.",
            "0 - Основное меню.",
            };
            bool stop = false;
            while (!stop)
            {
                ConsoleHelper.PrintSuccess("\nMENU");
                System.Console.WriteLine(new string('-', 30));
                System.Console.WriteLine("Выберите действие: ");
                foreach (string line in menu)
                {
                    System.Console.WriteLine(line);
                }
                System.Console.WriteLine(new string('-', 30));
                string? a = Console.ReadLine();
                switch (a)
                {
                    case "0":
                        ConsoleHelper.PrintWarning("Возврат...");
                        stop = true;
                        break;

                    case "1":
                        taskManager.DeleteTask(task);
                        stop = true;
                        break;

                        case "2":
                        taskManager.ChangeStatus(task);
                        stop = true;
                        break;
                    
                    default:
                        ConsoleHelper.PrintError("Неверный пункт меню.");
                        Menu.BackToMenu();
                        break;

                }
                ;
                Console.Clear();
            }        
        }
    }
}