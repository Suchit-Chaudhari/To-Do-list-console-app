using System;
using System.Collections.Generic;

class Program{
    static List<Task> tasks = new List<Task>();
    static int taskId = 1;
    static void Main(string[] args)
    {
        while(true){
            Console.Clear();
            Console.WriteLine("To-Do List");
            Console.WriteLine("================");
            Console.WriteLine("1. view tasks");
            Console.WriteLine("2. add tasks");
            Console.WriteLine("3. Delete Tasks");
            Console.WriteLine("4.Mark as done");
            Console.WriteLine("Choose an option to continue: ");

            string choice = Console.ReadLine();
            switch (choice){
                case "1":
                    ViewTasks();
                    break;
                
                case "2":
                    AddTask();
                    break;
                
                case"3":
                    DeleteTask();
                    break;

                case"4":
                    MarkDone();
                    break;

                default:
                    Console.WriteLine("Invalid option press any key to continue");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private static void MarkDone()
    {
        Console.Clear();
        Console.WriteLine("Enter task id to upate the tasks");
        int id = Convert.ToInt32(Console.ReadLine());

        Task updateTask = null;
        foreach (Task task in tasks){
            if (task.Id == id){
                updateTask = task;
            }
        }

        if(updateTask != null){
            updateTask.IsCompleted = true;
            Console.WriteLine("Task marked as completed, Press any key to continue... ");


        }
        else{
            Console.WriteLine("Unnable to find task, press any key to continue... ");
        }
    }

    private static void DeleteTask()
    {
        Console.Clear();
        Console.WriteLine("Enter task id");
        int id = Convert.ToInt32(Console.ReadLine());

        Task delTask = null;

        foreach (Task task in tasks){
            if (task.Id == id){
                delTask = task;
            }
        }

        if (delTask != null){
            tasks.Remove(delTask);
            Console.WriteLine("Task Deleted Successfully, Press any key to continue");
        }
        else{
            Console.WriteLine("Task not found press any key to continue");
        }
        Console.ReadKey();
    }

    private static void ViewTasks()
    {
        Console.Clear();
        foreach (Task task in tasks)
        {
            Console.WriteLine($"{task.Id} -- {task.description} -- {(task.IsCompleted == true ? "Completed" : "Completed")}");
        }

        Console.WriteLine("Press any key to continue"); 
        Console.ReadKey();
    }
    static void AddTask(){
        Console.Clear();
        Console.WriteLine("Enter description of the task");
        string desc = Console.ReadLine();

        tasks.Add(new Task {Id = taskId++, description=desc, IsCompleted=false });
        Console.WriteLine("Task added successfully press any key to continue");

        Console.ReadKey();
    }

    
}