using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Model
{
    public class Tip_operacii
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Tip_operacii(Tip_operacii tip_Operacii)
        {
            ID = tip_Operacii.ID;
            Name = tip_Operacii.Name;
        }
    }
}
