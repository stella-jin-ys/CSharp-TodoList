To-Do List Application

Overview

The To-Do List application is a console-based task management tool that helps users organize, track, and update their tasks efficiently. The application supports adding, editing, removing, and marking tasks as done, with persistent storage through file handling.

Features

Add Tasks: Create tasks with a title, project name, and due date.

View Tasks: Display all tasks sorted by due date, along with their ID, title, project, status, and due date.

Edit Tasks: Update the title, project, due date, or status of a task.

Remove Tasks: Delete tasks by specifying their ID.

Mark Tasks as Done: Toggle the status of a task between Done and Pending.

Save Tasks: Save the current list of tasks to a file for persistent storage.

Load Tasks: Load tasks from the file upon application startup.

How It Works

Task Management:

Tasks are managed in a List<Task> collection.

Each task has a unique ID, title, project, due date, and status (Done or Pending).

File Storage:

Tasks are saved to a file named tasks.txt in the current directory.

The file format for each task is:

TaskID|Title|Project|DueDate|Status

Status is stored as Done or Pending.

Task Loading:

The application reads tasks from the file and recreates the task list upon startup.

Invalid status values in the file result in an error to ensure data integrity.

