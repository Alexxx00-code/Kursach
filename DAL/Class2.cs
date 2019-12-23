using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DAL
{
    public partial class BankEntities : DbContext
    {
        public BankEntities()
            : base("name=BankEntities")
        {
        }

        
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Operacii> Operacii { get; set; }
        public virtual DbSet<Prog> Prog { get; set; }
        public virtual DbSet<Schet> Schet { get; set; }
        public virtual DbSet<Sotrudnic> Sotrudnic { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Status_Scheta> Status_Scheta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tip> Tip { get; set; }
        public virtual DbSet<Tip_operacii> Tip_operacii { get; set; }
        public virtual DbSet<Valute> Valute { get; set; }


    }
}
