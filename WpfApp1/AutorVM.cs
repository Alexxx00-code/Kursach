using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    class AutorVM
    {
        public ObservableCollection<string> Vibor { get; set; }
        AutorV win;
        public AutorVM(AutorV autor)
        {
            Vibor = new ObservableCollection<string>();
            Vibor.Add("Клиент");
            Vibor.Add("Сотрудник");
            win = autor;
        }
       
        string login;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }


        
        string selectVibor;
        public string SelectVibor
        {
            get
            {
                return selectVibor;
            }
            set
            {
                selectVibor = value;
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
                        string passworld = win.pas.Password;
                        if ((login.Length>0)&&(passworld.Length>0))
                        {
                            Bank bank = new Bank();
                            if(selectVibor== "Клиент")
                            {
                                Client client =bank.Client.Where(i => (i.login == login)&&(i.pasworld==passworld)).FirstOrDefault();
                                if(client!=null)
                                {
                                    win.Hide();
                                    ClientWindowV window = new ClientWindowV(client.ID);
                                    window.ShowDialog();
                                    win.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин или пароль");
                                }
                            }
                            else
                            {
                                WpfApp1.Model.Sotrudnic sotrudnic = bank.Sotrudnic.Where(i => (i.Login == login) && (i.Paswoorld == passworld)).FirstOrDefault();
                                if (sotrudnic != null)
                                {
                                    win.Hide();
                                    SotrudnicWindowV window = new SotrudnicWindowV(sotrudnic.ID);
                                    window.ShowDialog();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный логин или пароль");
                                }
                            }
                        }
                        else
                            MessageBox.Show("Введите логин и пароль");
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
