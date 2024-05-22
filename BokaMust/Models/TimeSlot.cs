using Microsoft.Extensions.Primitives;
using System.Xml.Linq;

namespace BokaMust.Models
{
    public class TimeSlot
    {
        public string Month { get; set; } 
        public string Date { get; set; } 
        public string Weekday { get; set; }
        public string Time { get; set; } //XX:XX
        public double Duration { get; set;}

        public TimeSlot() { }

        public TimeSlot(string month, string date, string weekday, string time, double duration)
        {
            Month = month; 
            Date = date;
            Weekday = weekday;
            Time = time;
            Duration = duration;

        }
    }
}
