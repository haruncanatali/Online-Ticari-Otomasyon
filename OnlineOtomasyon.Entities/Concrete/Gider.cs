﻿using OnlineOtomasyon.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineOtomasyon.Entities.Concrete
{
    public class Gider:IEntity
    {
        public int Id { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}
