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
        Operacii operacii;
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

        double Procent
        {
            get
            {
                return operacii.Schet.Prog.Procent;
            }
            set
            {
                operacii.Schet.Prog.Procent = value;
                OnPropertyChanged("Procent");
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
