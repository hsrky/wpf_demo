using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Model;

namespace Accounting
{
    /**
     * Provide cache access to all data
     */
    public class DataModel
    {
        private static DataModel _dataModel;

        private AccountDataModel _accountDataModel = null;

        private List<AccountDataModel.TaxModel> _taxModels = null;

        private List<AccountDataModel.AccountModel> _accountDebitModels = null;

        private List<AccountDataModel.AccountModel> _accountCreditModels = null;

        public static DataModel Instance
        {
            get { return _dataModel ?? (_dataModel = new DataModel()); }
        }

        public List<AccountDataModel.TaxModel> GetTax()
        {
            return _taxModels ?? (_taxModels = GetAccountDataModel().GetTaxAccounts());
        }

        public List<AccountDataModel.AccountModel> GetDebitAccounts()
        {
            return _accountDebitModels ?? (_accountDebitModels = GetAccountDataModel().GetAccounts(AccountDataModel.AccountType.Debit));
        }

        public List<AccountDataModel.AccountModel> GetCreditAccounts()
        {
            return _accountCreditModels ?? (_accountCreditModels = GetAccountDataModel().GetAccounts(AccountDataModel.AccountType.Credit));
        }

        private AccountDataModel GetAccountDataModel()
        {
            return _accountDataModel ?? (_accountDataModel = new AccountDataModel());
        }
    }
}
