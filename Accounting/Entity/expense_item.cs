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
    
    public partial class expense_item
    {
        public int expense_item_id { get; set; }
        public int expense_id { get; set; }
        public int expense_account_id { get; set; }
        public decimal subtotal { get; set; }
        public Nullable<int> tax_id { get; set; }
        public double quantity { get; set; }
        public Nullable<decimal> rate { get; set; }
        public Nullable<decimal> tax_amount { get; set; }
        public decimal net_amount { get; set; }
        public string description { get; set; }
        public Nullable<int> seq { get; set; }
    
        public virtual chart_of_accounts chart_of_accounts { get; set; }
        public virtual expense expense { get; set; }
        public virtual tax_code tax_code { get; set; }
    }
}
