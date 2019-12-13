using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Clientu;

namespace WpfApp1
{
    class MainWindowVM
    {
        int ID;
        ClientWindow window;
        public MainWindowVM(int id, ClientWindow window )
        {
            ID = id;
            this.window = window;
        }
        public RelayCommand SchetViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        
                        window.Page.Content = new SchetV(ID,window);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand KreditViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {

                        window.Page.Content = new KreditV(ID, window);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand VkladViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {

                        window.Page.Content = new VkladV(ID, window);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        
        public RelayCommand OperaciiViev
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {

                        window.Page.Content = new OperaciiV(ID, window);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }

        }
        public RelayCommand Perevod
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    try
                    {
                        window.Page.Content = new Perevod(ID, window);
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
