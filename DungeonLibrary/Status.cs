using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace DungeonLibrary
{
    public class Status 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        public Status(string name, string description, int duration)
        {
            Name = name;
            Description = description;
            Duration = duration;
        }

        public int GetDuration()
        {
            return Duration;
        }
    }
}
