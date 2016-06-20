using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Core
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Город")]
        [MinLength(3, ErrorMessage = "Наименование должно быть больше трех символов")]
        [RegularExpression("[а-яА-Яa-zA-Z-\\.\\s]+", ErrorMessage = "В названии города допустимы только символы латинского и русского алфавитов, а также знаки \"-\", \".\" и пробел")]
        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}