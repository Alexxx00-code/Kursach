using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Clientu;
using WpfApp1.Model;

namespace WpfApp1
{
    public class ClientWindowVM 
    {
        int ID;
        public ClientWindowV window;
        Bank bd;
        SchetV schetV;
        KreditV kreditV;
        OperaciiV operaciiV;
        VkladV vkladV;
        PerevodV perevodV;
        public ClientWindowVM(int id, ClientWindowV window )
        {
            ID = id;
            this.window = window;
            bd = new Bank();
        }
        public RelayCommand SchetViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        schet();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public void schet()
        {
            if (schetV == null)
                schetV = new SchetV(ID, this, bd);
            schetV.UPD();
            window.Page.Content = schetV;
        }
        public RelayCommand KreditViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        kredit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public void kredit()
        {
            if (kreditV == null)
                kreditV = new KreditV(ID, this, bd);
            kreditV.UPD();
            window.Page.Content = kreditV;
        }
        public RelayCommand VkladViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        vklad();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public void vklad()
        {
            if (vkladV == null)
                vkladV = new VkladV(ID, this, bd);
            vkladV.UPD();
            window.Page.Content = vkladV;
        }
        public RelayCommand OperaciiViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        operacii();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public void operacii()
        {
            if (operaciiV == null)
                operaciiV = new OperaciiV(ID, this, bd);
            operaciiV.UPD();
            window.Page.Content = operaciiV;
        }
        public RelayCommand Perevod
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        perevod();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        
        public void perevod()
        {
            if (perevodV == null)
                perevodV = new PerevodV(ID, this, bd);
            perevodV.UPD();
            window.Page.Content = perevodV;
        }

    }
}
