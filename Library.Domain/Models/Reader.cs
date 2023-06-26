using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Models
{
    public class Reader
    {
        public Reader(int id, string name, string family, string patronymic, DateOnly yearBirth)
        {
            Id = id;
            Name = name;
            Family = family;
            Patronymic = patronymic;
            YearBirth = yearBirth;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Patronymic { get; set; }
        public DateOnly YearBirth { get; set; }
    }
}
