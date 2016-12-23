﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account_type> account_type { get; set; }
        public virtual DbSet<chart_of_accounts> chart_of_accounts { get; set; }
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<currency> currencies { get; set; }
        public virtual DbSet<expense> expenses { get; set; }
        public virtual DbSet<expense_item> expense_item { get; set; }
        public virtual DbSet<general_ledger> general_ledger { get; set; }
        public virtual DbSet<invoice> invoices { get; set; }
        public virtual DbSet<invoice_item> invoice_item { get; set; }
        public virtual DbSet<invoice_payment> invoice_payment { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<manual_adjustment> manual_adjustment { get; set; }
        public virtual DbSet<manual_adjustment_item> manual_adjustment_item { get; set; }
        public virtual DbSet<profile> profiles { get; set; }
        public virtual DbSet<ref_account_type> ref_account_type { get; set; }
        public virtual DbSet<ref_contact_type> ref_contact_type { get; set; }
        public virtual DbSet<ref_payment_made_type> ref_payment_made_type { get; set; }
        public virtual DbSet<ref_payment_mode> ref_payment_mode { get; set; }
        public virtual DbSet<tax_code> tax_code { get; set; }
        public virtual DbSet<term> terms { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}