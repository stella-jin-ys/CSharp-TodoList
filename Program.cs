using System.Net;

public class Program
{
    public static void Main()
    {
        ManageTasks manageTasks = new ManageTasks();
        bool isRunning = true;

        while (isRunning)
        {
            int totalTasks = manageTasks.TotalTasks();
            int completedTasks = manageTasks.CompletedTasks();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Welcome to ToDo List!");
            Console.WriteLine($"You have {totalTasks} tasks and {completedTasks} tasks are done!");
            Console.WriteLine("Pick an options: ");
            Console.WriteLine("(1) Show Task List (by date or project)");
            Console.WriteLine("(2) Add New Task");
            Console.WriteLine("(3) Edit Task (update, mark as done, remove)");
            Console.WriteLine("(4) Save and Quit");
            Console.ResetColor();

            Console.Write("Enter your option: ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    manageTasks.ShowTasks();
                    break;
                case "2":
                    manageTasks.AddTasks();
                    break;
                case "3":
                    manageTasks.EditTasks();
                    break;
                case "4":
                    manageTasks.SaveTasks();
                    isRunning = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong option. Please select correct option!");
                    Console.ResetColor();
                    break;

            }
        }
    }
}