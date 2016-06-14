using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook_Core
{
    public class Category
    {
        public int Id { get; set; }

        [RegularExpression("[а-яА-Яa-zA-Z]+", ErrorMessage = "Некорректный формат группы")]
        public string Name { get; set; }

        public ICollection<Abonent> People { get; set; }
    }
}