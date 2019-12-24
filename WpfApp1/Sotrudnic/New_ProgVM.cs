using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class New_ProgVM : Base
    {
        SotrudnicWindowVM windowVM;
        Bank bank;
        int ID;
        Prog prog;
        bool add;
        public New_ProgVM(int id, SotrudnicWindowVM windowVM, Bank bank)
        {
            add = true;
            ID = id;
            this.windowVM = windowVM;
            this.bank = bank;
            prog = new Prog();
            prog.ID = 1;
        }
        public New_ProgVM(int id, SotrudnicWindowVM windowVM, Bank bank, Prog prog)
        {
            add = false;
            ID = id;
            this.windowVM = windowVM;
            this.bank = bank;
            this.prog = prog;

        }
        public RelayCommand OK
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        if (add)
                        {
                            prog.TipID = bank.Tip.Where(i => i.Name == "Вклад").FirstOrDefault().ID;
                            bank.Prog.Add(prog);
                            bank.SaveChanges();
                            windowVM.program();
                        }
                        else
                        {
                            bank.SaveChanges();
                            windowVM.program();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public string Name
        {
            get
            {
                return prog.Name;
            }
            set
            {
                prog.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public double Procent
        {
            get
            {
                return prog.Procent;
            }
            set
            {
                prog.Procent = value;
                OnPropertyChanged("Procent");
            }
        }
        public int dlitel_day_min
        {
            get
            {
                return prog.dlitel_day_min;
            }
            set
            {
                prog.dlitel_day_min = value;
                OnPropertyChanged("dlitel_day_min");
            }
        }
        public int dlitel_day_max
        {
            get
            {
                return prog.dlitel_day_max;
            }
            set
            {
                prog.dlitel_day_max = value;
                OnPropertyChanged("dlitel_day_max");
            }
        }
        public decimal min_Sum
        {
            get
            {
                return prog.min_Sum;
            }
            set
            {
                prog.min_Sum = value;
                OnPropertyChanged("min_Sum");
            }
        }
    }
}
