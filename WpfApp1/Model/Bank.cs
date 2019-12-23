namespace WpfApp1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Bank : DbContext
    {
        public Bank()
            : base("name=Bank")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Operacii> Operacii { get; set; }
        public virtual DbSet<Prog> Prog { get; set; }
        public virtual DbSet<Schet> Schet { get; set; }
        public virtual DbSet<Sotrudnic> Sotrudnic { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Status_Scheta> Status_Scheta { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tip_operacii> Tip_operacii { get; set; }
        public virtual DbSet<Tip> Tip { get; set; }
        public virtual DbSet<Valute> Valute { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasMany(e => e.Schet)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.ClientID);

            modelBuilder.Entity<Prog>()
                .HasMany(e => e.Schet)
                .WithOptional(e => e.Prog)
                .HasForeignKey(e => e.ProgID);

            modelBuilder.Entity<Schet>()
                .HasMany(e => e.Operacii)
                .WithOptional(e => e.Schet)
                .HasForeignKey(e => e.InID);

            modelBuilder.Entity<Schet>()
                .HasMany(e => e.Operacii1)
                .WithOptional(e => e.Schet1)
                .HasForeignKey(e => e.OutID);

            modelBuilder.Entity<Sotrudnic>()
                .HasMany(e => e.Operacii)
                .WithOptional(e => e.Sotrudnic)
                .HasForeignKey(e => e.SotrudnicID);

            modelBuilder.Entity<Tip_operacii>()
                .HasMany(e => e.Operaciis)
                .WithOptional(e => e.Tip_operacii)
                .HasForeignKey(e => e.Tip_operaziiID);

            modelBuilder.Entity<Tip>()
                .HasMany(e => e.Prog)
                .WithRequired(e => e.Tip)
                .HasForeignKey(e => e.TipID);

            modelBuilder.Entity<Valute>()
                .HasMany(e => e.Schets)
                .WithRequired(e => e.Valute)
                .HasForeignKey(e => e.ValuteID);
        }
    }
}
