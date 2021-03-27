using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Fatura:IEntity
    {

        public Fatura()
        {
            FaturaKalemler = new List<FaturaKalem>();
        }

        public int Id { get; set; }
        public string SeriNo { get; set; }
        public string SiraNo { get; set; }
        public DateTime Tarih { get; set; }
        public string VergiDairesi { get; set; }

        public int PersonelId { get; set; } // foreign key
        public int MusteriId { get; set; } //  foreign key

        public virtual Personel Personel { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual ICollection<FaturaKalem> FaturaKalemler { get; set; }

    }
}
