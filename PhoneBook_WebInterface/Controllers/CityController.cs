using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBook_Core;
using PhoneBook_WebInterface.Models;

namespace PhoneBook_WebInterface.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            var service = new PhoneBookService();
            return View(service.GetCities()
                .Select(c => new CityView
                {
                    Id = c.Id,
                    Name = c.Name
                }));
        }

        // GET: City/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(CityView cityView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.AddCity(new City
                    {
                        Name = cityView.Name
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new PhoneBookService();
            var city = service.GetCity(id);
            return View(new CityView
            {
                Id = city.Id,
                Name = city.Name
            });
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CityView cityView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new PhoneBookService();
                    service.ModifyCity(id, new City
                    {
                        Name = cityView.Name
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

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            var service = new PhoneBookService();
            var city = service.GetCity(id);
            return View(new CityView
            {
                Id = city.Id,
                Name = city.Name
            });
        }

        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var service = new PhoneBookService();
                service.DeleteCity(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
