﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class Rassmotreniy_perevodVM
    {
        Operacii operacii;
        Bank bank;
        SotrudnicWindowVM windowVM;
        int ID;
        public Rassmotreniy_perevodVM(int id,Operacii operacii, Bank bank, SotrudnicWindowVM windowVM)
        {
            this.operacii = operacii;
            this.bank = bank;
            this.windowVM = windowVM;
            ID = id;
        }
        public int? Vneshcniy_Nscheta
        {
            get
            {
                return operacii.Vneshcniy_Nscheta;
            }
            set
            {
            }
        }
        public decimal? Sum_In
        {
            get
            {
                return operacii.Sum_In;
            }
            set
            {
            }
        }
        public string Name
        {
            get
            {
                return operacii.Schet1.Valute.Name;
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
                        TransferManedger.Potv_vn_perevod(ID, operacii, bank);
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
                        TransferManedger.Otkaz_vn_perevod(ID, operacii, bank);
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
