using System;

namespace ToDoVSCode.Models 
{
    public class TodoItem 
    {
        public int Id {get;set;}
        public string Description {get;set;}
        public string Detail {get;set;}
        public bool IsComplete {get;set;}
        public DateTime DueDate {get;set;}
    }
}