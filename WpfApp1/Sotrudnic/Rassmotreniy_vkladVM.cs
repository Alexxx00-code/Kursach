using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class Rassmotreniy_vkladVM : Base
    {
        Operacii operacii;
        Bank bank;
        SotrudnicWindowVM windowVM;
        int ID;
        public Rassmotreniy_vkladVM(int id, Operacii operacii, Bank bank, SotrudnicWindowVM windowVM)
        {
            this.operacii = operacii;
            this.bank = bank;
            this.windowVM = windowVM;
            ID = id;
        }
        public double Pr
        {
            get
            {
                return (DateTime.Now-operacii.Schet.Data_sozd).Days;
            }
            set { }
           
        }
        public int? InID
        {
            get
            {
                return operacii.InID;
            }
            set { }

        }
        public decimal? Sum_In
        {
            get
            {
                return operacii.Sum_In;
            }
            set { }

        }
        public int dlitel_day_min
        {
            get
            {
                return operacii.Schet1.Prog.dlitel_day_min;
            }
            set { }
        }
        public string Name
        {
            get
            {
                return operacii.Schet1.Valute.Name;
            }
            set { }
        }
        public string Name1
        {
            get
            {
                return operacii.Schet1.Prog.Name;
            }
            set { }
        }
        
        public RelayCommand OK
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        TransferManedger.Potv_vklada(ID, operacii, bank);
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
                        TransferManedger.Otkaz_vklada(ID, operacii, bank);
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

