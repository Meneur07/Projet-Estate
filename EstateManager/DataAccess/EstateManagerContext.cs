using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace EstateManager.DataAccess
{
    public class EstateManagerContext : DbContext
    {

        private static EstateManagerContext _context = null;

        public static EstateManagerContext Current
        {
            get
            {
                if(_context == null)
                    throw new Exception("Le context n'est pas initialisé !");
                return _context;

            }
        }

        public DbSet<Models.Estate> Estates { get; set; }
        public DbSet<Models.Photo> Photos { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }
        public DbSet<Models.TagEstate> TagEstates { get; set; }
        public DbSet<Models.Tag> Tags { get; set; }
        public DbSet<Models.Person> Persons { get; set; }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Appointment> Appointments { get; set; }

        public async static Task InitializeAsync()
        {
            if(_context == null)
            {
                _context = new EstateManagerContext(Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), "database.db"));
            }
            await _context.Database.MigrateAsync();
        }

        public string DatabasePath { get; }
        private EstateManagerContext(string dbPath) : base()
        {
            DatabasePath = dbPath;
        }
        internal EstateManagerContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); optionsBuilder.EnableSensitiveDataLogging(); optionsBuilder.UseSqlite($"Filename ={DatabasePath}"); 
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.TagEstate>().HasKey(x=> new { x.EstateReference, x.TagId });

        }


    }
}

