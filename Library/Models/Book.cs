using System.Collections.Generic;

namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public ICollection<Author> BookAuthors { get; set; }
        public ICollection<Genre> BookGenres { get; set; }
    }
}
