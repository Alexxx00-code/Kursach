namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Schet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schet()
        {
            Operacii = new HashSet<Operacii>();
            Operacii1 = new HashSet<Operacii>();
        }

        [Key]
        public int Nschet { get; set; }

        public DateTime Data_sozd { get; set; }

        public decimal? Sum { get; set; }

        public int? ProgID { get; set; }

        public int ValuteID { get; set; }

        public int ClientID { get; set; }

        public bool Status { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacii> Operacii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacii> Operacii1 { get; set; }

        public virtual Prog Prog { get; set; }

        public virtual Valute Valute { get; set; }
    }
}
