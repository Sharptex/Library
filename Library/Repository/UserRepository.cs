using Library.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class UserRepository
    {
        private readonly AppContext db;
        public UserRepository(AppContext context)
        {
            this.db = context;
        }

        //CRUD
        public async Task<User> AddAsync(User entity)
        {
            db.Users.Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await db.Users.FindAsync(id);
        }

        public async Task<User> UpdateUserNameByIdAsync(string newName, int id)
        {
            var entity = await db.Users.FindAsync(id);
            entity.Name = newName;
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(User user)
        {
            var entity = await db.Users.FindAsync(user.Id);
            if (entity != null)
            {
                db.Users.Remove(entity);
                return await db.SaveChangesAsync();
            }
            return 0;
        }

        //Custom
        public async Task<bool> GetBookInUseFlag(int bookId, int userId)
        {
            return await db.Cards.AnyAsync(p => p.BookId == bookId && p.UserId == userId);
        }

        public async Task<int> GetBooksCountInUseByUser(int userId)
        {
            return await db.Cards.Where(p => p.UserId == userId).CountAsync();
        }
    }
}
