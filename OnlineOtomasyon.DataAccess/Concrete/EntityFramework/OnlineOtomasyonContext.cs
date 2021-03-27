using OnlineOtomasyon.Entities.Concrete;
using OnlineOtomasyon.Entities.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.DataAccess.Concrete.EntityFramework
{
    public class OnlineOtomasyonContext:DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
        public DbSet<Departman> Departman { get; set; }
        public DbSet<Fatura> Fatura { get; set; }
        public DbSet<FaturaKalem> FaturaKalem { get; set; }
        public DbSet<Gider> Gider { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<SatisHareket> SatisHareket { get; set; }
        public DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Relationships

            modelBuilder.Entity<Musteri>().HasMany(c => c.SatisHareketleri).WithRequired(c => c.Musteri).HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<Musteri>().HasMany(c => c.Faturalar).WithRequired(c => c.Musteri).HasForeignKey(c => c.MusteriId);

            modelBuilder.Entity<Departman>().HasMany(c => c.Personeller).WithRequired(c => c.Departman).HasForeignKey(c => c.DepartmanId);

            modelBuilder.Entity<Fatura>().HasMany(c => c.FaturaKalemler).WithRequired(c => c.Fatura).HasForeignKey(c => c.FaturaId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Kategori>().HasMany(c => c.Urunler).WithRequired(c => c.Kategori).HasForeignKey(c => c.KategoriId);

            modelBuilder.Entity<Musteri>().HasMany(c => c.Faturalar).WithRequired(c => c.Musteri).HasForeignKey(c => c.MusteriId);
            modelBuilder.Entity<Musteri>().HasMany(c => c.SatisHareketleri).WithRequired(c => c.Musteri).HasForeignKey(c => c.MusteriId);

            modelBuilder.Entity<Personel>().HasMany(c => c.Faturalar).WithRequired(c => c.Personel).HasForeignKey(c => c.PersonelId);
            modelBuilder.Entity<Personel>().HasMany(c => c.SatisHareketleri).WithRequired(c => c.Personel).HasForeignKey(c => c.PersonelId);

            modelBuilder.Entity<Urun>().HasMany(c => c.FaturaKalemler).WithRequired(c => c.Urun).HasForeignKey(c => c.UrunId);
            modelBuilder.Entity<Urun>().HasMany(c => c.SatisHareketleri).WithRequired(c => c.Urun).HasForeignKey(c => c.UrunId);


            //Mappings

            modelBuilder.Configurations.Add(new AdminMap());
            modelBuilder.Configurations.Add(new DepartmanMap());
            modelBuilder.Configurations.Add(new FaturaMap());
            modelBuilder.Configurations.Add(new FaturaKalemMap());
            modelBuilder.Configurations.Add(new GiderMap());
            modelBuilder.Configurations.Add(new KategoriMap());
            modelBuilder.Configurations.Add(new MusteriMap());
            modelBuilder.Configurations.Add(new PersonelMap());
            modelBuilder.Configurations.Add(new SatisHareketMap());
            modelBuilder.Configurations.Add(new UrunMap());
        }

    }
}
