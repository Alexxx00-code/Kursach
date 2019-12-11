using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BLL.Model;

namespace BLL
{
    public class Controler
    {
        BankEntities bd;
        public Controler()
        {
            bd = new BankEntities();
        }
        public List<SchetBLL> GetAllSchet()
        {            
            return bd.Schet.ToList().Where(i => i.Prog == null).ToList().Select(i => new SchetBLL(i, GetAllValute())).ToList();
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
    }
}

