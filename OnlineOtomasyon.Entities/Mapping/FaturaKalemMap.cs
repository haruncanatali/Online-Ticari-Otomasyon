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
    public class FaturaKalemMap:EntityTypeConfiguration<FaturaKalem>
    {
        public FaturaKalemMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Miktar).IsRequired();
            this.Property(c => c.BirimFiyat).HasPrecision(18, 2).IsRequired();
            this.Property(c => c.Tutar).HasPrecision(18, 2).IsRequired();
            this.Property(c => c.FaturaId).IsRequired();
            this.Property(c => c.UrunId).IsRequired();

            this.ToTable("FaturaKalem");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Miktar).HasColumnName("Miktar");
            this.Property(c => c.BirimFiyat).HasColumnName("BirimFiyat");
            this.Property(c => c.Tutar).HasColumnName("Tutar");
            this.Property(c => c.FaturaId).HasColumnName("FaturaId");
            this.Property(c => c.UrunId).HasColumnName("UrunId");

        }
    }
}
