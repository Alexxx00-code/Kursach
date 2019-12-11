using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class SchetBLL
    {
        public int Nschet { get; set; }
        public System.DateTime Data_sozd { get; set; }
        public Nullable<decimal> Sum { get; set; }        
        public int Valute_FK { get; set; }
        public string Valute { get; set; }
        public int Client_FK { get; set; }
        public SchetBLL(Schet schet)
        {
            Nschet = schet.Nschet;
            Data_sozd = schet.Data_sozd;
            Sum = schet.Sum;            
            Valute_FK = schet.Valute_FK;
            Client_FK = schet.Client_FK;
        }
        public SchetBLL(Schet schet,List<ValuteBLL> valutes)
        {
            Nschet = schet.Nschet;
            Data_sozd = schet.Data_sozd;
            Sum = schet.Sum;
            Valute_FK = schet.Valute_FK;
            Client_FK = schet.Client_FK;
            Valute = valutes.Where(i => i.ID == Valute_FK).FirstOrDefault().Name;
        }
        public SchetBLL()
        { }
    }
}
