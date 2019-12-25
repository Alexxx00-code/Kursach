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
    class New_VkladVM : Base
    {        
        int ID;
        ClientWindowVM window;
        private Client user;
        public ObservableCollection<Prog> Program { get; set; }
        Bank bd;
        public ObservableCollection<Valute> Valutes { get; set; }
        public ObservableCollection<Schet> Schets { get; set; }

        public New_VkladVM(int id, ClientWindowVM window,Bank bank) 
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            this.window = window;            
            Program = new ObservableCollection<Prog>(bd.Prog.Where(i=>i.TipID==1));
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
        decimal sum = 0;
        decimal sum1 = 0;
        public decimal Sum
        {
            get { return sum1; }
            set
            {
                try
                {
                    sum = value;
                    if (SelectedSchet.ValuteID != SelectedValute.ID)
                        sum1 = value * (decimal)SelectedSchet.Valute.Otnoshenie_k_rub_prod / (decimal)SelectedValute.Otnoshenie_k_rub_pok;

                    OnPropertyChanged("Sum");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
                        window.vklad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
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
                        if (SelectedSchet.Sum - Sum > 0)
                        {
                            if (SelectedProgram.min_Sum <= Sum)
                            {
                                
                                    TransferManedger.Create_Vklad(user, SelectedValute, SelectedProgram, Sum, SelectedSchet, bd);
                                    window.vklad();
                                
                            }
                            else
                                MessageBox.Show("Не достаточная сумма");
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
