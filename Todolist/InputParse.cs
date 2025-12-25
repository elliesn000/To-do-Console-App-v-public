using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todolist
{
    public class InputParse
    {
        public static string GetName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? inputName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(inputName))
                {
                    return inputName;
                }
                Console.WriteLine("Task name cannot be empty!");
                Console.WriteLine("Input again. Or press 0 return Main Menu.");
                string? exitOrNot = Console.ReadLine();
                if (exitOrNot == "0")
                {
                    return null!; 
                }
            }
        }

        public static DateTime GetDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? inputDate = Console.ReadLine();

                if (string.IsNullOrEmpty(inputDate))
                {
                    return DateTime.Now;
                }

                if (DateTime.TryParseExact(
                    inputDate,
                    new[] { "yyyy-MM-dd" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime date))
                {
                    return date;
                }

                Console.WriteLine("Invalid date! Please use yyyy-MM-dd");
            }
        }
        public static TimeSpan GetTime(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? inputTime = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputTime))
                {
                    return TimeSpan.Zero;
                }

                if (TimeSpan.TryParseExact(
                    inputTime,
                    new[] { "hh\\:mm" },
                    CultureInfo.InvariantCulture,
                    TimeSpanStyles.None,
                    out TimeSpan time))
                {
                    return time;
                }

                else
                {
                    Console.WriteLine("Invalid time! Please use HH:mm");
                }
            }
        }
    }

    public enum StatusEnum
    {
        Pending,
        Done
    }

}
