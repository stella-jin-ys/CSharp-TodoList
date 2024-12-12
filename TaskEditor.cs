public class TaskEditor
{
    public void UpdateTask(List<Task> tasks)
    {
        while (true)
        {
            Console.Write("Enter a task ID to update the task: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = tasks.Find(task => task.Id == taskId);
                if (task != null)
                {
                    Console.Write("Enter a new title: ");
                    string newTitle = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newTitle))
                    {
                        task.Title = newTitle;
                    }

                    Console.Write("Enter a new project: ");
                    string newProject = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newProject))
                    {
                        task.Project = newProject;
                    }
                    string newDueTime;
                    while (true)
                    {
                        Console.Write("Enter a new due date(MM-DD-YYYY): ");
                        newDueTime = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newDueTime))
                        {
                            if (!DateTime.TryParse(newDueTime, out DateTime newTime))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid due date format. Please enter a valid date");
                                Console.ResetColor();
                            }
                            else
                            {
                                break;
                            };

                            DateOnly newDueDate = DateOnly.FromDateTime(newTime);
                            task.DueDate = newDueDate;
                        }
                        else
                        {
                            break;
                        }
                    };
                    Console.Write("Is the task done? Yes/ No: ");
                    string newStatus = Console.ReadLine().Trim().ToLower();
                    if (!string.IsNullOrWhiteSpace(newStatus))
                    {
                        if (newStatus == "yes")
                        {
                            task.Status = true;
                        }
                        else if (newStatus == "no")
                        {
                            task.Status = false;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task updated Successfully!");
                        Console.ResetColor();
                        break;
                    }
                    else if (string.IsNullOrWhiteSpace(newTitle) && string.IsNullOrWhiteSpace(newProject) && string.IsNullOrWhiteSpace(newDueTime) && string.IsNullOrWhiteSpace(newStatus))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No update input!");
                        Console.ResetColor();
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Task updated Successfully!");
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task not found.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task ID. Please enter a valid ID");
                Console.ResetColor();
            }
        }
    }
    public void RemoveTask(List<Task> tasks)
    {
        while (true)
        {
            Console.Write("Enter a task ID: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = tasks.Find(task => task.Id == taskId);
                if (task == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task not found.");
                    Console.ResetColor();
                }
                else
                {
                    tasks.Remove(task);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Task{task.Id} removed successfully!");
                    Console.ResetColor();
                    break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task ID. Please enter a valid ID");
                Console.ResetColor();
                break;
            }
        }
    }
    public void MarkDone(List<Task> tasks)
    {
        while (true)
        {
            Console.Write("Enter a task ID: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                var task = tasks.Find(task => task.Id == taskId);
                if (task == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Task not found.");
                    Console.ResetColor();
                }
                else
                {
                    task.Status = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Task{task.Id} marked as done!");
                    Console.ResetColor();
                    break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid task ID. Please enter a valid ID");
                Console.ResetColor();
                break;
            }
        }
    }
}