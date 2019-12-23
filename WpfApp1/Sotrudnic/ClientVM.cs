using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.Sotrudnic
{
    class ClientVM
    {
        int ID;
        ClientWindowVM window;
        Bank bank;
        ObservableCollection<Client> clients { get; set; }
        public ClientVM(int id, ClientWindowVM window, Bank bank)
        {
            ID = id;
            this.bank = bank;
            this.window = window;
            clients = new ObservableCollection<Client>(bank.Client);
        }

    }
}
