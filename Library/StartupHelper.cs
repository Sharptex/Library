using Library.Models;
using System.Collections.Generic;

namespace Library
{
    public static class StartupHelper
    {
        public static void SeedData(AppContext db)
        {
            var user1 = new User { Name = "Артур", Email = "admin@mail.ru" };
            var user2 = new User { Name = "Боб", Email = "bob@mail.ru" };

            var g1 = new Genre { Name = "Юмор", Books = new List<Book>() };
            var g2 = new Genre { Name = "Драма", Books = new List<Book>() };

            var a1 = new Author { Name = "Мартин", Books = new List<Book>() };
            var a2 = new Author { Name = "Вальтер", Books = new List<Book>() };

            var book1 = new Book { Title = "Основы C#", Year = 1254, BookGenres = new List<Genre>() { g1, g2 }, BookAuthors = new List<Author>() { a1 } };
            var book2 = new Book { Title = "Алгоритмы", Year = 2342, BookGenres = new List<Genre>() { g2 }, BookAuthors = new List<Author>() { a2 } };

            db.Users.AddRange(user1, user2);
            db.Genres.AddRange(g1, g2);
            db.Authors.AddRange(a1, a2);
            db.SaveChanges();

            db.Books.AddRange(book1, book2);
            db.SaveChanges();

            var card1 = new Card { BookId = book1.Id, UserId = user2.Id };
            var card2 = new Card { BookId = book2.Id, UserId = user1.Id };
            db.Cards.AddRange(card1, card2);
            db.SaveChanges();
        }
    }
}
