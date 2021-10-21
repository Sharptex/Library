using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var db = new AppContext())
            {
                StartupHelper.SeedData(db);

                var userRepo = new UserRepository(db);
                var bookRepo = new BookRepository(db);

                //Example of repo using
                var books = await bookRepo.GetAllBooksOrderedByYearDesc();
            }
        }
    }
}
