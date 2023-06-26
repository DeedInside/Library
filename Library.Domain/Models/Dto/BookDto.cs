
namespace Library.Domain.Models.Dto
{
    public class BookDto
    {
        public BookDto(string name, string autor, string arc, int agePublic, int counBook)
        {
            Name = name;
            Autor = autor;
            Arc = arc;
            AgePublic = agePublic;
            CounBook = counBook;
        }

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
