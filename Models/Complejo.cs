using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiProyecto
{
    public class Complejo
    {
        [Key]
        public int idComplejo { get; set; }
        public string nombre { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
        public int cantCanchas { get; set; }

        public class Map
        {
            public Map(EntityTypeBuilder<Complejo> ebComplejo)
            {
                ebComplejo.HasKey(x => x.idComplejo);
                ebComplejo.Property(x => x.nombre).HasColumnName("Nombre").HasMaxLength(20);
                ebComplejo.Property(x => x.latitud).HasColumnName("Latitud").HasColumnType("decimal");
                ebComplejo.Property(x => x.longitud).HasColumnName("Longitud").HasColumnType("decimal");
                ebComplejo.Property(x => x.cantCanchas).HasColumnName("CantidadDeCanchas").HasColumnType("int");
            }
        }

    }
}