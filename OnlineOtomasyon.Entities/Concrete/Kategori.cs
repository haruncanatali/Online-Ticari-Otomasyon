using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Kategori:IEntity
    {
        public Kategori()
        {
            Urunler = new List<Urun>();
        }
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public ICollection<Urun> Urunler { get; set; }
    }
}
