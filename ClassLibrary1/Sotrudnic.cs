//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sotrudnic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudnic()
        {
            this.Operacii = new HashSet<Operacii>();
        }
    
        public int ID { get; set; }
        public string FIO { get; set; }
        public string Dolgnost { get; set; }
        public string Login { get; set; }
        public string Paswoorld { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operacii> Operacii { get; set; }
    }
}
