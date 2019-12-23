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
    class PerevodVM : Base
    {
        ClientWindowVM window;        
        public ObservableCollection<Schet> schets_out { get; set; }
        public ObservableCollection<Schet> schets_in { get; set; }
        private Client user;
        Bank bd;
        int ID;
        public PerevodVM(int id, ClientWindowVM window, Bank bank)
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            schets_out = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Status == true)&&((i.Prog==null)||(i.Prog.Tip.Name == "Вклад"))));
            schets_in = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Status == true) && ((i.Prog == null) || (i.Prog.Tip.Name == "Кредит"))));
            this.window = window;
        }
        public PerevodVM(int id, ClientWindowVM window,Schet schet, Bank bank) 
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            schets_out = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Status == true) && ((i.Prog == null) || (i.Prog.Tip.Name == "Вклад"))));
            schets_in = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Status == true) && ((i.Prog == null) || (i.Prog.Tip.Name == "Кредит"))));
            this.window = window;
        }
        bool select_vnschet = false;
        public bool Select_vnschet
        {
            get { return select_vnschet; }
            set
            {
                select_vnschet = value;
                OnPropertyChanged("Select_vnschet");
            }
        }

        bool select_vnbank = false;
        public bool Select_vnbank
        {
            get { return select_vnbank; }
            set
            {
                select_vnbank = value;
                OnPropertyChanged("Select_vnbank");
            }
        }

        int? schet_vibr;
        public int? Schet_vibr
        {
            get { return schet_vibr; }
            set
            {
                schet_vibr = value;                
                SelectedIn = null;
                OnPropertyChanged("Schet_vibr");                
            }
        }

        Schet selectedOut;
        public Schet SelectedOut
        {
            get { return selectedOut; }
            set
            {               
                selectedOut = value;
                if (value.Prog.Tip.Name == "Вклад")
                {
                    SumOut = (decimal)value.Sum;
                }
                OnPropertyChanged("SelectedOut");             
            }
        }

        Schet selectedIn;
        public Schet SelectedIn
        {
            get { return selectedIn; }
            set
            {
                Select_vnschet = false;
                Select_vnbank = false;
                selectedIn = value;
                OnPropertyChanged("SelectedIn");
            }
        }

        decimal Sum=0;
        public decimal SumOut
        {
            get { return Sum; }
            set
            {
                try
                {
                    Sum = value;
                    if (SelectedOut.Prog.Tip.Name == "Вклад")   
                    {
                        Sum = (decimal)SelectedOut.Sum;
                    }

                    if (selectedOut.ValuteID != selectedIn.ValuteID)
                        SumIn = value * (decimal)selectedIn.Valute.Otnoshenie_k_rub_pok / (decimal)selectedOut.Valute.Otnoshenie_k_rub_prod-value ;
                    
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
                        if (SelectedOut != null)
                            if (SelectedOut.Sum - (SumOut + SumIn) >= 0)
                                if ((select_vnschet==false)&&(select_vnbank==false))
                                {
                                    if (SelectedIn != null)
                                    {
                                        if (SelectedOut.Prog.Tip.Name == "Вклад")
                                        {
                                            TransferManedger.Delete_Vklad(SelectedOut,SelectedIn,bd);
                                        }
                                        else
                                            if ((SelectedIn.Prog.Tip.Name == "Кредит")&&(SelectedIn.Sum+Sum>0))
                                            {
                                            TransferManedger.Delete_Kredit(SelectedOut, SelectedIn, bd);
                                            }
                                            else
                                               TransferManedger.Perevod_vnutri(SelectedOut, SelectedIn, SumOut, bd);
                                        UPD();
                                    }
                                    else
                                        MessageBox.Show("Не выбран счёт зачисления");
                                }
                                else
                                {
                                    if (schet_vibr!=null)
                                    {
                                        if (select_vnschet == false)
                                        {
                                            TransferManedger.Perevod_vneshniy_Bank(SelectedOut, (int)schet_vibr, SumOut, bd);
                                            UPD();
                                        }
                                        else
                                        {
                                            TransferManedger.Perevod_vneshniy_Schet(SelectedOut, (int)schet_vibr, SumOut, bd);
                                            UPD();
                                        }
                                    }
                                    else
                                        MessageBox.Show("Введите номер счета");
                                }
                            else
                                MessageBox.Show("Не хватает средств");
                        else
                            MessageBox.Show("Не выбран счёт, с которого производится снятие");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        /*
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
        }*/
        public void UPD()
        {
            schets_in.Clear();
            schets_out.Clear();
            foreach (Schet schet in user.Schet)
            {
                schets_in.Add(schet);
                schets_out.Add(schet);
            }
            SumIn = 0;
            SumOut = 0;
            SelectedIn = null;
            SelectedOut = null;
            Schet_vibr = null;
            Select_vnbank = false;
            Select_vnschet = false;

        }
    }
}


