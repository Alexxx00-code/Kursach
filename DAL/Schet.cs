//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Schet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schet()
        {
            this.Operacii = new HashSet<Operacii>();
            this.Operacii1 = new HashSet<Operacii>();
        }
        [Key]
        public int Nschet { get; set; }
        public System.DateTime Data_sozd { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public Nullable<int> ProgID { get; set; }
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
