//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_Insurance_Company.ApplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Medical_Services
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medical_Services()
        {
            this.Medical_Institutions = new HashSet<Medical_Institutions>();
        }
    
        public int ID_Medical_Services { get; set; }
        public string Type_Of_Services { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medical_Institutions> Medical_Institutions { get; set; }
    }
}
