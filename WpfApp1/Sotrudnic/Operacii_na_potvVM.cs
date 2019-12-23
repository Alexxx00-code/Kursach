using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class Operacii_na_potvVM : Base
    {
        Operacii_na_potvV Page;
        int ID;
        SotrudnicWindowVM window;
        Bank bank;
        public ObservableCollection<Operacii> operaciis { get; set; }
        Operacii selectedOperacii;
        public Operacii SelectedOperacii
        {
            get
            {
                return selectedOperacii;
            }
            set
            {
                selectedOperacii = value;
                OnPropertyChanged("SelectedOperacii");
            }
        }
        public Operacii_na_potvVM(int id, SotrudnicWindowVM window, Bank bank,Operacii_na_potvV page)
        {
            ID = id;
            this.bank = bank;
            this.window = window;
            operaciis = new ObservableCollection<Operacii>(bank.Operacii.Where(i=>i.Tip_operacii.Name== "Ожидает выполнения"));
            Page = page;
        }
        public RelayCommand Rassmotret
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        if (selectedOperacii.Tip_operacii.Name == "Перевод")
                            Page.Page.Content = new Rassmotreniy_perevodV(ID, window, SelectedOperacii, bank);
                        else
                        {
                            if (selectedOperacii.Tip_operacii.Name == "Создание кредита")
                                Page.Page.Content = new Rassmotreniy_kreditV(ID, SelectedOperacii,bank , window);
                            else
                                Page.Page.Content = new Rassmotreniy_vkladV(ID, SelectedOperacii, bank, window);
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
            foreach (Operacii operacii in bank.Operacii.Where(i => i.Tip_operacii.Name == "Ожидает выполнения"))
            {
                operaciis.Add(operacii);
            }
        }
    }
}