using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using DAL;
using System.Collections.ObjectModel;

namespace WpfApp1.Clientu
{
    class VkladVM
    {
        ClientWindow window;
        
       
        public ObservableCollection<Schet> vklads { get; set; }

        private Client user;
       
        BankEntities bd;
        int ID;
        public VkladVM(int id, ClientWindow window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            this.window = window;
            vklads = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog != null) && (i.Prog.Tip.Name == "Вклад")&& (i.Status == true)));
            
        }
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.Page.Content = new New_vklad(ID, window);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
    }
}
