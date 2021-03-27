using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Musteri:IEntity
    {
        public Musteri()
        {
            Faturalar = new List<Fatura>();
            SatisHareketleri = new List<SatisHareket>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<Fatura> Faturalar { get; set; }
        public virtual ICollection<SatisHareket> SatisHareketleri { get; set; }
    }
}
