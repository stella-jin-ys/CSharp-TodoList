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
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;
    public void AddTasks()
    {
        while (true)
        {
            Console.Write("Enter the title of the task: ");
            string title = Console.ReadLine();

            Console.Write("Enter the project of the task: ");
            string project = Console.ReadLine();

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

            tasks.Add(new Task(nextId, title, project, dueDate, false));
            nextId++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Task{nextId} added successfully!");
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
        tasks = tasks.OrderBy(task => task.DueDate).ToList();
        Console.WriteLine("------------------------------------------------------------------------------------------------");
        Console.WriteLine("Task ID".PadRight(10) + "Title".PadRight(20) + "Project".PadRight(30) + "Due Date".PadRight(20) + "Status");
        foreach (var t in tasks)
        {
            Console.WriteLine(t.Id.ToString().PadRight(10) + t.Title.PadRight(20) + t.Project.PadRight(30) + t.DueDate.ToString().PadRight(20) + (t.Status ? "Done" : "Pending"));
        }
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }
    public void EditTasks()
    {
        TaskEditor taskEditor = new TaskEditor();
        Console.Write("To update the task, enter edit, done or remove: ");
        string choice = Console.ReadLine().Trim().ToLower();
        if (choice == "remove")
        {
            taskEditor.RemoveTask(tasks);
        }
        else if (choice == "edit")
        {
            taskEditor.UpdateTask(tasks);
        }
        else if (choice == "done")
        {
            taskEditor.MarkDone(tasks);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Enter edit, done or remove.");
            Console.ResetColor();
        }
    }
    public int TotalTasks()
    {
        return tasks.Count;
    }
    public int CompletedTasks()
    {
        return tasks.Count(task => task.Status);
    }
    public void SaveTasks()
    {

    }
}