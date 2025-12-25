using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class TaskManager
    {
        public static void AddSampleTask(List<TodoTask> TaskList)
        {
            TaskList.Add(new TodoTask("Task 1", DateTime.Today, new TimeSpan(0, 30, 0), new TimeSpan(2, 0, 0)));
            TaskList.Add(new TodoTask("Task 2", DateTime.Today.AddDays(3), new TimeSpan(2, 30, 0), new TimeSpan(3, 0, 0)));
            TaskList.Add(new TodoTask("Task 3", DateTime.Today.AddDays(1), new TimeSpan(6, 15, 0), new TimeSpan(7, 0, 0)));

        }


        public static void AddTask(List<TodoTask> TaskList)
        {
            string name = InputParse.GetName("Enter task name: ");
            if (name == null)
            {
                return;
            }
            DateTime date = InputParse.GetDate("Enter date (yyyy-MM-dd) or press Enter to skip: ");
            TimeSpan time_start = InputParse.GetTime("Enter start time (HH:mm) or press Enter to skip: ");
            TimeSpan time_end = InputParse.GetTime("Enter end time (HH:mm) or press Enter to skip: ");
            if (time_end < time_start && time_end != TimeSpan.Zero && time_start != TimeSpan.Zero)
            {
                Console.WriteLine("End time > Start time");
                Console.ReadLine();
                return;
            }
            TaskList.Add(new TodoTask(name, date, time_start, time_end));
        }
        //==============================================================================================
        public static void ViewTask(List<TodoTask> TaskList)
        {
            Console.WriteLine("===============================");
            Console.WriteLine("         TASK LIST");
            Console.WriteLine("===============================");
            if (TaskList.Count < 1)
            {
                Console.WriteLine("No tasks available.");
                Console.WriteLine("===============================");
                return;
            }

            for (int i = 0; i < TaskList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {TaskList[i]}");
            }

            Console.WriteLine("===============================");
            Console.WriteLine($"Total: {TaskList.Count} task(s).");
        }
        //==============================================================================================
        public static void StatusTask(List<TodoTask> TaskList)
        {
            TaskManager.ViewTask(TaskList);
            if (TaskList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"Enter task number (1..{TaskList.Count}) or press 0 to cancel: ");
            if (!int.TryParse(Console.ReadLine(), out int inputTaskNumber))
            {
                Console.WriteLine("Invalid input!");
                Console.ReadLine();
                return;
            }
            if (inputTaskNumber == 0) return;
            if (inputTaskNumber < 0 || inputTaskNumber > TaskList.Count)
            {
                Console.WriteLine("Invalid task number!");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter status: press 1 = Done, press 0 = Pending");
            if (!int.TryParse(Console.ReadLine(), out int inputStatusChoice))
            {
                Console.WriteLine("Invalid Input.");
                Console.ReadLine();
                return;
            }
            if (inputStatusChoice <= 0 || inputTaskNumber > TaskList.Count)
            {
                Console.WriteLine("Invalid task number!");
                Console.ReadLine();
                return;
            }

            switch (inputStatusChoice)
            {
                case 0:
                    TaskList[inputTaskNumber - 1].Status = StatusEnum.Pending;
                    Console.WriteLine("Set back to Pending.");
                    break;
                case 1:
                    TaskList[inputTaskNumber - 1].Status = StatusEnum.Done;
                    Console.WriteLine("Marked as Done.");
                    break;
                default:
                    Console.WriteLine("Invalid status value!");
                    Console.ReadLine();
                    return;
            }
            Console.Clear();
            TaskManager.ViewTask(TaskList);
            Console.WriteLine("===============================");
            Console.WriteLine("Update list");
            Console.ReadLine();
            return;
        }
        //==============================================================================================
        public static void DeleteTask(List<TodoTask> TaskList)
        {
            while (true)
            {
                TaskManager.ViewTask(TaskList);
                if (TaskList.Count == 0)
                {
                    Console.WriteLine("No task avaiable.");
                    Console.WriteLine("Return Main Menu.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"Enter task number (1...{TaskList.Count}) or press 0 to cancel:");
                if (!int.TryParse(Console.ReadLine(), out int inputTaskDelete))
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadLine();
                    continue;
                }

                if (inputTaskDelete == 0)
                {
                    return;
                }

                if (inputTaskDelete < 1 || inputTaskDelete > TaskList.Count)
                {
                    Console.WriteLine("Invalid input!. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                else
                {
                    TaskList.RemoveAt(inputTaskDelete - 1);
                }

                Console.Clear();
                TaskManager.ViewTask(TaskList);
                Console.WriteLine("===============================");
                Console.WriteLine("Task Deleted.");
                Console.ReadLine();
                return;
            }
        }
        //==============================================================================================
        public static void EditTask(List<TodoTask> TaskList)
        {
            TaskManager.ViewTask(TaskList);
            while (true)
            {
                if (TaskList.Count == 0)
                {
                    Console.WriteLine("No task avaiable.");
                    Console.WriteLine("Return Main Menu.");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"Enter task number (1...{TaskList.Count}) or press 0 to cancel:");
                if (!int.TryParse(Console.ReadLine(), out int inputnumberEdit))
                {
                    Console.WriteLine("Invalid Input. Press Enter to try again");
                    Console.ReadLine();
                    continue;
                }

                if (inputnumberEdit == 0)
                {
                    return;
                }
                
                if (inputnumberEdit < 1 || inputnumberEdit > TaskList.Count)
                {
                    Console.WriteLine("Invalid task.");
                    Console.ReadLine();
                    continue;
                }

                else
                {
                    Console.WriteLine("Enter new Task");
                    int i = inputnumberEdit - 1;
                    string? input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        TaskList[i].Name = input;
                    }
                    else
                    {
                        Console.Write("Invalid Name.");
                        return;
                    }
                    Console.Clear();
                    TaskManager.ViewTask(TaskList);
                    Console.WriteLine("===============================");
                    Console.WriteLine("Task updated successfully.");
                    Console.ReadLine();
                    return;
                }
            }
        }
        //==============================================================================================
        public static void DeleteAllTask(List<TodoTask>TaskList)
        {
            TaskList.Clear();
            TaskManager.ViewTask(TaskList);
            Console.WriteLine("===============================");
            Console.WriteLine("Delete All Task successfully.");
            Console.ReadLine();
            return;
        }
    }
}
