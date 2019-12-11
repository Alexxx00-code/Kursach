using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SchetRepository
    {
        private BankEntities db;
        public SchetRepository(BankEntities context)
        {
            db = context;
        }
        public Schet GetItem(int id)
        {
            return db.Schet.Find(id);
        }
        public List<Schet> GetList()
        {
            return db.Schet.ToList().Where(i => i.Prog == null).ToList();
        }
        public void ADD(Schet schet)
        {
            db.Schet.Add(schet);
        }
        public void UPD(Schet schet)
        {
            Schet s = db.Schet.Find(schet.Nschet);
            s.Client_FK = schet.Client_FK;
            s.Data_sozd = schet.Data_sozd;
            s.Sum = schet.Sum;
            s.Valute_FK = schet.Valute_FK;
            s.Prog_FK = schet.Prog_FK;
        }
    }
}
