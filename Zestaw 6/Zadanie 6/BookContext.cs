﻿using Microsoft.EntityFrameworkCore;

namespace Zadanie_6
{
    public class BookContext : DbContext
    {
        private const string ConnectionString =
            @"server=(localdb)\MSSQLLocalDb;" + @"database=MyBooks;trusted_connection=true";

        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}