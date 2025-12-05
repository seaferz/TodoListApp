using System.Diagnostics.Metrics;
using TodoListApp;
using TodoListApp.Logic;
using TodoListApp.Models;

Console.WriteLine("Your Ultimate To-Do List!");

var todoManager = new TodoListManager();

RunInteractive(todoManager); // Запускаем основной интерактивный режии

Console.WriteLine("\nPress any key to exit…");
Console.ReadKey();

static void RunInteractive(TodoListManager manager)
{
    while (true)
    {
        manager.DisplayTodoList(); // Показышаем текущий список дел
        Console.WriteLine("\nAvailable commands: add, toggle, exit");
        Console.Write("Enter command: ");
        string command = Console.ReadLine()?.Trim().ToLower(); // Используеm ?. для null-conditional, если Console.ReadLine() вернет null
        bool operationSuccessful = false; // Флаг для индинации успеха операции

        switch (command)
        {
            case "add":
                Console.Write("Enter the description for the new task: ");
                string description = Console.ReadLine();
                operationSuccessful = manager.AddTask(description);
                break;
            case "toggle":
                Console.Write("Enter the ID of the task to toggle completion: ");
                string taskIdInput = Console.ReadLine();
                if (int.TryParse(taskIdInput, out int taskId))
                {
                    operationSuccessful = manager.ToggleleTaskComplection(taskId);
                }
                else
                {
                    Console.WriteLine("Error: Invalid ID format. Please enter a number.");
                    operationSuccessful = false; // Считаем операцию меуспешной
                }
                break;
            case "exit":
                return; // Выход из цикла RunInteractive, а затем и из программы
            default:
                Console.WriteLine("Error: Unknown command. Please try again.");
                operationSuccessful = false; // Неизвестная конанда - неуспех
                break;
        }
        if (operationSuccessful || command == "add" || command == "toggle" || command == "exit" || command == null)
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
    
