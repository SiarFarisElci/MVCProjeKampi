using Project.ENTITIES.Models;
using Project.MAP.Optionals;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WriteMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new ContentMap());
            modelBuilder.Configurations.Add(new AboutMap());
            modelBuilder.Configurations.Add(new HeadingMap());
        }

        public DbSet<Write>  Writes { get; set; }
        public DbSet<Category>   Categories  { get; set; }
        public DbSet<Contact>   Contacts { get; set; }
        public DbSet<Content>   Contents { get; set; }
        public DbSet<About>   Abouts { get; set; }
        public DbSet<Heading>   Headings { get; set; }
    }
}
