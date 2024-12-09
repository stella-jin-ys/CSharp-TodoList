public class Tasks
{
    public string Title { get; set; }
    public DateOnly DueDate { get; set; }
    public bool Status { get; set; }
    public string Project { get; set; }
    public Tasks(string title, string project, DateOnly dueDate, bool status)
    {
        Title = title;
        Project = project;
        DueDate = dueDate;
        Status = status;
    }
}