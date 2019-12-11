using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Tip_progRepository
    {
        private BankEntities db;
        public Tip_progRepository(BankEntities context)
        {
            db = context;
        }
        public Tip GetItem(int id)
        {
            return db.Tip.Find(id);
        }
        public List<Tip> GetList()
        {
            return db.Tip.ToList();
        }
    }
}
