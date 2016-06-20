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
        [RegularExpression("[а-яА-Яa-zA-Z-\\.]+", ErrorMessage = "В имени абонента допустимы только символы латинского и русского алфавитов, а также знаки \"-\" и \".\"")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Номер телефона не может быть пустым")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{6,15}$", ErrorMessage = "Некорректный формат номера")]
        [Display(Name = "Номер телефона")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Наименование группы должно быть заполнено")]
        [Display(Name = "Группа")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Наименование города должно быть заполнено")]
        [Display(Name = "Город")]
        public City City { get; set; }
    }
}