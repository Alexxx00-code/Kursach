using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Tip_operRepository
    {
        private BankEntities db;
        public Tip_operRepository(BankEntities context)
        {
            db = context;
        }
        public Tip_operacii GetItem(int id)
        {
            return db.Tip_operacii.Find(id);
        }
        public List<Tip_operacii> GetList()
        {
            return db.Tip_operacii.ToList();
        }

    }
}
