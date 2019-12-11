using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class VkladBLL : SchetBLL
    {
        public int Nschet { get; set; }
        public System.DateTime Data_sozd { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<int> Prog_FK { get; set; }
        public string Program { get; set; }
        public int Valute_FK { get; set; }
        public string Valute { get; set; }
        public int Client_FK { get; set; }
        public VkladBLL(Schet schet)
        {
            Nschet = schet.Nschet;
            Data_sozd = schet.Data_sozd;
            Sum = schet.Sum;
            Prog_FK = schet.Prog_FK;
            Valute_FK = schet.Valute_FK;
            Client_FK = schet.Client_FK;
        }
        public VkladBLL(Schet schet, List<ValuteBLL> valutes, List<ProgramBLL> programs)
        {
            Nschet = schet.Nschet;
            Data_sozd = schet.Data_sozd;
            Prog_FK = schet.Prog_FK;
            Sum = schet.Sum;
            Valute_FK = schet.Valute_FK;
            Client_FK = schet.Client_FK;
            Valute = valutes.Where(i => i.ID == Valute_FK).FirstOrDefault().Name;
            Program = programs.Where(i => i.ID == Prog_FK).FirstOrDefault().Name;
        }
    }
}

