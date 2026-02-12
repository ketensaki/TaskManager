namespace csharpik
{
    class Menu
    {

        public void Print(string value)
        {
            System.Console.WriteLine(value);
        }

        
        public void ConsoleMenu()
        {
            //TODO: 3 - Фильтр задач по статусу.
            //TODO 4 - Фильтр по приоритету.
            //TODO 5 - Статистика.
            //TODO 6 - Удалить задачу.


            string menu = @"1 - Создать задачу.
            2 - Просмотр списка задач.
            0 - Выход.
            ";
            bool stop = false;
            TaskManager taskManager = new TaskManager();
            while (!stop)
            {
                Print("Выберите действие: ");
                Print(menu);
                string? a = Console.ReadLine();
                switch (a)
                {
                     case "0":
                        stop = true;
                        break;

                    case "1":
                        
                        taskManager.CreateTask();
                        break;

                    case "2":

                        taskManager.printList();
                        break;
                }; 

            

        }
    }
}
}