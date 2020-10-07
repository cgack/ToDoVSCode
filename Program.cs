using System;
using ToDoVSCode.Models;
namespace ToDoVSCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! type ? to see menu");
            using var db = new TodoContext();
            Console.WriteLine("db initialized");
            var app = new TodoListApp(db);
            app.Run();
        }
    }
}
