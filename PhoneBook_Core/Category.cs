using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Core
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Группа")]
        [MinLength(3, ErrorMessage = "Наименование должно быть больше трех символов")]
        [RegularExpression("[а-яА-Яa-zA-Z]+", ErrorMessage = "В имени группы допустимы только символы латинского и русского алфавитов")]
        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}