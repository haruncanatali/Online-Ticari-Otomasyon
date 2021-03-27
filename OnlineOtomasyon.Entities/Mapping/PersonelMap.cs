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
    public class PersonelMap:EntityTypeConfiguration<Personel>
    {
        public PersonelMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Ad).HasMaxLength(30).IsRequired();
            this.Property(c => c.Soyad).HasMaxLength(30).IsRequired();
            this.Property(c => c.Gorsel).HasMaxLength(250).IsOptional();
            this.Property(c => c.DepartmanId).IsRequired();

            this.ToTable("Personel");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Ad).HasColumnName("Ad");
            this.Property(c => c.Soyad).HasColumnName("Soyad");
            this.Property(c => c.Gorsel).HasColumnName("Gorsel");
            this.Property(c => c.DepartmanId).HasColumnName("DepartmanId");
        }
    }
}
