using System.Globalization;
using System.Text;

namespace Todolist
{
    class Program
    {

        static void Main(string[] args)
        {
            List<TodoTask> TaskList = new List<TodoTask>();
            TaskManager.AddSampleTask(TaskList);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================");
                Console.WriteLine("         TO-DO LIST APP");
                Console.WriteLine("===============================");
                Console.WriteLine("1. View Tasks");
                Console.WriteLine("2. Add Task");
                Console.WriteLine("3. Delete Task");
                Console.WriteLine("4. Change Status Task");
                Console.WriteLine("5. Edit Task");
                Console.WriteLine("6. Delete All Task");
                Console.WriteLine("7. Today’s Productivity Report");
                Console.WriteLine("8. Export TimeTable to .txt");
                Console.WriteLine("0. Exit");
                Console.WriteLine("-------------------------------");

                Console.Write("Choose an option: ");
                string? menuinput = Console.ReadLine();
                if (!int.TryParse(menuinput, out int choose))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
                }

                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Clear();
                        TaskManager.ViewTask(TaskList);
                        Console.WriteLine("===============================");
                        Console.WriteLine("Press Enter to return Menu.");
                        Console.ReadLine();
                        break;

                    case 2:
                        Console.Clear();
                        TaskManager.AddTask(TaskList);
                        break;
                    case 3:
                        Console.Clear();
                        TaskManager.DeleteTask(TaskList);
                        break;
                    case 4:
                        Console.Clear();
                        TaskManager.StatusTask(TaskList);
                        break;
                    case 5:
                        Console.Clear();
                        TaskManager.EditTask(TaskList);
                        break;
                    case 6:
                        Console.Clear();
                        TaskManager.DeleteAllTask(TaskList);
                        break;
                    case 7:
                        Console.Clear();
                        ReportGenerator.ReportTask(TaskList);
                        break;
                    case 8:
                        Console.Clear();
                        ReportGenerator.ExportFileTxt(TaskList);
                        break;

                    default:
                        Console.WriteLine("Invalid choose. Try again.");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
