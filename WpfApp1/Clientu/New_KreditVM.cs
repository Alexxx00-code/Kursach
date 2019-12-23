using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;
namespace WpfApp1.Clientu
{
    class New_KreditVM : Base
    {
        int ID;
        ClientWindowVM window;
        private Client user;
        Prog prog = new Prog();
        Bank bd;
        public ObservableCollection<Valute> Valutes { get; set; }
        public ObservableCollection<Schet> Schets { get; set; }

        public New_KreditVM(int id, ClientWindowVM window, Bank bank)
        {
            bd = bank;
            ID = id;
            user = bd.Client.Find(id);
            this.window = window;
            prog.Procent = bd.Prog.FirstOrDefault().Procent;
            prog.ID = 1;
            prog.TipID = bd.Tip.Where(i => i.Name == "Кредит").FirstOrDefault().ID;
            Valutes = new ObservableCollection<Valute>(bd.Valute);
            Schets = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog == null) && (i.Status == true)));
            proc = bd.Prog.FirstOrDefault().Procent;

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

        DateTime date = DateTime.Now.AddMonths(1);
        public DateTime Date
        {
            get 
            { 
                return date;
            }
            set
            {
                if (value > DateTime.Now.AddMonths(1))
                {
                    date = value;
                    int d = (Date - DateTime.Now).Days/30;
                    if (sum == 0)
                    {
                        double dec = Math.Pow(1 + (Proc / 100), d);
                        double cha = (Proc / 100 * dec);
                        double del = (Math.Pow(1 + Proc / 100, d) - 1);
                        dec = cha/del;
                        double dec1 = (double)sum_m / dec;
                        sum = (decimal)dec1;
                    }
                    else
                        sum_m = (decimal)((double)sum * (Proc / 100 * Math.Pow(1 + (Proc / 100), d) / (Math.Pow(1 + Proc / 100, d) - 1)));
                    
                    OnPropertyChanged("Sum");
                    OnPropertyChanged("Sum_m");
                }
                OnPropertyChanged("Date");
            }
        }
        double proc;
        public double Proc
        {
            get { return proc; }
            set { }
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
        decimal sum_m = 0;
        public decimal Sum_m
        {
            get { return sum_m; }
            set
            {
                try
                {
                    sum_m = value;
                    int d = (Date - DateTime.Now).Days/30;
                    sum = sum_m / (decimal)(Proc / 100 * Math.Pow(1 + (Proc / 100), d) / (Math.Pow(1 + Proc / 100, d) - 1));
                    OnPropertyChanged("Sum");
                    OnPropertyChanged("Sum_m");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        decimal sum = 0;
        public decimal Sum
        {
            get { return sum; }
            set
            {
                try
                {
                    sum = value;
                    int d = (Date -DateTime.Now).Days/30;
                    sum_m = sum * (decimal)(Proc / 100 * Math.Pow(1 + (Proc / 100), d) / (Math.Pow(1 + Proc / 100, d) - 1));
                    
                    OnPropertyChanged("Sum_m");
                    OnPropertyChanged("Sum");
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
                        if(selectedValute!=null)
                        {
                            if (selectedSchet != null)
                            {
                                prog.dlitel_day_min = (Date - DateTime.Now).Days;
                                prog.min_Sum = sum_m;
                                prog.Name = " ";
                                TransferManedger.Create_Kredit(SelectedSchet, prog, Sum, bd, selectedValute, ID);
                                window.vklad();
                            }
                            else MessageBox.Show("Не выбран счет начисления");
                        }
                        else MessageBox.Show("Не выбрана валюта");



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
