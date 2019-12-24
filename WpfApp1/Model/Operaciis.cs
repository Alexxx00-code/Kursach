namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operacii
    {
        public int ID { get; set; }

        public decimal? Sum_In { get; set; }

        public int? OutID { get; set; }

        public int? InID { get; set; }

        public int? Vneshcniy_Nscheta { get; set; }

        public int? Tip_operaziiID { get; set; }

        public DateTime Date { get; set; }

        public int? SotrudnicID { get; set; }

        public int StatusID { get; set; }

        public decimal? Sum_Out { get; set; }

        public virtual Sotrudnic Sotrudnic { get; set; }

        public virtual Status Status { get; set; }

        public virtual Schet Schet { get; set; }

        public virtual Schet Schet1 { get; set; }

        public virtual Tip_operacii Tip_operacii { get; set; }

   
    }
}
