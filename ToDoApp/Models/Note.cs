using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class Note : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime DueDate { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}