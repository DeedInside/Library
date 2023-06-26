using System.ComponentModel.DataAnnotations;


namespace Library.Domain.Models
{
    public class Book
    {
        public Book(int id, string name, string autor, string arc, int agePublic, int counBook)
        {
            Id = id;
            Name = name;
            Autor = autor;
            Arc = arc;
            AgePublic = agePublic;
            CounBook = counBook;
        }
        public Book(string name, string autor, string arc, int agePublic, int counBook)
        {
            Name = name;
            Autor = autor;
            Arc = arc;
            AgePublic = agePublic;
            CounBook = counBook;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// «Автор»
        /// </summary>
        public string Autor { get; set; }
        /// <summary>
        /// «Артикул» 
        /// </summary>
        public string Arc { get; set; }
        /// <summary>
        /// «Год издания» 
        /// </summary>
        public int AgePublic { get; set; }
        /// <summary>
        /// //«Количество экземпляров» 
        /// </summary>
        public int CounBook { get; set; }
    }
}
