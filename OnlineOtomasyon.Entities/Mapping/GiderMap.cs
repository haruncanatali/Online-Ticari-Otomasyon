using OnlineOtomasyon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Mapping
{
    public class GiderMap:EntityTypeConfiguration<Gider>
    {
        public GiderMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Aciklama).HasMaxLength(1500).IsRequired();
            this.Property(c => c.Tarih).IsRequired();
            this.Property(c => c.Tutar).HasPrecision(18, 2).IsRequired();

            this.ToTable("Gider");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Aciklama).HasColumnName("Aciklama");
            this.Property(c => c.Tarih).HasColumnName("Tarih");
            this.Property(c => c.Tutar).HasColumnName("Tutar");
        }
    }
}
