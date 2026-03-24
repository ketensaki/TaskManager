namespace csharpik
{
    class Menu
    {
        // private TaskManager? taskManager;
        public void ConsoleMenu(TaskManager taskManager, TaskMenu tmenu)
        {
        
            string[] menu = {

            "1 - Создать задачу.",
            "2 - Просмотр списка задач.",
            "3 - Выбрать задачу.",
            "4 - Незавершенные задачи.",
            "5 - Приоритетные задачи.",
            "0 - Выход.",
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
                        ConsoleHelper.PrintWarning("Выход...");
                        stop = true;
                        break;

                    case "1":
                        taskManager.CreateTask();
                        break;

                    case "2":
                        taskManager.printList();
                        break;

                    case "3":
                        var task = taskManager.FindTask();
                        if(task != null)
                        {
                            tmenu.TaskConsoleMenu(taskManager, task);
                        }
                        break;

                    case "4":
                        taskManager.FilterByStatus();
                        break;
                        
                    case "5":
                        taskManager.FilterByHighPriority();
                        break;
                    
                    default:
                        ConsoleHelper.PrintError("Неверный пункт меню.");
                        BackToMenu();
                        break;

                }
                ;
                Console.Clear();
            }
        }

        public static void BackToMenu()
        {
            ConsoleHelper.PrintWarning("Нажмиите ENTER для возврата в меню.");
            System.Console.ReadLine();
        }

    }
}
