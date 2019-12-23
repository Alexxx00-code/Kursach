namespace WpfApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Client 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Schet = new HashSet<Schet>();
        }

        public int ID { get; set; }

        public string FIO { get; set; }

        public int Npasporta { get; set; }

        public int Serpasporta { get; set; }

        public DateTime Data_rog { get; set; }

        public string login { get; set; }

        public string pasworld { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schet> Schet { get; set; }
    }
}
