using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
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
        ClientWindowVM window;
        private Client user;
        Bank bd;

        public OperaciiVM(int id, ClientWindowVM window,Bank bank)
        {
            bd = bank;
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
            this.window = window;
        }
        public void UPD()
        {
            
            operaciis.Clear();
            foreach (Operacii operacii in bd.Operacii)
            {
                operaciis.Add(operacii);               
            }
        }
    }
}
