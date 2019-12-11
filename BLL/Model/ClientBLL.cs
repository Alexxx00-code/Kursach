using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Model
{
    public class ClientBLL
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public int Npasporta { get; set; }
        public int Serpasporta { get; set; }
        public System.DateTime Data_rog { get; set; }
        public string login { get; set; }
        public string pasworld { get; set; }
        public ClientBLL(Client client)
        {
            ID = client.ID;
            FIO = client.FIO;
            Npasporta = client.Npasporta;
            Serpasporta = client.Serpasporta;
            Data_rog = client.Data_rog;
            login = client.login;
            pasworld = client.pasworld;

        }
    }
}
