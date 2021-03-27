using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Personel:IEntity
    {
        public Personel()
        {
            Faturalar = new List<Fatura>();
            SatisHareketleri = new List<SatisHareket>();
        }
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Gorsel { get; set; }

        public int DepartmanId { get; set; }

        public virtual Departman Departman { get; set; }
        public virtual ICollection<Fatura> Faturalar { get; set; }
        public virtual ICollection<SatisHareket> SatisHareketleri { get; set; }
    }
}
