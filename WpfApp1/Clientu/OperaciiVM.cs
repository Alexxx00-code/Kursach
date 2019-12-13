using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1.Clientu
{
    class OperaciiVM
    {
        public ObservableCollection<Operacii> operaciis { get; set; }        
        ClientWindow window;
        private Client user;
        BankEntities bd;

        public OperaciiVM(int id,ClientWindow window)
        {
            bd = new BankEntities();
            user = bd.Client.Find(id);
            operaciis = new ObservableCollection<Operacii>();
            foreach (Schet s in user.Schet)
            {
                foreach (Operacii o in s.Operacii)
                {
                    operaciis.Add(o);
                }
                foreach (Operacii o in s.Operacii1)
                {
                    operaciis.Add(o);
                }
            }

        }
    }
}
