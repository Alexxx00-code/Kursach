using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ProgramRepository
    {
        private BankEntities db;
        public ProgramRepository(BankEntities context)
        {
            db = context;
        }
        public Prog GetItem(int id)
        {
            return db.Prog.Find(id);
        }
        public List<Prog> GetList()
        {
            return db.Prog.ToList();
        }
        public void ADD(Prog prog)
        {
            db.Prog.Add(prog);
        }
        public void UPD(Prog prog)
        {
            Prog p = db.Prog.Find(prog.ID);
            p.min_Sum = prog.min_Sum;
            p.dlitel_day_min = prog.dlitel_day_min;
            p.dlitel_day_max = prog.dlitel_day_max;
            p.Name = prog.Name;
            p.Procent = prog.Procent;
            p.Tip_FK = p.Tip_FK;
        }
    }
}
