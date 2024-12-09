public class Task : Tasks
{
    public int Id { get; set; }
    public Task(int id, string title, string project, DateOnly dueDate, bool status) : base(title, project, dueDate, status)
    {
        Id = id;
    }
}
public class ManageTasks
{
    List<Task> tasks = new List<Task>();
    int nextId = 1;
    public void AddTasks()
    {
        while (true)
        {
            Console.Write("Enter the title of the task: ");
            string title = Console.ReadLine();

            DateTime dueTime;
            while (true)
            {
                Console.Write("Enter the due date of the task(MM-DD-YYYY): ");
                if (!DateTime.TryParse(Console.ReadLine(), out dueTime))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid due date format. Please enter a valid date");
                    Console.ResetColor();
                }
                else
                {
                    break;
                };
            }
            DateOnly dueDate = DateOnly.FromDateTime(dueTime);

            Console.Write("Please enter the project of the task: ");
            string project = Console.ReadLine();

            tasks.Add(new Task(nextId++, title, project, dueDate, false));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Task added successfully!");
            Console.ResetColor();

            Console.Write("Do you want to add another task? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "no")
            {
                break;
            }
        }
    }
    public void ShowTasks()
    {
        tasks.OrderBy(task => task.DueDate).ToList();
        Console.WriteLine("Task ID".PadRight(10) + "Title".PadRight(20) + "Project".PadRight(30) + "Due Date".PadRight(20) + "Status");
        foreach (var t in tasks)
        {
            Console.WriteLine(t.Title.PadRight(20) + t.Project.PadRight(20) + t.DueDate.ToString().PadRight(20) + t.Status);
        }
    }
    public void EditTasks()
    {
        Console.Write("Select a task ID to edit: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.Find(task => task.Id == taskId);
            Console.WriteLine("Enter 'title, project, due date or status' to edit: ");
            string editInput = Console.ReadLine().Trim().ToLower();
            if (editInput != "title" || editInput != "project" || editInput != "due date" || editInput != "status")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter title or project or due date or status");
                Console.ResetColor();
            }
        };

    }
    public int TotalTasks()
    {
        return 1;
    }
    public int CompletedTasks()
    {
        return 0;
    }
    public void SaveTasks()
    {

    }
}