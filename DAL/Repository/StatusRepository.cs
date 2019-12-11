using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StatusRepository
    {
        private BankEntities db;
        public StatusRepository(BankEntities context)
        {
            db = context;
        }
        public Status GetItem(int id)
        {
            return db.Status.Find(id);
        }
        public List<Status> GetList()
        {
            return db.Status.ToList();
        }
    }
}
