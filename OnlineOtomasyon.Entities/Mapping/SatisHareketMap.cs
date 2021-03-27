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
    public class SatisHareketMap:EntityTypeConfiguration<SatisHareket>
    {
        public SatisHareketMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Tarih).IsRequired();
            this.Property(c => c.Adet).IsRequired();
            this.Property(c => c.Fiyat).HasPrecision(18,2).IsRequired();
            this.Property(c => c.ToplamTutar).HasPrecision(18, 2).IsRequired();
            this.Property(c => c.UrunId).IsRequired();
            this.Property(c => c.PersonelId).IsRequired();
            this.Property(c => c.MusteriId).IsRequired();

            this.ToTable("SatisHareket");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Tarih).HasColumnName("Tarih");
            this.Property(c => c.Adet).HasColumnName("Adet");
            this.Property(c => c.Fiyat).HasColumnName("Fiyat");
            this.Property(c => c.ToplamTutar).HasColumnName("ToplamTutar");
            this.Property(c => c.UrunId).HasColumnName("UrunId");
            this.Property(c => c.PersonelId).HasColumnName("PersonelId");
            this.Property(c => c.MusteriId).HasColumnName("MusteriId");

        }
    }
}
