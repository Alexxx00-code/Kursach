using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using WpfApp1;

namespace WpfApp1.Sotrudnic
{
    class ClientVM : Base
    {
        int ID;
        SotrudnicWindowVM window;
        Bank bank;
        public ObservableCollection<Client> clients { get; set; }
        public Client selectedClient;
        Client SelectedClient
        {
            get {
                return selectedClient;
                    }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public ClientVM(int id, SotrudnicWindowVM window, Bank bank)
        {
            ID = id;
            this.bank = bank;
            this.window = window;
            clients = new ObservableCollection<Client>(bank.Client);
        }
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.window.Page.Content = new NewClientV(ID, window, bank);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Change
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.window.Page.Content = new NewClientV(ID, window, bank, SelectedClient);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public void UPD()
        {
            clients.Clear();
            foreach (Client client in bank.Client)
            {
                clients.Add(client);
            }
        }
    }
}
