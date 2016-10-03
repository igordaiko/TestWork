using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestWork.Models;
namespace TestWork.DataBase
{
    public class CodeContext : DbContext
    {
        public CodeContext() : base("connectionString")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}