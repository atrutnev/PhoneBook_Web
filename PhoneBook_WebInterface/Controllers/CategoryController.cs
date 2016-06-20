using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook_Core;
using PhoneBook_WebInterface.Models;

namespace PhoneBook_WebInterface.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var service = new PhoneBookService();
            return View(service.GetCategories()
                .Select(c => new CategoryView
                {
                    Id = c.Id,
                    Name = c.Name
                }));
        }

        // GET: Category/Details/5
        //public ActionResult Details(int id)
        //{
        //    var service = new PhoneBookService();
        //    var category = service.GetCategory(id);
        //    return View(new CategoryView { Name = category.Name});
        //}

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryView categoryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.AddCategory(new Category
                    {
                        Name = categoryView.Name
                    });

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new PhoneBookService();
            var category = service.GetCategory(id);
            return View(new CategoryView
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryView categoryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.ModifyCategory(id, new Category
                    {
                        Name = categoryView.Name
                    });

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new PhoneBookService();
            var category = service.GetCategory(id);
            return View(new CategoryView
            {
                Id = category.Id,
                Name = category.Name
            });
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var service = new PhoneBookService();
                service.DeleteCategory(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
