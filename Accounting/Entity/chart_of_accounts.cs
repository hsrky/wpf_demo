//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class chart_of_accounts
    {
        public chart_of_accounts()
        {
            this.expenses = new HashSet<expense>();
            this.expense_item = new HashSet<expense_item>();
            this.general_ledger = new HashSet<general_ledger>();
            this.invoice_payment = new HashSet<invoice_payment>();
            this.items = new HashSet<item>();
            this.items1 = new HashSet<item>();
            this.manual_adjustment_item = new HashSet<manual_adjustment_item>();
            this.tax_code1 = new HashSet<tax_code>();
            this.tax_code2 = new HashSet<tax_code>();
        }
    
        public int chart_of_accounts_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Nullable<int> tax_code_id { get; set; }
        public int account_type_id { get; set; }
        public bool active { get; set; }
    
        public virtual account_type account_type { get; set; }
        public virtual tax_code tax_code { get; set; }
        public virtual ICollection<expense> expenses { get; set; }
        public virtual ICollection<expense_item> expense_item { get; set; }
        public virtual ICollection<general_ledger> general_ledger { get; set; }
        public virtual ICollection<invoice_payment> invoice_payment { get; set; }
        public virtual ICollection<item> items { get; set; }
        public virtual ICollection<item> items1 { get; set; }
        public virtual ICollection<manual_adjustment_item> manual_adjustment_item { get; set; }
        public virtual ICollection<tax_code> tax_code1 { get; set; }
        public virtual ICollection<tax_code> tax_code2 { get; set; }
    }
}
