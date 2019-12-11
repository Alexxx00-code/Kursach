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
            o.In_FK = operacii.In_FK;
            o.Out_FK = operacii.Out_FK;
            o.Sotrudnic_FK = operacii.Sotrudnic_FK;
            o.Status_FK = operacii.Status_FK;
            o.Sum_In = operacii.Sum_In;
            o.Sum_Out = operacii.Sum_Out;
            o.Tip_operazii_FK = operacii.Tip_operazii_FK;
            o.Vneshcniy_Nscheta = operacii.Vneshcniy_Nscheta;
        }
    }
}
