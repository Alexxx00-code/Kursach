using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ClientRepository
    {
        private BankEntities db;
        public ClientRepository(BankEntities context)
        {
            db = context;
        }
        public Client GetItem(int id)
        {
            return db.Client.Find(id);
        }
        public List<Client> GetList()
        {
            return db.Client.ToList();
        }
        public void ADD(Client client)
        {
            db.Client.Add(client);
        }
        public void UPD(Client client)
        {
            Client c = db.Client.Find(client.ID);
            c.FIO = client.FIO;
            c.Data_rog = client.Data_rog;
            c.Npasporta = client.Npasporta;
            c.login = client.login;
            c.pasworld = client.pasworld;
            c.Serpasporta = client.Serpasporta;
        }
    }
}
