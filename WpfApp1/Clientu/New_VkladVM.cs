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
    class New_VkladVM : Controler
    {
        
        int ID;
        ClientWindow window;
        private Client user;
        public ObservableCollection<Prog> Program { get; set; }
        BankEntities bd;
        public ObservableCollection<Valute> Valutes { get; set; }
        public ObservableCollection<Schet> Schets { get; set; }

        public New_VkladVM(int id, ClientWindow window) : base(id, window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            this.window = window;            
            Program = new ObservableCollection<Prog>(bd.Prog.Where(i=>i.Tip_FK==2));
            Valutes = new ObservableCollection<Valute>(bd.Valute);
            Schets = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog == null) && (i.Status == true)));
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
        Prog selectedProgram;
        public Prog SelectedProgram
        {
            get { return selectedProgram; }
            set
            {
                selectedProgram = value;
                OnPropertyChanged("SelectedProgram");
            }
        }
        Schet selectedSchet;
        public Schet SelectedSchet
        {
            get { return selectedSchet; }
            set
            {
                selectedSchet = value;
                OnPropertyChanged("SelectedSchet");
            }
        }
        decimal sum1 = 0;
        public decimal Sum1
        {
            get { return sum1; }
            set
            {
                try
                {
                    sum1 = value;
                    if (SelectedSchet.Valute_FK != SelectedValute.ID)
                        sum1 = value - value * (decimal)SelectedSchet.Valute.Otnoshenie_k_rub_prod / (decimal)SelectedValute.Otnoshenie_k_rub_pok;

                    OnPropertyChanged("SumOut");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                        if (SelectedSchet.Sum - Sum1 > 0)
                        {
                            TransferManedger.Create_Vklad(user, SelectedValute, SelectedProgram, Sum1, SelectedSchet, bd);
                            window.Page.Content = new VkladV(ID, window);
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
    }
}
