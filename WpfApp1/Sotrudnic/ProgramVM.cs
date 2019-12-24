using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;
using System.Collections.ObjectModel;

namespace WpfApp1.Sotrudnic
{
    class ProgramVM : Base
    {
        int ID;
        SotrudnicWindowVM window;
        Bank bank;
        public ObservableCollection<Prog> progs { get; set; }
        public Prog selectedProg;
        public Prog SelectedProgram
        {
            get
            {
                return selectedProg;
            }
            set
            {
                selectedProg = value;
                OnPropertyChanged("SelectedProgram");
            }
        }
        public ProgramVM(int id, SotrudnicWindowVM window, Bank bank)
        {
            ID = id;
            this.bank = bank;
            this.window = window;
            progs = new ObservableCollection<Prog>(bank.Prog);
        }
        public RelayCommand New
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.window.Page.Content = new New_ProgV(ID, window, bank);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Change
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.window.Page.Content = new New_ProgV(ID, window, bank, SelectedProgram);
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
            progs.Clear();
            foreach (Prog prog in bank.Prog)
            {
                progs.Add(prog);
            }
        }
    }
}
