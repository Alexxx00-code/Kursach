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
        
        bool select_vnschet = false;
        public bool Select_vnschet
        {
            get { return select_vnschet; }
            set
            {
                select_vnschet = value;
                if (value == true)
                {
                    select_vnbank = false;
                    SelectedIn = null;
                }
                OnPropertyChanged("Select_vnbank");
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
                if (value == true)
                {
                    select_vnschet = false;
                    SelectedIn = null;
                }
                OnPropertyChanged("Select_vnbank");
                OnPropertyChanged("Select_vnschet");
            }
        }

        int? schet_vibr;
        public int? Schet_vibr
        {
            get { return schet_vibr; }
            set
            {
                schet_vibr = value;                
                
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

                if((value!=null) &&(value.Prog!=null))
                if (value.Prog.Tip.Name == "Вклад")
                {
                    SumOut = (decimal)value.Sum;
                }
                if ((SelectedOut != null) && (selectedIn != null) && (selectedOut.ValuteID != selectedIn.ValuteID))
                    SumIn = Sum - Sum * (decimal)selectedIn.Valute.Otnoshenie_k_rub_pok / (decimal)selectedOut.Valute.Otnoshenie_k_rub_prod;

                OnPropertyChanged("SelectedOut");             
            }
        }

        Schet selectedIn;
        public Schet SelectedIn
        {
            get { return selectedIn; }
            set
            {
                if (value != null)
                {
                    Select_vnschet = false;
                    Select_vnbank = false;
                }
                selectedIn = value;
                if ((SelectedOut != null) && (selectedIn != null) && (selectedOut.ValuteID != selectedIn.ValuteID))
                    SumIn = Sum - Sum * (decimal)selectedIn.Valute.Otnoshenie_k_rub_pok / (decimal)selectedOut.Valute.Otnoshenie_k_rub_prod;

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
                    if ((SelectedOut!=null) &&(SelectedOut.Prog!=null) &&(SelectedOut.Prog.Tip.Name == "Вклад"))
                    {
                        Sum = (decimal)SelectedOut.Sum;
                    }

                    if ((SelectedOut != null) && (selectedIn != null) && (selectedOut.ValuteID != selectedIn.ValuteID))
                        SumIn =Sum- Sum * (decimal)selectedIn.Valute.Otnoshenie_k_rub_pok / (decimal)selectedOut.Valute.Otnoshenie_k_rub_prod ;
                    
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
                            if (SelectedOut.Prog != null)
                            if ((SelectedOut.Prog.Tip.Name == "Вклад"))
                            {
                                Select_vnschet = false;
                                Select_vnbank = false;
                            }
                        if (SelectedOut != null)
                            if ((SelectedOut.Sum - (SumOut + SumIn) >= 0)|| ((SelectedOut.Prog != null) && (SelectedOut.Prog.Tip.Name == "Вклад")))
                                if ((select_vnschet==false)&&(select_vnbank==false))
                                {
                                    if (SelectedIn != null)
                                    {

                                        if ((SelectedOut.Prog!=null) &&(SelectedOut.Prog.Tip.Name == "Вклад"))
                                        {
                                            if ((SelectedIn.Prog == null)||((SelectedIn.Prog!=null) &&(SelectedIn.Prog.Tip.Name != "Кредит")))
                                                TransferManedger.Delete_Vklad(SelectedOut,SelectedIn,bd);
                                            else
                                                MessageBox.Show("Выберете другой счёт зачисления");
                                        }
                                        else
                                            if ((SelectedIn.Prog.Tip.Name == "Кредит")&&(SelectedIn.Sum+Sum+SumIn>0))
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
                                            int t =TransferManedger.Perevod_vneshniy_Schet(SelectedOut, (int)schet_vibr, SumOut, bd);
                                            if(t==0)
                                                MessageBox.Show("Такой счет не существует");
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
            foreach (Schet schet in user.Schet.Where(i => (i.Status == true) && ((i.Prog == null) || (i.Prog.Tip.Name == "Вклад"))))
            {
                
                schets_out.Add(schet);
            }
            foreach (Schet schet in user.Schet.Where(i => (i.Status == true) && ((i.Prog == null) || (i.Prog.Tip.Name == "Кредит"))))
            {

                schets_in.Add(schet);
            }
            SumIn = 0;
            SumOut = 0;
            selectedIn = null;
            selectedOut = null;
            Schet_vibr = null;
            Select_vnbank = false;
            Select_vnschet = false;

        }
    }
}


