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
    public class KategoriMap:EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.KategoriAdi).HasMaxLength(100).IsRequired();

            this.ToTable("Kategori");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.KategoriAdi).HasColumnName("KategoriAdi");
        }
    }
}
