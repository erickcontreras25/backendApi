using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiProyecto.Models
{
    public class Cancha
    {
        [Key]
        public int idCancha { get; set; }
        public int precio { get; set; }
        public bool estado { get; set; }
        public int idComplejo { get; set; }
        public Complejo complejo { get; set; }


        public class Map
        {
            public Map(EntityTypeBuilder<Cancha> ebCancha)
            {
                ebCancha.HasKey(x => x.idCancha);
                ebCancha.Property(x => x.precio).HasColumnName("Precio").HasColumnType("int");
                ebCancha.Property(x => x.estado).HasColumnName("EstadoCancha").HasColumnType("decimal");
                ebCancha.Property(x => x.idComplejo).HasColumnName("idComplejo").HasColumnType("int");
                ebCancha.HasOne(x => x.complejo);
            }
        }
    }
}