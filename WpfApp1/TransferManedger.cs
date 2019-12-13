using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace WpfApp1
{
    class TransferManedger
    {
        static public void Create_Schet(Client client,Valute valute,BankEntities bank)
        {
            Schet schet = new Schet();
            schet.Nschet = 1;
            schet.Data_sozd = DateTime.Now;
            schet.Prog_FK = null;
            schet.Sum = 0;
            schet.Valute_FK = valute.ID;
            schet.Client_FK = client.ID;
            schet.Status = true;
            bank.Schet.Add(schet);
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.Status_FK = bank.Status.Where(i=>i.Name=="Выполнена").FirstOrDefault().ID;            
            operacii.Schet = schet;
            operacii.Tip_operazii_FK = bank.Tip_operacii.Where(i => i.Name == "Создание счёта").FirstOrDefault().ID;
            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public void Create_Vklad(Client client, Valute valute,Prog prog,decimal Sum,Schet Out, BankEntities bank)
        {
            Schet In = new Schet();
            In.Nschet = 1;
            In.Data_sozd = DateTime.Now;
            In.Prog = prog;
            In.Sum = 0;
            In.Valute_FK = valute.ID;
            In.Client_FK = client.ID;
            In.Status = true;
            bank.Schet.Add(In);
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.Status_FK = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
            operacii.Out_FK = Out.Nschet;
            operacii.In_FK = In.Nschet;
            operacii.Tip_operazii_FK = bank.Tip_operacii.Where(i => i.Name == "Создание вклада").FirstOrDefault().ID;
            if (In.Valute_FK == Out.Valute_FK)
            {
                Out.Sum -= Sum;
                In.Sum += Sum;
            }
            else
            {
                operacii.Sum_Out = Sum;
                operacii.Sum_In = Sum * (decimal)Out.Valute.Otnoshenie_k_rub_prod / (decimal)In.Valute.Otnoshenie_k_rub_pok;
                Out.Sum -= operacii.Sum_Out;
                In.Sum += operacii.Sum_In;
                bank.Client.Find(1).Schet.Where(i => i.Valute_FK == Out.Valute_FK).FirstOrDefault().Sum += operacii.Sum_Out;
                bank.Client.Find(1).Schet.Where(i => i.Valute_FK == In.Valute_FK).FirstOrDefault().Sum -= operacii.Sum_In;
            }

            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public void Perevod_vnutri(Schet Out, Schet In, decimal Sum, BankEntities bank)
        {
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.Status_FK = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
            operacii.Out_FK = Out.Nschet;
            operacii.In_FK = In.Nschet;
            operacii.Tip_operazii_FK = bank.Tip_operacii.Where(i => i.Name == "Перевод").FirstOrDefault().ID;
            if (In.Valute_FK == Out.Valute_FK)
            {
                Out.Sum -= Sum;
                In.Sum += Sum;
            }
            else
            {
                operacii.Sum_Out = Sum * (decimal)Out.Valute.Otnoshenie_k_rub_prod / (decimal)Out.Valute.Otnoshenie_k_rub_pok;
                operacii.Sum_In = Sum;
                Out.Sum -= operacii.Sum_Out;
                In.Sum += operacii.Sum_In;
                bank.Client.Find(1).Schet.Where(i=>i.Valute_FK==Out.Valute_FK).FirstOrDefault().Sum += operacii.Sum_Out;
                bank.Client.Find(1).Schet.Where(i => i.Valute_FK == In.Valute_FK).FirstOrDefault().Sum -= operacii.Sum_In;
            }

            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public int Delete_Schet(Schet del, BankEntities bank)
        {
            if (((del.Prog_FK!=null)||(del.Client.Schet.Where(i=>(i.Prog_FK==null)&&(i.Status==true)).Count()>1))&&(del.Sum==0))
            {
                del.Status = false;
                return bank.SaveChanges();
            }
            return 0;
        }
    }
}
