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
using WpfApp1;

namespace WpfApp1.Clientu
{
    class New_SchetVM : Controler
    {
        
        int ID;
        ClientWindow window;
        private Client user;
        public ObservableCollection<Valute> Valutes { get; set; }
        BankEntities bd;

        public New_SchetVM(int id,ClientWindow window): base(id,window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            this.window = window;

            Valutes = new ObservableCollection<Valute>(bd.Valute);
        }
        
        public RelayCommand OK
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        TransferManedger.Create_Schet(user, SelectedValute,bd);
                        window.Page.Content = new SchetV(ID, window);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Cansel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.Page.Content = new SchetV(ID, window);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        Valute selectedValute;
        public Valute SelectedValute
        {
            get { return selectedValute; }
            set
            {
                selectedValute = value;
                OnPropertyChanged("SelectedValute");
            }
        }
    }
}
