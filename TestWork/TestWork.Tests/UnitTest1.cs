using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWork.Controllers;
using TestWork.DataBase;

using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Linq;
namespace TestWork.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsTheModelNotNull()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;
            var context = new CodeContext();

            Assert.IsNotNull(result.Model);
        }
        [TestMethod]
        public void HasNewBookAdded()
        {
            HomeController controller = new HomeController();
            var context = new CodeContext();
            int count = context.Books.ToList().Count;
            Models.Author auth = new Models.Author { Name = "Ф. Достоевский" };
            string name = "Идиот";
            string genre = "Классика";
            Models.Book book = new Models.Book { Name = name, Genre = genre, Author = auth };
            controller.AddNewBook(name, null, auth.Name, genre);
            var result = context.Books.ToList().Count;
            Assert.IsTrue(result - count == 1);
        }
    }
}
