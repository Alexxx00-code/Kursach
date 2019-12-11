using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class OperaciiBLL
    {
        public int ID { get; set; }
        public Nullable<decimal> Sum_In { get; set; }
        public Nullable<int> Out_FK { get; set; }
        public Nullable<int> In_FK { get; set; }
        public Nullable<int> Vneshcniy_Nscheta { get; set; }
        public Nullable<int> Tip_operazii_FK { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> Sotrudnic_FK { get; set; }
        public int Status_FK { get; set; }
        public Nullable<decimal> Sum_Out { get; set; }
        public OperaciiBLL(Operacii operacii)
        {
            ID = operacii.ID;
            Sum_In = operacii.Sum_In;
            Sum_Out = operacii.Sum_Out;
            Out_FK = operacii.Out_FK;
            In_FK = operacii.In_FK;
            Vneshcniy_Nscheta = operacii.Vneshcniy_Nscheta;
            Tip_operazii_FK = operacii.Tip_operazii_FK;
            Date = operacii.Date;
            Sotrudnic_FK = operacii.Sotrudnic_FK;
            Status_FK = operacii.Status_FK;
        }
    }
}
