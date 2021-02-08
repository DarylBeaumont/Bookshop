namespace Bookshop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bookshop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Bookshop.Data.BookshopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bookshop.Data.BookshopContext context)
        {
            // Books
            context.Books.AddOrUpdate(x => x.Id,
                new Book { Author = "Mary Shelley", PublishDate = new DateTime(2003, 8, 11), Title = "Frankenstein: Or, the Modern Prometheus" },
                new Book { Author = "Frank Herbert", PublishDate = new DateTime(2015, 7, 16), Title = "Dune" },
                new Book { Author = "Karl Marx", PublishDate = new DateTime(2011, 3, 2), Title = "Das Kapital" },
                new Book { Author = "George Orwell", PublishDate = new DateTime(2000, 3, 30), Title = "Homage to Catalonia" }
            );
        }
    }
}
