﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCLogistics.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ABCLogisticsDataEntities : DbContext
    {
        public ABCLogisticsDataEntities()
            : base("name=ABCLogisticsDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Parcel> Parcels { get; set; }
        public virtual DbSet<Tracking> Trackings { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
