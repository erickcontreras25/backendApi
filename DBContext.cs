using apiProyecto.Models;
using Microsoft.EntityFrameworkCore;

namespace  apiProyecto
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions opciones): base(opciones)
        {
            
        }
        public virtual DbSet<Cancha> Canchas { get; set; }
        public virtual DbSet<Complejo> Complejo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelB)
        {
            new Cancha.Map(modelB.Entity<Cancha>());
            new Complejo.Map(modelB.Entity<Complejo>());
            base.OnModelCreating(modelB);
        }
        
    }

}
