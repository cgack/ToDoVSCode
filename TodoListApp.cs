using System;
using System.Linq;
using ToDoVSCode.Models;
namespace ToDoVSCode
{
    public class TodoListApp
    {
        private TodoContext _todoContext;
        public TodoListApp(TodoContext db) {
            _todoContext = db;
        }

      	public void Run()
		{
			CountTodos();
		}
		private string CountTodos()
		{
			var existingTodos = _todoContext.TodoItems.Count();
			Console.WriteLine($"You have {existingTodos} existing Todos.");
			return ParseMenu();
		}

		private string ParseMenu()
		{
			var inputLine = Console.ReadLine();
			if (inputLine == "?") inputLine = ShowMenu();
			if (inputLine == "1") inputLine = AddItem();
			if (inputLine == "2") inputLine = CompleteTodo();
			if (inputLine == "3") inputLine = ShowTodos();
			return Console.ReadLine();
		}
		private static string ShowMenu()
		{
			Console.WriteLine(@"
Select an option
1. Add an Item
2. Complete an Item
3. List Todos
");
			return Console.ReadLine();
		}

        private string AddItem() {
            Console.WriteLine("Please add a description.");
            var desc = Console.ReadLine();
            Console.WriteLine("Please add details (optional - just press enter to skip)");
            var detail = Console.ReadLine();
            var todoItem = new TodoItem {
                Description = desc,
                Detail = detail,
                DueDate = DateTime.Now.AddDays(1)
            };
            _todoContext.TodoItems.Add(todoItem);
            _todoContext.SaveChanges();
            return CountTodos();
        }

        private string CompleteTodo() {
            Console.WriteLine("Please select an item you would like to mark completed.");
            ListTodos(true);
            var todoToMarkCompletedAsIntegerPlease = int.Parse(Console.ReadLine());
            var todoItemToUpdate = _todoContext.TodoItems.FirstOrDefault(t => t.Id == todoToMarkCompletedAsIntegerPlease);
            todoItemToUpdate.IsComplete = true;
            _todoContext.TodoItems.Update(todoItemToUpdate);
            _todoContext.SaveChanges();
            return ShowTodos();
        }
        private string ShowTodos() {
            ListTodos();
            return CountTodos();
        }

        private void ListTodos(bool showOpenOnly = false) {
            var todos = _todoContext.TodoItems.ToList();
            if (showOpenOnly) {
                todos = todos.Where(t => t.IsComplete == false).ToList();
            }
            foreach( var todo in todos) {
                Console.WriteLine($"ID: {todo.Id}, Description: {todo.Description}, IsComplete: {todo.IsComplete}");
            }
        }
    }
}