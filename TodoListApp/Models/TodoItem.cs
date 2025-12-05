using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Models
{
    internal class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TodoItem (int id, string description)
        {
            Id = id; 
            Description = description; 
            IsCompleted = false;

        }
        public string GetStatusDisplay()
        {
            return IsCompleted ? "[x]" : "[ ]";
        }
    }

}
