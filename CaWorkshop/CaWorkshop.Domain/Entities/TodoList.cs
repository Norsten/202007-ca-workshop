using System.Collections.Generic;

namespace CaWorkshop.Domain.Entities
{
    public class TodoList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Colour { get; set; }

        // TIP: initialise property directly here
        // removing set;
        public IList<TodoItem> Items { get; set; } = new List<TodoItem>();
    }
}
