using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class Rassmotreniy_kreditVM : Base
    {
        public Operacii operacii;
        Bank bank;
        SotrudnicWindowVM windowVM;
        int ID;
        public Rassmotreniy_kreditVM(int id, Operacii operacii, Bank bank, SotrudnicWindowVM windowVM)
        {
            this.operacii = operacii;
            this.bank = bank;
            this.windowVM = windowVM;
            ID = id;
        }

        public double Procent
        {
            get
            {
                return operacii.Schet1.Prog.Procent;
            }
            set
            {
                operacii.Schet1.Prog.Procent = value;
                OnPropertyChanged("Procent");
            }
        }
        public decimal? Sum
        {
            get
            {
                return operacii.Sum_In;
            }
            set
            {
            }
        }
        public int? InID
        {
            get
            {
                return operacii.InID;
            }
            set
            {
            }
        }
        public string Name
        {
            get
            {
                return operacii.Schet.Valute.Name;
            }
            set
            {
            }
        }
        public int dlitel_day_min
        {
            get
            {
                return operacii.Schet1.Prog.dlitel_day_min;
            }
            set
            {
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
                        TransferManedger.Potv_kredita(ID, operacii, bank, Procent);
                        windowVM.operacii();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Cans
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        TransferManedger.Otkaz_kredita(ID, operacii, bank);
                        windowVM.operacii();
                        
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
