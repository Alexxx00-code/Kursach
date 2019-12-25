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
    class KreditVM
    {
        ClientWindowVM window;
       
       
        public ObservableCollection<Schet> kredits { get; set; }
       
        private Client user;
        
        Bank bd;
        int ID;
        public KreditVM(int id, ClientWindowVM window,Bank bank)
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            kredits = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog != null) && (i.Prog.Tip.Name == "Кредит")&&(i.Status==true)));
            this.window = window;
            
        }
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.window.Page.Content = new New_kreditV(ID, window, bd);
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
            kredits.Clear();
            foreach (Schet schet in user.Schet.Where(i => (i.Prog != null) && (i.Prog.Tip.Name == "Кредит") && (i.Status == true)))
            {
                kredits.Add(schet);
            }
        }
    }
}
