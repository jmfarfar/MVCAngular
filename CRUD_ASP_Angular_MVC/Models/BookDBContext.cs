using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_ASP_Angular_MVC.Models
{
    public class BookDBContext:DbContext
    {
        public DbSet<Book> book { get; set; }
    }
}