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

namespace WpfApp1
{
    public class Controler : INotifyPropertyChanged
    {
        
        public ObservableCollection<SchetBLL> schets { get; set; }
        BankEntities bd;
        int ID;
        public Controler(int id)
        {
            bd = new BankEntities();
            ID = id;
            schets =new ObservableCollection<SchetBLL>( GetAllSchet().Where(i=>i.Client_FK==ID));
        }
        public ObservableCollection<SchetBLL> GetAllSchet()
        {            
            return new ObservableCollection < SchetBLL > (bd.Schet.ToList().Where(i => i.Prog == null).ToList().Select(i => new SchetBLL(i, GetAllValute())));
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
        }
        SchetBLL selectedSchet;
        public SchetBLL SelectedSchet
        {
            get { return selectedSchet; }
            set
            {
                selectedSchet = value;
                OnPropertyChanged("SelectedSchet");
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


