using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotGame
{
    internal class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }

        public override string ToString()
        {
            return $"Task: {Title}\nDescription: {Description}\nReminder: {(Reminder.HasValue ? Reminder.Value.ToString("g") : "None")}";
        }
    }
}
