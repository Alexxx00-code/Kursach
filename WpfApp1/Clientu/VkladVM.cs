using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1.Clientu
{
    class VkladVM : Base
    {
        ClientWindowVM window;
        
                                    
        public ObservableCollection<Schet> vklads { get; set; }

        private Client user;
       
        Bank bd;
        int ID;
        public VkladVM(int id, ClientWindowVM window, Bank bank)
        {
            bd = bank;
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
                        window.window.Page.Content = new New_vkladV(ID, window,bd);
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
            vklads.Clear();
            foreach (Schet schet in user.Schet.Where(i => (i.Prog != null) && (i.Prog.Tip.Name == "Вклад") && (i.Status == true)))
            {
                vklads.Add(schet);
            }
        }
    }
}
