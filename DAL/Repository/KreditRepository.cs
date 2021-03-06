﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class KreditRepository
    {
        private BankEntities db;
        public KreditRepository(BankEntities context)
        {
            db = context;
        }
        public Schet GetItem(int id)
        {
            return db.Schet.Find(id);
        }
        public List<Schet> GetList()
        {
            return db.Schet.ToList().Where(i=>i.Prog.Tip.Name=="Кредит").ToList();
        }
        public void ADD(Schet schet)
        {
            db.Schet.Add(schet);
        }
        public void UPD(Schet schet)
        {
            Schet s = db.Schet.Find(schet.Nschet);
            s.ClientID = schet.ClientID;
            s.Data_sozd = schet.Data_sozd;
            s.Sum = schet.Sum;
            s.ValuteID = schet.ValuteID;
            s.ProgID = schet.ProgID;
        }
    }
}

