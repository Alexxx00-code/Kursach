using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class ValuteBLL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Otnoshenie_k_rub_prod { get; set; }
        public double Otnoshenie_k_rub_pok { get; set; }
        public ValuteBLL(Valute valute)
        {
            ID = valute.ID;
            Name = valute.Name;
            Otnoshenie_k_rub_prod = valute.Otnoshenie_k_rub_prod;
            Otnoshenie_k_rub_pok = valute.Otnoshenie_k_rub_pok;
        }
    }
}
