using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class ReportGenerator
    {
        public static void ReportTask(List<TodoTask> TaskList)
        {
            int doneCount = TaskList.Count(t => t.Status == StatusEnum.Done); //lambda expression            

            double completerate = TaskList.Count == 0 ? 0.00 : (double)doneCount * 100.0 / TaskList.Count;

            string evaluation = doneCount == TaskList.Count
                ? "Excellent! Keep the energy going!"
                : completerate < 60
                    ? "Making progress — stay focused!"
                    : "Good work! Keep pushing forward!";
            TaskManager.ViewTask(TaskList);
            Console.WriteLine("===============================");
            Console.WriteLine("  TODAY'S PRODUCTIVITY REPORT  ");
            Console.WriteLine("===============================");
            Console.WriteLine($"Total Tasks: {TaskList.Count}");
            Console.WriteLine($"Completed: {doneCount}");
            Console.WriteLine($"Completion Rate: {completerate:F2}%");
            Console.WriteLine($"Evaluation: {evaluation}");
            Console.ReadLine();
            return;
        }
        //==============================================================================================
        public static void ExportFileTxt(List<TodoTask> TaskList)
        {
            //sort
            TaskList = TaskList
                .OrderBy(t => t.Date)
                .ThenBy(t => t.Time_start)
                .ToList();
            //test
            ReportTask(TaskList); 
            //---------------------------------
            string ExportTaskDetail()
            {
                var etd = new StringBuilder();
                etd.AppendLine("                TIMETABLE");
                etd.AppendLine("========================================");
                etd.AppendLine($"Export at: {DateTime.Now}");
                etd.AppendLine("----------------------------------------");
                if (TaskList.Count == 0)
                {
                    etd.AppendLine("No tasks available.");
                }
                else
                {
                    for (int i = 0; i < TaskList.Count; i++)
                    {
                        etd.AppendLine($"{i + 1}. {TaskList[i]}");
                    }
                }
                return etd.ToString();
            }

            Console.WriteLine("Export completer");
            string text = ExportTaskDetail();
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            File.WriteAllText(Path.Combine(docPath, "TimeTable.txt"), text);
            Console.WriteLine("===============================");
            Console.WriteLine($"Exported to: {docPath}");
            Console.WriteLine("Press Enter to return...");
            Console.ReadLine();
            return;

        }
    }
}
