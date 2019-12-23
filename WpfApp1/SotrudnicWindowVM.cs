using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;
using WpfApp1.Sotrudnic;

namespace WpfApp1
{
    class SotrudnicWindowVM 
    {
        Bank bd;
        Model.Sotrudnic sotrudnic;
        int ID;
        ClientV clientV;
        SotrudnicWindow window;
        public SotrudnicWindowVM(int id, SotrudnicWindow window)
        {
            bd = new Bank();
            ID = id;
            sotrudnic = bd.Sotrudnic.Find(ID);
            this.window = window;
        }
        public RelayCommand ClientViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        client();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public void client()
        {
            if (clientV == null)
                clientV = new ClientV(ID, this, bd);
            clientV.UPD();
            window.Page.Content = clientV;
        }
    }
}
