using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OperaciiRepository
    {
        private BankEntities db;
        public OperaciiRepository(BankEntities context)
        {
            db = context;
        }
        public Operacii GetItem(int id)
        {
            return db.Operacii.Find(id);
        }
        public List<Operacii> GetList()
        {
            return db.Operacii.ToList();
        }
        public void ADD(Operacii operacii)
        {
            db.Operacii.Add(operacii);
        }
        public void UPD(Operacii operacii)
        {
            Operacii o = db.Operacii.Find(operacii.ID);
            o.Date = operacii.Date;
            o.InID = operacii.InID;
            o.OutID = operacii.OutID;
            o.SotrudnicID = operacii.SotrudnicID;
            o.StatusID = operacii.StatusID;
            o.Sum_In = operacii.Sum_In;
            o.Sum_Out = operacii.Sum_Out;
            o.Tip_operaziiID = operacii.Tip_operaziiID;
            o.Vneshcniy_Nscheta = operacii.Vneshcniy_Nscheta;
        }
    }
}
