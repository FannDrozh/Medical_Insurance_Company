﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MIC_BarashenkovEntities : DbContext
    {
        public MIC_BarashenkovEntities()
            : base("name=MIC_BarashenkovEntities")
        {
        }

    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Authorization> Authorizations { get; set; }
        public virtual DbSet<Documentation_Insurance_Cases> Documentation_Insurance_Cases { get; set; }
        public virtual DbSet<Insurance_Cases> Insurance_Cases { get; set; }
        public virtual DbSet<Medical_Institutions> Medical_Institutions { get; set; }
        public virtual DbSet<Medical_Services> Medical_Services { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Role_Users> Role_Users { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
