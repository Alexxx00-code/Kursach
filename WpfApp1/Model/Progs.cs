namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prog()
        {
            Schet = new HashSet<Schet>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public double Procent { get; set; }

        public int TipID { get; set; }

        public int dlitel_day_min { get; set; }

        public int dlitel_day_max { get; set; }

        public decimal min_Sum { get; set; }

        public virtual Tip Tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schet> Schet { get; set; }
    }
}
