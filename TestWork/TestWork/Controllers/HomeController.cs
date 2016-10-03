using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWork.Models;
using TestWork.DataBase;
using System.Data.Entity;
namespace TestWork.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CodeContext>());
            using (var context = new CodeContext())
            {

                //Заполнение базы
                Author author1 = new Author { Name = "М. Пьюзо" };
                Author author2 = new Author { Name = "Г. Шилдт" };
                Author author3 = new Author { Name = "Ч. Диккенс" };

                Book book1 = new Book { Name = "Крестный отец", Genre = "Криминальный жанр", Author = author1 };
                Book book2 = new Book { Name = "C# 4.0 Полное руководство", Genre = "Техническая литература", Author = author2 };
                Book book3 = new Book { Name = "Приключения Оливера твиста", Genre = "Приключения", Author = author3 };



                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);

                context.SaveChanges();



                context.Authors.ToList();
                ViewBag.Authors = context.Authors.ToList();
                List<Book> model = context.Books.ToList();
                return View(model);
            }
        }

        [HttpPost]
        public PartialViewResult TableWithBooks(string value)
        {
            using (var context = new CodeContext())
            {
                context.Authors.ToList();
                List<Book> model = context.Books.Where(b => b.Author.Name.Contains(value) || b.Name.Contains(value)).ToList();

                return PartialView(model);
            }
        }
        [HttpPost]
        public void AddNewBook(string name, string author, string new_author, string genre)
        {
            using (var context = new CodeContext())
            {
                context.Authors.ToList();
                Author auth;
                if (new_author != "")
                    auth = new Author { Name = new_author };
                else
                    auth = context.Authors.First(a => a.Name == author);
                Book book = new Book { Name = name, Genre = genre, Author = auth};
                context.Books.Add(book);
                context.SaveChanges();
                List<Book> model = context.Books.ToList();
            }
        }
    }
}