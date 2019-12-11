using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class StatusBLL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public StatusBLL(Status status)
        {
            ID = status.ID;
            Name = status.Name;
        }
    }
}
