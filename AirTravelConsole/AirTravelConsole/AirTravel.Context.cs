﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirTravelConsole
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AirTravelEntities : DbContext
    {
        public AirTravelEntities()
            : base("name=AirTravelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airline> Airlines { get; set; }
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
    }
}
