using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoApp.Models;

namespace ToDoApp.DataAccess
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext() : base ("ToDoAppDb")
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}