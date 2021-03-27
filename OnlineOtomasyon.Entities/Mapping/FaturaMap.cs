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
    public class FaturaMap:EntityTypeConfiguration<Fatura>
    {
        public FaturaMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.SeriNo).HasMaxLength(1).IsRequired();
            this.Property(c => c.SiraNo).HasMaxLength(10).IsRequired();
            this.Property(c => c.Tarih).IsRequired();
            this.Property(c => c.VergiDairesi).IsRequired().HasMaxLength(100);
            this.Property(c => c.PersonelId).IsRequired();
            this.Property(c => c.MusteriId).IsRequired();

            this.ToTable("Fatura");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.SeriNo).HasColumnName("SeriNo");
            this.Property(c => c.SiraNo).HasColumnName("SiraNo");
            this.Property(c => c.Tarih).HasColumnName("Tarih");
            this.Property(c => c.VergiDairesi).HasColumnName("VergiDairesi");
            this.Property(c => c.PersonelId).HasColumnName("PersonelId");
            this.Property(c => c.MusteriId).HasColumnName("MusteriId");

        }
    }
}
