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
    public class MusteriMap:EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Ad).HasMaxLength(30).IsRequired();
            this.Property(c => c.Soyad).HasMaxLength(30).IsRequired();
            this.Property(c => c.Mail).HasMaxLength(80).IsRequired();
            this.Property(c => c.Telefon).HasMaxLength(20).IsRequired();
            this.Property(c => c.Adres).HasMaxLength(250).IsRequired();

            this.ToTable("Musteri");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Ad).HasColumnName("Ad");
            this.Property(c => c.Soyad).HasColumnName("Soyad");
            this.Property(c => c.Mail).HasColumnName("Mail");
            this.Property(c => c.Telefon).HasColumnName("Telefon");
            this.Property(c => c.Adres).HasColumnName("Adres");

        }
    }
}
