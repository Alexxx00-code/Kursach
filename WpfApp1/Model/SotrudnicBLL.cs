using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace WpfApp1.Model
{
    public class SotrudnicBLL
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Dolgnost { get; set; }
        public string Login { get; set; }
        public string Paswoorld { get; set; }
        public SotrudnicBLL(DAL.Sotrudnic sotrudnic)
        {
            ID = sotrudnic.ID;
            FIO = sotrudnic.FIO;
            Dolgnost = sotrudnic.Dolgnost;
            Login = sotrudnic.Login;
            Paswoorld = sotrudnic.Paswoorld;
        }
    }
}
