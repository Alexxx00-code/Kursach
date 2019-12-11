using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ValuteRepository
    {
        private BankEntities db;
        public ValuteRepository(BankEntities context)
        {
            db = context;
        }
        public Valute GetItem(int id)
        {
            return db.Valute.Find(id);
        }
        public List<Valute> GetList()
        {
            return db.Valute.ToList();
        }
        public void ADD(Valute valute)
        {            
            db.Valute.Add(valute);
        }
        public void UPD(Valute valute)
        {
            Valute v = db.Valute.Find(valute.ID);
            v.Name = valute.Name;
            v.Otnoshenie_k_rub_pok = valute.Otnoshenie_k_rub_pok;
            v.Otnoshenie_k_rub_prod = valute.Otnoshenie_k_rub_prod;
        }
    }
}
