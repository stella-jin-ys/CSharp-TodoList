using System.Security.Cryptography;

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
            string title;
            while (true)
            {
                Console.Write("Enter the title of the task: ");
                title = Console.ReadLine();
                if (title != "")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a title.");
                    Console.ResetColor();
                }
            }
            string project;
            while (true)
            {
                Console.Write("Enter the project of the task: ");
                project = Console.ReadLine();
                if (project != "")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a project.");
                    Console.ResetColor();
                }
            }


            DateTime dueTime;
            while (true)
            {
                Console.Write("Enter the due date of the task(MM-DD-YYYY): ");
                if (!DateTime.TryParse(Console.ReadLine(), out dueTime))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid due date format. Please enter a valid date.");
                    Console.ResetColor();
                }
                else if (dueTime < DateTime.Now)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Due time cannot be earlier than today.");
                    Console.ResetColor();
                }
                else
                {
                    break;
                };
            }
            DateOnly dueDate = DateOnly.FromDateTime(dueTime);

            tasks.Add(new Task(nextId, title, project, dueDate, false));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Task{nextId} added successfully!");
            Console.ResetColor();
            nextId++;

            Console.Write("Enter any to continue add more tasks, no to exit: ");
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Task ID".PadRight(10) + "Title".PadRight(20) + "Project".PadRight(30) + "Due Date".PadRight(20) + "Status");
        Console.ResetColor();
        foreach (var t in tasks)
        {
            Console.WriteLine(t.Id.ToString().PadRight(10) + t.Title.PadRight(20) + t.Project.PadRight(30) + t.DueDate.ToString().PadRight(20) + (t.Status ? "Done" : "Pending"));
        }
        Console.WriteLine($"\n Total tasks: {TotalTasks()}, Completed tasks: {CompletedTasks()}");
        Console.WriteLine("------------------------------------------------------------------------------------------------");
    }
    public void EditTasks()
    {
        TaskEditor taskEditor = new TaskEditor();
        while (true)
        {
            Console.Write("To update the task, enter edit, done or remove: ");
            string choice = Console.ReadLine().Trim().ToLower();
            if (choice == "remove")
            {
                taskEditor.RemoveTask(tasks);
                break;
            }
            else if (choice == "edit")
            {
                taskEditor.UpdateTask(tasks);
                break;
            }
            else if (choice == "done")
            {
                taskEditor.MarkDone(tasks);
                break;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Enter edit, done or remove.");
                Console.ResetColor();
            }
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
        FileHandling fileHandling = new FileHandling("tasks.txt");

        // serialize each task into a string format
        List<string> linesToSave = tasks.Select(task => $"{task.Id}|{task.Title}|{task.Project}|{task.DueDate}|{(task.Status ? "Done" : "Pending")}").ToList();
        fileHandling.SaveToFile(linesToSave);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Tasks saved successfully!");
        Console.ResetColor();
    }
    public void LoadTasks()
    {
        FileHandling fileHandling = new FileHandling("tasks.txt");
        List<string> lines = fileHandling.ReadFromFile();
        tasks = lines.Select(line =>
        {
            var parts = line.Split("|");
            bool status = parts[4].Trim().ToLower() switch
            {
                "done" => true,
                "pending" => false,
                _ => throw new FormatException($"Invalid status {parts[4]}")
            };
            return new Task(int.Parse(parts[0]), parts[1], parts[2], DateOnly.Parse(parts[3]), status);
        }).ToList();
        if (tasks.Any())
        {
            nextId = tasks.Max(task => task.Id) + 1;
        };
    }
}