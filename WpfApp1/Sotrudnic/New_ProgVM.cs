using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;

namespace WpfApp1.Sotrudnic
{
    class New_ProgVM
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

    }
}
