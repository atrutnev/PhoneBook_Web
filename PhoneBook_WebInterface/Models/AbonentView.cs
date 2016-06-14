using PhoneBook_Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook_WebInterface.Models
{
    public class AbonentView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя не может быть пустым")]
        [Display(Name = "Имя абонента")]
        [RegularExpression("[а-яА-Яa-zA-Z]+", ErrorMessage = "Некорректный формат имени")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Номер телефона не может быть пустым")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{6,15}$", ErrorMessage = "Некорректный формат номера")]
        //[Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Номер телефона")]
        public int phoneNumber { get; set; }

        [Required(ErrorMessage = "Наименование группы должно быть заполнено")]
        [Display(Name = "Группа")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Наименование города должно быть заполнено")]
        [Display(Name = "Город")]
        public City City { get; set; }
    }
}