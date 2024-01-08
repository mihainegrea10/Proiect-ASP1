using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Models;
using Proiect_ASP1.Models;

namespace Proiect_ASP.Data
{
    public class Context : DbContext
    {
        
        public DbSet<Echipa> echipas { get; set; }
        public DbSet<Antrenor> antrenors { get; set; }
        public DbSet<Jucator> jucators { get; set; }
        public DbSet<Impresar> impresars { get; set; }
        public DbSet<User> Users { get; set;  }

        public Context(DbContextOptions<Context> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<echipa_cont_juc>()
                .HasKey(mr => new { mr.EchipaId, mr.JucatorId });

            modelBuilder.Entity<echipa_cont_juc>()
                        .HasOne<Echipa>(mr => mr.Echipa)
                        .WithMany(m3 => m3.echipa_Cont_Jucs)
                        .HasForeignKey(mr => mr.EchipaId);
            modelBuilder.Entity<echipa_cont_juc>()
                        .HasOne<Jucator>(mr => mr.Jucator)
                        .WithMany(m4 => m4.echipa_Cont_Jucs)
                        .HasForeignKey(mr => mr.JucatorId);
            modelBuilder.Entity<Antrenor>()
                .HasOne(m => m.Echipa)
                .WithOne(m6 => m6.Antrenor)
                .HasForeignKey<Echipa>(m6 => m6.AntrenorId);

            modelBuilder.Entity<Jucator>()
                .HasOne(m2 => m2.Impresar)
                .WithMany(m1 => m1.jucators);

            base.OnModelCreating(modelBuilder);
        }    
    }
}
