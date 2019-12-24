using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using System.Windows;
using WpfApp1.Sotrudnic;

namespace WpfApp1
{
    public class SotrudnicWindowVM 
    {
        Bank bd;
        Model.Sotrudnic sotrudnic;
        int ID;
        ClientV clientV;
        Operacii_na_potvV Operacii;
        OperaciiV OperaciiV;
        ProgramV ProgramV;
        public SotrudnicWindow window;
        public SotrudnicWindowVM(int id, SotrudnicWindow window)
        {
            bd = new Bank();
            ID = id;
            sotrudnic = bd.Sotrudnic.Find(ID);
            this.window = window;
        }
        public RelayCommand ClientViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        client();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public void client()
        {
            if (clientV == null)
                clientV = new ClientV(ID, this, bd);
            clientV.UPD();
            window.Page.Content = clientV;
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
            if (Operacii == null)
                Operacii = new Operacii_na_potvV(ID, this, bd);
            Operacii.UPD();
            window.Page.Content = Operacii;
        }
        public RelayCommand VkladViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        program();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public void program()
        {
            if (ProgramV == null)
                ProgramV = new ProgramV(ID, this, bd);
            ProgramV.UPD();
            window.Page.Content = ProgramV;
        }
        public RelayCommand OperaciiAllViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        operaciiall();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
        }
        public void operaciiall()
        {
            if (OperaciiV == null)
                OperaciiV = new OperaciiV(ID, this, bd);
            OperaciiV.UPD();
            window.Page.Content = OperaciiV;
        }
    }
}
