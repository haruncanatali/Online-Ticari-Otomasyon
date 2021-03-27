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
    public class AdminMap:EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.KullaniciAdi).HasMaxLength(10).IsRequired();
            this.Property(c => c.Sifre).HasMaxLength(10).IsRequired();
            this.Property(c => c.Yetki).HasMaxLength(50).IsRequired();

            this.ToTable("Admin");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.KullaniciAdi).HasColumnName("KullaniciAdi");
            this.Property(c => c.Sifre).HasColumnName("Sifre");
            this.Property(c => c.Yetki).HasColumnName("Yetki");
        }
    }
}
