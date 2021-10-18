using Microsoft.EntityFrameworkCore;
using System;

namespace Domen
{
    public class BibliotekaContext : DbContext
    {
        public BibliotekaContext(DbContextOptions<BibliotekaContext> options) : base(options)
        {

        }
        public DbSet<Knjiga> Knjiga { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Zahtev> Zahtev { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database = Biblioteka; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervacija>()
            .HasKey(r => new { r.Id});

            modelBuilder.Entity<Zahtev>()
            .HasKey(z => new { z.knjigaId,z.usernameKorisnik});

            modelBuilder.Entity<Korisnik>()
          .HasKey(k => new { k.Username });

            modelBuilder.Entity<Knjiga>()
          .HasKey(k => new { k.Id });

            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.Korisnik)
                .WithMany(r => r.Rezervacije)
                .HasForeignKey(r => r.KorisnikUsername);


            modelBuilder.Entity<Rezervacija>()
                .HasOne(r => r.Knjiga)
                .WithMany(r => r.Rezervacije)
                .HasForeignKey(r => r.IDKnjige);

            modelBuilder.Entity<Zahtev>()
                .HasOne(z => z.Knjiga)
                .WithMany(z => z.Zahtevi)
                .HasForeignKey(z => z.knjigaId);



            modelBuilder.Entity<Zahtev>()
                .HasOne(z => z.Korisnik)
                .WithMany(z => z.Zahtevi)
                .HasForeignKey(z => z.usernameKorisnik);

            
        

        }
    }
}
