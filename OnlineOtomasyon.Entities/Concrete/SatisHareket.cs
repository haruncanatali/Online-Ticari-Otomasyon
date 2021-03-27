using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class SatisHareket:IEntity
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }

        public int UrunId { get; set; }
        public int MusteriId { get; set; }
        public int PersonelId { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
