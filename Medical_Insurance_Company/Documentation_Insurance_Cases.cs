//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Medical_Insurance_Company
{
    using System;
    using System.Collections.Generic;
    
    public partial class Documentation_Insurance_Cases
    {
        public int ID_Documentation { get; set; }
        public Nullable<System.DateTime> Date_Insuranse_Case { get; set; }
        public Nullable<int> ID_Person { get; set; }
        public Nullable<int> ID_Insuranse_Case { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ID_Medical_Institution { get; set; }
    
        public virtual Insurance_Cases Insurance_Cases { get; set; }
        public virtual Medical_Institutions Medical_Institutions { get; set; }
        public virtual Person Person { get; set; }
    }
}