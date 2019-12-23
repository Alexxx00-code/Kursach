﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
namespace WpfApp1
{
    class TransferManedger
    {
        static public void Create_Schet(Client client, Valute valute, Bank bank)
        {
            Schet schet = new Schet();
            schet.Nschet = 1;
            schet.Data_sozd = DateTime.Now;
            schet.ProgID = null;
            schet.Sum = 0;
            schet.ValuteID = valute.ID;
            schet.ClientID = client.ID;
            schet.Status = true;
            bank.Schet.Add(schet);
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.StatusID = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
            operacii.Schet = schet;
            operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Создание счёта").FirstOrDefault().ID;
            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public void Create_Vklad(Client client, Valute valute, Prog prog, decimal Sum, Schet Out, Bank bank)
        {
            Schet In = new Schet();
            In.Nschet = 1;
            In.Data_sozd = DateTime.Now;
            In.Prog = prog;
            In.Sum = 0;
            In.ValuteID = valute.ID;
            In.ClientID = client.ID;
            In.Status = true;
            bank.Schet.Add(In);
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.StatusID = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
            operacii.OutID = Out.Nschet;
            operacii.InID = In.Nschet;
            operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Создание вклада").FirstOrDefault().ID;
            if (In.ValuteID == Out.ValuteID)
            {
                operacii.Sum_In = operacii.Sum_Out = Sum;
                Out.Sum -= Sum;
                In.Sum += Sum;
            }
            else
            {
                perevod(Out, In, Sum, bank, operacii);
            }

            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public void Perevod_vnutri(Schet Out, Schet In, decimal Sum, Bank bank)
        {
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.StatusID = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
            operacii.OutID = Out.Nschet;
            operacii.InID = In.Nschet;
            operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Перевод").FirstOrDefault().ID;
            if (In.ValuteID == Out.ValuteID)
            {
                operacii.Sum_In = operacii.Sum_Out = Sum;
                Out.Sum -= Sum;
                In.Sum += Sum;
            }
            else
            {
                perevod(Out, In, Sum, bank, operacii);
            }

            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public int Perevod_vneshniy_Schet(Schet Out, int In_n, decimal Sum, Bank bank)
        {
            Schet In = bank.Schet.Find(In_n);
            if (In != null)
            {
                Operacii operacii = new Operacii();
                operacii.ID = 1;
                operacii.Date = DateTime.Now;
                operacii.StatusID = bank.Status.Where(i => i.Name == "Выполнена").FirstOrDefault().ID;
                operacii.OutID = Out.Nschet;
                operacii.InID = In.Nschet;
                operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Перевод").FirstOrDefault().ID;
                if (In.ValuteID == Out.ValuteID)
                {
                    operacii.Sum_In = operacii.Sum_Out = Sum;
                    Out.Sum -= Sum;
                    In.Sum += Sum;
                }
                else
                {
                    perevod(Out, In, Sum, bank, operacii);
                }

                bank.Operacii.Add(operacii);
                return bank.SaveChanges();
            }
            else
                return 0;
        }
        static public void Perevod_vneshniy_Bank(Schet Out, int In, decimal Sum, Bank bank)
        {
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.StatusID = bank.Status.Where(i => i.Name == "Ожидает выполнения").FirstOrDefault().ID;
            operacii.OutID = Out.Nschet;
            operacii.Vneshcniy_Nscheta = In;
            operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Перевод").FirstOrDefault().ID;
            operacii.Sum_In = operacii.Sum_Out = Sum;
            Out.Sum -= Sum;
            bank.Client.Find(2).Schet.Where(i => i.ValuteID == Out.ValuteID).FirstOrDefault().Sum += operacii.Sum_Out;
            bank.Operacii.Add(operacii);
            bank.SaveChanges();
        }
        static public int Delete_Vklad(Schet del, Schet In, Bank bank)
        {            
            del.Status = false;
            Operacii operacii = new Operacii();
            operacii.ID = 1;
            operacii.Date = DateTime.Now;
            operacii.StatusID = bank.Status.Where(i => i.Name == "Ожидает выполнения").FirstOrDefault().ID;
            operacii.OutID = del.Nschet;
            operacii.InID = In.Nschet;
            operacii.Tip_operaziiID = bank.Tip_operacii.Where(i => i.Name == "Закрытие вклада").FirstOrDefault().ID;
            if (In.ValuteID == del.ValuteID)
            {
                operacii.Sum_In = operacii.Sum_Out = del.Sum;
            }
            else
            {
                operacii.Sum_Out = del.Sum;
                operacii.Sum_In = del.Sum * (decimal)del.Valute.Otnoshenie_k_rub_prod / (decimal)In.Valute.Otnoshenie_k_rub_pok;
            }
            bank.Operacii.Add(operacii);
            return bank.SaveChanges();
        }

        static public int Delete_Schet(Schet del, Bank bank)
        {
            if (del.Client.Schet.Where(i => (i.ProgID == null)&&(i.Status==true)).Count() > 1)
            {
                del.Status = false;
                return bank.SaveChanges();
            }
            return 0;
        }

        static int perevod(Schet Out, Schet In, decimal Sum, Bank bank, Operacii operacii)
        {
            operacii.Sum_Out = Sum * (decimal)In.Valute.Otnoshenie_k_rub_pok / (decimal)Out.Valute.Otnoshenie_k_rub_prod;
            operacii.Sum_In = Sum;
            Out.Sum -= operacii.Sum_Out;
            bank.Client.Find(2).Schet.Where(i => i.ValuteID == Out.ValuteID).FirstOrDefault().Sum += operacii.Sum_Out;
            In.Sum += operacii.Sum_In;            
            bank.Client.Find(2).Schet.Where(i => i.ValuteID == In.ValuteID).FirstOrDefault().Sum -= operacii.Sum_In;
            return 1;
        }

        static public void Create_Kredit(Schet schet, Prog prog, decimal Sum, Bank bank)
        {

        }
    }
}
