using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1.Clientu
{
    class SchetVM : Base
    {
        ClientWindowVM window;
        
        public ObservableCollection<Schet> schets { get; set; }        
        
        private Client user;

        Bank bd;
        int ID;
        public SchetVM(int id, ClientWindowVM window, Bank bank)
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            
            schets = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog == null)&&(i.Status==true)));
            bd = bank;
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
                        window.window.Page.Content = new New_SchetV(ID, window,bd);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Del
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        int n=TransferManedger.Delete_Schet(Selected,bd);
                        if(n>0)
                            schets.Remove(Selected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }


        }
        Schet selected;
        public Schet Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public void UPD()
        {
            schets.Clear();
            foreach(Schet schet in user.Schet.Where(i => (i.Prog == null) && (i.Status == true)))
            {
                schets.Add(schet);
            }
        }
    }
}
