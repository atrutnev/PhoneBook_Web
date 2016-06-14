using PhoneBook_Core;
using PhoneBook_WebInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook_WebInterface.Controllers
{
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook
        public ActionResult Index()
        {
            var service = new PhoneBookService();
            return View(service.GetPeople()
                        .Select(a => new AbonentView { Name = a.Name, phoneNumber = a.phoneNumber, Id = a.Id, Category = a.Category, City = a.City }));
        }

        // GET: PhoneBook/Details/5
        public ActionResult Details(int id)
        {
            var service = new PhoneBookService();
            var abonent = service.GetAbonent(id);
            return View(new AbonentView { Name = abonent.Name, phoneNumber = abonent.phoneNumber, Id = abonent.Id, Category = abonent.Category, City = abonent.City });
        }

        // GET: PhoneBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBook/Create
        [HttpPost]
        public ActionResult Create(AbonentView abonentView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.AddAbonent(new Abonent { Name = abonentView.Name, phoneNumber = abonentView.phoneNumber, Category = abonentView.Category, City = abonentView.City});
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new PhoneBookService();
            var abonent = service.GetAbonent(id);
            return View(new AbonentView
            {
                Name = abonent.Name,
                phoneNumber = abonent.phoneNumber,
                Id = abonent.Id,
                Category = abonent.Category,
                City = abonent.City
            });
        }

        // POST: PhoneBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AbonentView abonentView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.ModifyAbonent(
                        id,
                        new Abonent { Name = abonentView.Name, phoneNumber = abonentView.phoneNumber, Category = abonentView.Category, City = abonentView.City });
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBook/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new PhoneBookService();
            var abonent = service.GetAbonent(id);
            return View(new AbonentView
            {
                Name = abonent.Name,
                phoneNumber = abonent.phoneNumber,
                Id = abonent.Id,
                Category = abonent.Category,
                City = abonent.City
            });
        }

        // POST: PhoneBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AbonentView abonentView)
        {
            try
            {
                var service = new PhoneBookService();
                service.DeleteAbonent(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
