using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1.Clientu
{
    class SchetVM : Controler
    {
        ClientWindow window;
        
        public ObservableCollection<Schet> schets { get; set; }        
        public ObservableCollection<Operacii> operaciis { get; set; }
        private Client user;

        BankEntities bd;
        int ID;
        public SchetVM(int id, ClientWindow window):base(id,window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            schets = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog == null)&&(i.Status==true)));            
            
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
                        window.Page.Content = new New_Schet(ID, window);
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
                        if(n==1)
                            schets.Remove(Selected);
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
