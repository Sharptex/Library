using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class BookRepository
    {
        private readonly AppContext db;
        public BookRepository(AppContext context)
        {
            this.db = context;
        }

        //CRUD
        public async Task<Book> AddAsync(Book entity)
        {
            db.Books.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await db.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await db.Books.FindAsync(id);
        }

        public async Task<Book> UpdateBookYearByIdAsync(int newYear, int id)
        {
            var entity = await db.Books.FindAsync(id);
            entity.Year = newYear;
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(Book book)
        {
            var entity = await db.Books.FindAsync(book.Id);
            if (entity != null)
            {
                db.Books.Remove(entity);
                return await db.SaveChangesAsync();
            }
            return 0;
        }

        //Custom
        public async Task<IEnumerable<Book>> GetByGenreAndPeriodAsync(string genre, int yearStart, int yearEnd)
        {
            var books = db.Books.Include(p => p.BookGenres).Where(p => p.BookGenres.Any(c => c.Name == genre) && (p.Year >= yearStart && p.Year <= yearEnd));
            return await books.ToListAsync();
        }

        public async Task<int> GetBooksCountByAuthor(string author, int yearStart, int yearEnd)
        {
            return await db.Books.Where(p => p.BookAuthors.Any(c => c.Name == author)).CountAsync();
        }

        public async Task<Book> GetLastBookPublished()
        {
            return await db.Books.OrderByDescending(p => p.Year).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksOrderedByTitle()
        {
            return await db.Books.OrderBy(p => p.Title).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllBooksOrderedByYearDesc()
        {
            return await db.Books.OrderByDescending(p => p.Year).ToListAsync();
        }
    }
}
