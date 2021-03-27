using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Urun:IEntity
    {

        public Urun()
        {
            FaturaKalemler = new List<FaturaKalem>();
            SatisHareketleri = new List<SatisHareket>();
        }

        public int Id { get; set; }
        public string Ad { get; set; }
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; } // kritik seviye kontrolü
        public string Gorsel { get; set; }

        public int KategoriId { get; set; } //foreign key

        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<FaturaKalem> FaturaKalemler { get; set; }
        public virtual ICollection<SatisHareket> SatisHareketleri { get; set; }
    }
}
