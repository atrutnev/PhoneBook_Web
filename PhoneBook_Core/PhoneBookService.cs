using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Core
{
    public class PhoneBookService
    {
        //Метод добавления абонента
        public void AddAbonent(Abonent abonent)
        {
            var db = new PhoneBookContext();
            db.People.Add(abonent);
            db.SaveChanges();
        }

        //Метод добавления группы
        public void AddCategory(Category category)
        {
            var db = new PhoneBookContext();
            db.Categories.Add(category);
            db.SaveChanges();
        }

        //Метод добавления города
        public void AddCity(City city)
        {
            var db = new PhoneBookContext();
            db.Cities.Add(city);
            db.SaveChanges();
        }

        //Методы удаления абонента
        public void DeleteAbonent(Abonent abonent)
        {
            DeleteAbonent(abonent.Id);
        }

        public void DeleteAbonent(int abonentId)
        {
            var db = new PhoneBookContext();
            var abonent = db.People.SingleOrDefault(a => a.Id == abonentId);
            if (abonent != null)
            {
                db.People.Remove(abonent);
                db.SaveChanges();
            }
        }

        //Метод удаления группы
        public void DeleteCategory(int categoryId)
        {
            var db = new PhoneBookContext();
            var category = db.Categories
                .SingleOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        //Метод удаления города
        public void DeleteCity(int cityId)
        {
            var db = new PhoneBookContext();
            var city = db.Cities
                .SingleOrDefault(c => c.Id == cityId);
            if (city != null)
            {
                db.Cities.Remove(city);
                db.SaveChanges();
            }
        }

        //Метод изменения абонента
        public void ModifyAbonent(int abonentId, Abonent abonent)
        {
            var db = new PhoneBookContext();
            var oldAbonent = db.People.Single(a => a.Id == abonentId);
            oldAbonent.Name = abonent.Name;
            oldAbonent.phoneNumber = abonent.phoneNumber;
            oldAbonent.Category = abonent.Category;
            oldAbonent.City = abonent.City;
            db.SaveChanges();
        }

        //Метод изменения группы
        public void ModifyCategory(int id, Category category)
        {
            var db = new PhoneBookContext();
            var ocategory = db.Categories.Single(c => c.Id == id);
            ocategory.Name = category.Name;
            db.SaveChanges();
        }

        //Метод изменения города
        public void ModifyCity(int id, City city)
        {
            var db = new PhoneBookContext();
            var ocity = db.Cities.Single(c => c.Id == id);
            ocity.Name = city.Name;
            db.SaveChanges();
        }

        //Метод формирования списка абонентов
        public IEnumerable<Abonent> GetPeople()
        {
            var db = new PhoneBookContext();
            return db.People.Include("Category").Include("City");   
        }

        //Метод формирования списка групп
        public IEnumerable<Category> GetCategories()
        {
            var db = new PhoneBookContext();
            return db.Categories.Include("People");
        }

        //Метод формирования списка городов
        public IEnumerable<City> GetCities()
        {
            var db = new PhoneBookContext();
            return db.Cities.Include("People");
        }

        //Метод поиска
        public IEnumerable<Abonent> SearchAbonent(string s)
        {
            var db = new PhoneBookContext();
            if (s != null)
            {
                foreach (var c in s)
                {
                    //Если введены буквы, то поиск производится по имени абонента. 
                    if (char.IsLetter(c))
                    {
                        var q = db.People.Where(a => a.Name.Contains(s)).Include("Category").Include("City");
                        return q;
                    }
                    //Если введены цифры, то поиск производится по номеру абонента.
                    else if (char.IsDigit(c))
                    {
                        //var number = int.Parse(s);
                        var q = db.People.Where(a => a.phoneNumber.Contains(s)).Include("Category").Include("City");
                        return q;
                    }
                    else
                    {
                        Console.WriteLine("Не удалось распознать поисковый запрос!");
                        break;
                    }
                }
            }
            return GetPeople();
        }


        //Метод отбора абонента
        public Abonent GetAbonent(int id)
        {
            var db = new PhoneBookContext();
            var q = db.People.Include("Category").Include("City").Single(a => a.Id == id);
            return q;
        }

        //Метод отбора группы
        public Category GetCategory(int categoryId)
        {
            var db = new PhoneBookContext();
            var q = db.Categories.Single(c => c.Id == categoryId);
            return q;
        }

        //Метод отбора города
        public City GetCity(int cityId)
        {
            var db = new PhoneBookContext();
            var q = db.Cities.Single(c => c.Id == cityId);
            return q;
        }

        //Метод очистки справочника (удаление БД)
        public void DeleteDb()
        {
            var db = new PhoneBookContext();
            db.Database.Delete();
        }

        //Метод вывода списка абонентов на экран
        public void ListAbonents()
        {
            foreach (var a in GetPeople())
            {
                Console.WriteLine(a);
            }
        }
    }
}
