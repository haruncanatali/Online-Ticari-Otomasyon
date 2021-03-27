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
    public class UrunMap:EntityTypeConfiguration<Urun>
    {
        public UrunMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.Ad).HasMaxLength(100).IsRequired();
            this.Property(c => c.Marka).HasMaxLength(100).IsRequired();
            this.Property(c => c.Stok).IsRequired();
            this.Property(c => c.AlisFiyat).HasPrecision(18, 2).IsRequired();
            this.Property(c => c.SatisFiyat).HasPrecision(18, 2).IsRequired();
            this.Property(c => c.Durum).IsOptional();
            this.Property(c => c.Gorsel).IsOptional();
            this.Property(c => c.KategoriId).IsRequired();

            this.ToTable("Urun");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Ad).HasColumnName("Ad");
            this.Property(c => c.Marka).HasColumnName("Marka");
            this.Property(c => c.Stok).HasColumnName("Stok");
            this.Property(c => c.AlisFiyat).HasColumnName("AlisFiyat");
            this.Property(c => c.SatisFiyat).HasColumnName("SatisFiyat");
            this.Property(c => c.Durum).HasColumnName("Durum");
            this.Property(c => c.Gorsel).HasColumnName("Gorsel");
            this.Property(c => c.KategoriId).HasColumnName("KategoriId");
        }
    }
}
