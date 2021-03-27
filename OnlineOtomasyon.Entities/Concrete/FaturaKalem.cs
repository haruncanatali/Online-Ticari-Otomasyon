using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class FaturaKalem:IEntity
    {
        public int Id { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public int FaturaId { get; set; }
        public int UrunId { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}
