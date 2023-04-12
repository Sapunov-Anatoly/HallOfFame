using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame.Models
{
    [Table("Persons")]
    public class Person
    {
        public Person() { }

        public long Id { get; set; }

        [MaxLength(50, ErrorMessage = "Длина Name не может быть больше 50 символов")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Длина DisplayName не может быть больше 20 символов")]
        public string DisplayName  { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }

    [Table("Skills")]
    public class Skill
    {
        public Skill() { }

        [MaxLength(20, ErrorMessage = "Длина Name не может быть больше 20 символов")]
        public string Name { get; set; }

        [Range(1, 10, ErrorMessage = "Значение уровня навыка не может быть ниже 1 и больше 10.")]
        public byte Level { get; set; }

        public long PersonId { get; set; }
    }
}
