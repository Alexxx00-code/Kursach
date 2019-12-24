using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class OperaciiVM : Base
    {
        public OperaciiVM(int id, SotrudnicWindowVM window, Bank bank)
        {
            ID = id;
            this.bank = bank;
            this.window = window;
            operaciis = new ObservableCollection<Operacii>(bank.Operacii);
        }
        int ID;
        SotrudnicWindowVM window;
        Bank bank;
        public ObservableCollection<Operacii> operaciis { get; set; }
        string fio="";
        public string FIO 
        {
            get
            {
                return fio;
            }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }
        string seriy = "";
        public string Seriy
        {
            get
            {
                return seriy;
            }
            set
            {
                seriy = value;
                OnPropertyChanged("Seriy");
            }
        }
        string nomer = "";
        public string Nomer
        {
            get
            {
                return nomer;
            }
            set
            {
                nomer = value;
                OnPropertyChanged("Nomer");
            }
        }
        
        
        DateTime ot=DateTime.Now;
        public DateTime Ot
        {
            get
            {
                return ot;
            }
            set
            {
                ot = value;
                OnPropertyChanged("Ot");
            }
        }
        DateTime dod = DateTime.Now;
        public DateTime Do
        {
            get
            {
                return dod;
            }
            set
            {
                dod = value;
                OnPropertyChanged("Do");
            }
        }

        public RelayCommand Find
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        operaciis.Clear();
                        foreach(Operacii operacii in bank.Operacii.Where(i=>(
                        ((fio.Length==0)||(fio==i.Schet1.Client.FIO))&&
                        ((seriy.Length == 0) || (seriy == i.Schet1.Client.Serpasporta.ToString())) &&
                        ((nomer.Length == 0) || (nomer == i.Schet1.Client.Npasporta.ToString())) 
                        &&(i.Date<dod)&&(i.Date>ot)
                        )))
                        {
                            operaciis.Add(operacii);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }

        public void UPD()
        {
            operaciis.Clear();
            foreach (Operacii operacii in bank.Operacii)
            {
                operaciis.Add(operacii);
            }
        }
    }
}
