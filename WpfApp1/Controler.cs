using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using WpfApp1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp1
{
    public class Controler : INotifyPropertyChanged
    {
        Window window;
        Page newvklad;
        
        private Client user;
        public ObservableCollection<Schet> Schetss { get; set; }
        BankEntities bd;
        int ID;
        
        public Controler(int id, Window window)
        {
            /*
            bd = new BankEntities();
            ID = id;
            user = bd.Client.Find(id);
            schets = new ObservableCollection<Schet>(user.Schet.Where(i => i.Prog == null));
            vklads = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog != null)&&(i.Prog.Tip.Name == "Кредит")));
            kredits = new ObservableCollection<Schet>(user.Schet.Where(i => (i.Prog != null) &&( i.Prog.Tip.Name == "Вклад")));
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
            Schetss = new ObservableCollection<Schet>(bd.Schet.ToList().Where(i => i.Prog == null).ToList().Where(i => i.Client_FK == ID));
            Schet schet = new Schet();
            //schet.Valute.Name;*/
        }
        
        public RelayCommand D
        {
            get
            {
                return new RelayCommand(obj =>
                {

                    try
                    {
                        //newvklad = new New_vklad();
                        Window1 window1 = (Window1)window;
                        //window1.Page.Content = newvklad;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
            }
           
        }
        /*
        public ObservableCollection<SchetBLL> GetAllSchet()
        {
            return new ObservableCollection<SchetBLL>(bd.Schet.ToList().Where(i => i.Prog == null).ToList().Select(i => new SchetBLL(i, GetAllValute())));
        }
        public List<ValuteBLL> GetAllValute()
        {
            return bd.Valute.ToList().Select(i => new ValuteBLL(i)).ToList();
        }
        public List<ProgramBLL> GetAllProgramKredit()
        {
            return bd.Prog.ToList().Where(i => GetTipProgram(i.Tip_FK).Name == "Кредит").ToList().Select(i=>new ProgramBLL(i)).ToList();
        }
        public List<ProgramBLL> GetAllProgramVklad()
        {
            return bd.Prog.ToList().Where(i => GetTipProgram(i.Tip_FK).Name == "Вклад").ToList().Select(i => new ProgramBLL(i)).ToList();
        }
        public ProgramBLL GetProgramKredit(int id)
        {
            return GetAllProgramKredit().Find(i=>i.ID==id);
        }
        public ProgramBLL GetProgramVklad(int id)
        {
            return GetAllProgramVklad().Find(i => i.ID == id);
        }
        public Tip_program GetTipProgram(int id)
        {
            return new Tip_program(bd.Tip.ToList().Find(i=>i.ID==id));
        }
        public List<KreditBLL> GetAllKredit()
        {
            return bd.Schet.ToList().Where(i => (i.Prog_FK!=null)&&(GetProgramKredit((int)i.Prog_FK) != null)).ToList().Select(i => new KreditBLL(i, GetAllValute(),GetAllProgramKredit())).ToList();
        }
        public List<VkladBLL> GetAllVklad()
        {
            return bd.Schet.ToList().Where(i => (i.Prog_FK != null) && (GetProgramVklad((int)i.Prog_FK) != null)).ToList().Select(i => new VkladBLL(i, GetAllValute(),GetAllProgramVklad())).ToList();
        }
        public List<ClientBLL> GetAllClient()
        {
            return bd.Client.ToList().Select(i => new ClientBLL(i)).ToList();
        }*/
        Schet selected;
        public Schet Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}


