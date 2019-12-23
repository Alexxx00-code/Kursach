using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class NewClientVM : Base
    {
        SotrudnicWindowVM windowVM;
        Bank bank;
        int ID;
        Client client;
        bool add;
        public NewClientVM(int id,SotrudnicWindowVM windowVM, Bank bank)
        {
            add = true;
            ID = id;
            this.windowVM = windowVM;
            this.bank = bank;
            client = new Client();
        }
        public NewClientVM(int id, SotrudnicWindowVM windowVM, Bank bank,Client client)
        {
            add = false;
            ID = id;
            this.windowVM = windowVM;
            this.bank = bank;
            this.client = client;

        }
        public RelayCommand OK
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        if (add)
                        {
                            TransferManedger.Create_Client(client, ID, bank);
                            windowVM.client();
                        }
                        else
                        {
                            TransferManedger.UPD_Client(client, ID, bank);
                            windowVM.client();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
               
        public string FIO
        {
            get { return client.FIO; }
            set
            {
                client.FIO = value;
                OnPropertyChanged("FIO");
            }
        }
               
        public string Pasworld
        {
            get { return client.pasworld; }
            set
            {
                client.pasworld = value;
                OnPropertyChanged("Pasworld");
            }
        }
                
        public string Login
        {
            get { return client.login; }
            set
            {
                client.login = value;
                OnPropertyChanged("Login");
            }
        }
                
        public DateTime Date
        {
            get { return client.Data_rog; }
            set
            {
                client.Data_rog = value;
                OnPropertyChanged("Date");
            }
        }
                
        public int Seriy
        {
            get { return client.Serpasporta; }
            set
            {
                client.Serpasporta = value;
                OnPropertyChanged("Seriy");
            }
        }
        
        public int Nom
        {
            get { return client.Npasporta; }
            set
            {
                client.Npasporta = value;
                OnPropertyChanged("Nom");
            }
        }
    }
}
