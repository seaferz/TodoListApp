using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Logic
{
    internal class TodoListManager
    {
       private List<TodoItem> _todoList = new List<TodoItem> ();
        private int _nextId = 1;


        public TodoListManager()
        {
            _todoList.Add(new TodoItem(_nextId++, "Buy groceries"));
            _todoList.Add(new TodoItem(_nextId++, "Read a book"));
            _todoList.Add(new TodoItem(_nextId++, "Go for a walk"));
        }
        public List<TodoItem> GetTodoList()
        { return _todoList; }
        public bool AddTask(string description)
        {
            
            if (string.IsNullOrWhiteSpace(description))
            {
                Console.WriteLine("Error: Task description cannot be empty");
                return false;
            }
            _todoList.Add(new TodoItem (_nextId++, description));
            Console.WriteLine($"Success: Task '{description}' added.");
            return true;
        }
        public bool ToggleleTaskComplection(int taskId)
        {
            var taskToToggle = _todoList.FirstOrDefault(t => t.Id == taskId);
            if (taskToToggle == null)
            {
                Console.WriteLine($"Error: Task with ID {taskId} not found.");
                return false;
            }
            taskToToggle.IsCompleted = !taskToToggle.IsCompleted;
            Console.WriteLine($"Success: Task {taskId} status updated to {taskToToggle.GetStatusDisplay()}");
            return true;
        }
        
        public void DisplayTodoList()
        {
            Console.Clear();
            Console.WriteLine("\n--- Yout To-Do List ---");
            if ( _todoList.Count == 0 )
            {
                Console.WriteLine("Your To-Do List is empty!");
            }
            else
            {
                foreach (var item in _todoList )
                {
                    Console.WriteLine($"{item.Id}, {item.GetStatusDisplay()}, {item.Description}");
                }
                Console.WriteLine("-------------------");
            }
        }
       
       
    }
}
