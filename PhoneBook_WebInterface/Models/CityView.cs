using PhoneBook_Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook_WebInterface.Models
{
    public class CityView
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Город")]
        [MinLength(3, ErrorMessage = "Наименование должно быть больше трех символов")]
        [RegularExpression("[а-яА-Яa-zA-Z-\\.\\s]+", ErrorMessage = "В названии города допустимы только символы латинского и русского алфавитов, а также знаки \"-\", \".\" и пробел")]
        public string Name { get; set; }

        [Display(Name = "Абонент")]
        public Abonent Abonent { get; set; }
    }
}