﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laba5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Laba5Entities : DbContext
    {
        public Laba5Entities()
            : base("name=Laba5Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdresaDostavkis> AdresaDostavkis { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<CountryProizvodstvas> CountryProizvodstvas { get; set; }
        public virtual DbSet<Dolznostis> Dolznostis { get; set; }
        public virtual DbSet<Gorods> Gorods { get; set; }
        public virtual DbSet<LoginPasses> LoginPasses { get; set; }
        public virtual DbSet<SNM_Sortudnicks> SNM_Sortudnicks { get; set; }
        public virtual DbSet<Sotrudnicks> Sotrudnicks { get; set; }
        public virtual DbSet<TypeDostavkis> TypeDostavkis { get; set; }
        public virtual DbSet<TypeOplatis> TypeOplatis { get; set; }
        public virtual DbSet<Unitazs> Unitazs { get; set; }
        public virtual DbSet<UnitazTypes> UnitazTypes { get; set; }
        public virtual DbSet<Zakazs> Zakazs { get; set; }
    }
}
