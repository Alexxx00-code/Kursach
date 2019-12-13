using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using DAL;
using System.Collections.ObjectModel;

namespace WpfApp1.Clientu
{
    class KreditVM
    {
        Window window;
        Page newvklad;
       
        public ObservableCollection<Schet> kredits { get; set; }
        public ObservableCollection<Operacii> operaciis { get; set; }
        private Client user;
        public ObservableCollection<Schet> Schetss { get; set; }
        BankEntities bd;
        int ID;
        public KreditVM(int id, Window window)
        {
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            kredits = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog != null) && (i.Prog.Tip.Name == "Кредит")&&(i.Status==true)));
            
            
        }
    }
}
