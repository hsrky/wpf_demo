using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accounting.Model
{
    public class AccountDataModel
    {
        public enum AccountType
        {
            Credit,
            Debit,
            All
        };

        public List<AccountModel> GetAccounts(AccountType type = AccountType.All)
        {
            string prefix = "ALL - ";
            if (type == AccountType.Credit)
            {
                prefix = "Credit - ";
            }
            else if (type == AccountType.Debit)
            {
                prefix = "Debit -";
            }

            var list = new List<AccountModel>
            {
                new AccountModel(1, "1000", prefix + "Account 1"),
                new AccountModel(2, "2000", prefix + "Account 2"),
                new AccountModel(3, "3000", prefix + "Account 3")
            };

            return list;
        }

        public List<TaxModel> GetTaxAccounts()
        {
            var list = new List<TaxModel>
            {
                new TaxModel(1, "TS"),
                new TaxModel(2, "TS-TW"),
                new TaxModel(3, "KK-343")
            };

            return list;
        }

        public class AccountModel
        {
            public AccountModel(int id, string code, string name)
            {
                this.Id = id;
                this.Code = code;
                this.Name = name;
            }

            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public class TaxModel
        {

            public TaxModel(int id, string code)
            {
                this.Id = id;
                this.Code = code;
            }

            public int Id { get; set; }
            public string Code { get; set; }
        }
    }
}
