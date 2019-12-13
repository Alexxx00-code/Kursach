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
    class PerevodVM : Controler
    {
        ClientWindow window;


        public ObservableCollection<Schet> schets_out { get; set; }
        public ObservableCollection<Schet> schets_in { get; set; }

        private Client user;

        BankEntities bd;
        int ID;
        public PerevodVM(int id, ClientWindow window):base(id,window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            schets_out = new ObservableCollection<Schet>(user.Schet.Where(i => i.Status == true));
            schets_in = new ObservableCollection<Schet>(user.Schet.Where(i => i.Status == true));
            this.window = window;
        }
        public PerevodVM(int id, ClientWindow window,Schet schet) : base(id, window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            schets_out = new ObservableCollection<Schet>(user.Schet.Where(i=>i.Status == true));
            schets_in = new ObservableCollection<Schet>(user.Schet.Where(i => i.Status == true));
            this.window = window;

        }
     
        public RelayCommand Changed
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        Schet selectedOut;
        public Schet SelectedOut
        {
            get { return selectedOut; }
            set
            {
                if (SelectedIn != value)
                {
                    selectedOut = value;
                    OnPropertyChanged("SelectedOut");
                }
            }
        }
        Schet selectedIn;
        public Schet SelectedIn
        {
            get { return selectedIn; }
            set
            {
                if (SelectedOut != value)
                {
                    selectedIn = value;
                    OnPropertyChanged("SelectedIn");
                }
            }
        }
        decimal sumOut=0;
        public decimal SumOut
        {
            get { return sumOut; }
            set
            {
                try
                {
                    sumOut = value;
                    if (selectedOut.Valute_FK != selectedIn.Valute_FK)
                        SumIn = value-value * (decimal)selectedIn.Valute.Otnoshenie_k_rub_prod / (decimal)selectedIn.Valute.Otnoshenie_k_rub_pok ;
                    
                    OnPropertyChanged("SumOut");
                }
                catch (Exception ex)
                {
                    
                }                
            }
        }
        decimal sumIn=0;
        public decimal SumIn
        {
            get { return sumIn; }
            set
            {
                
                sumIn = value;
                OnPropertyChanged("SumIn");
            }
        }
        public RelayCommand OK
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        if (SelectedOut.Sum - (SumOut + SumIn) > 0)
                        {
                            TransferManedger.Perevod_vnutri(SelectedOut, SelectedIn, SumOut, bd);
                            window.Page.Content = new Perevod(ID, window);
                        }
                        else
                            MessageBox.Show("Не хватает средств");
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
    }
}


