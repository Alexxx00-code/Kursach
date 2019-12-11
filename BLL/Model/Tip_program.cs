using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Model
{
    public class Tip_program
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Tip_program(Tip tip_Program)
        {
            ID = tip_Program.ID;
            Name = tip_Program.Name;
        }
    }
}
