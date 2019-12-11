using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class SotrudnicRepository
    {
        private BankEntities db;
        public SotrudnicRepository(BankEntities context)
        {
            db = context;
        }        
        public Sotrudnic GetItem(int id)
        {
            return db.Sotrudnic.Find(id);
        }
        public List<Sotrudnic> GetList()
        {
            return db.Sotrudnic.ToList();
        }
        public void ADD(Sotrudnic sotrudnic)
        {
            db.Sotrudnic.Add(sotrudnic);
        }
        public void UPD(Sotrudnic sotrudnic)
        {
            Sotrudnic s = db.Sotrudnic.Find(sotrudnic.ID);
            s.FIO = sotrudnic.FIO;
            s.Dolgnost = sotrudnic.Dolgnost;
            s.Login = sotrudnic.Login;
            s.Paswoorld = sotrudnic.Paswoorld;
        }
    }
}
