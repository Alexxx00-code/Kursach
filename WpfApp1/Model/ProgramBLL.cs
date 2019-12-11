using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class ProgramBLL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Procent { get; set; }
        public int Tip_FK { get; set; }
        public int dlitel_day_min { get; set; }
        public int dlitel_day_max { get; set; }
        public decimal min_Sum { get; set; }
        public ProgramBLL(Prog prog)
        {
            ID = prog.ID;
            Name = prog.Name;
            Procent = prog.Procent;
            Tip_FK = prog.Tip_FK;
            dlitel_day_min = prog.dlitel_day_min;
            dlitel_day_max = prog.dlitel_day_max;
            min_Sum = prog.min_Sum;
        }
    }
}
