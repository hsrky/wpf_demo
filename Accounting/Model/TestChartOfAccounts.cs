using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.Entity;

namespace Accounting.Model
{
    class TestChartOfAccounts
    {
        public void Create()
        {
        }

        public void Read()
        {
            using (var ett = new Entities())
            {
                foreach (var acc in ett.chart_of_accounts)
                {
                    Console.WriteLine(String.Format("SQL Server: {0}: {1}", acc.code, acc.name));
                }
            }
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}
