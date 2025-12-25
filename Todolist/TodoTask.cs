using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class TodoTask
    {
        //public int Id;
        public string Name;
        public StatusEnum Status;
        public DateTime Date;
        public TimeSpan Time_start;
        public TimeSpan Time_end;
        public TimeSpan Duration => Time_end - Time_start;
        public TodoTask(string name, DateTime date, TimeSpan time_start, TimeSpan time_end)
        {
            //Id = autoId++; //id lun fix, ko update sau khi xóa hay sort.
            Name = name;
            Status = StatusEnum.Pending;
            Date = date;
            Time_start = time_start;
            Time_end = time_end;
        }
        public override string ToString()
        {
            string statusView = Status == StatusEnum.Done ? "[X]" : "[ ]";
            return
                $"{statusView} {Name} " +
                $"({Date:yyyy-MM-dd} " +
                $"{Time_start:hh\\:mm} - {Time_end:hh\\:mm}) " +
                $"- {Duration.TotalMinutes} min";
        }
    }
}
