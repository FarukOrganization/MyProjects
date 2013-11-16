using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALManagment
{
    public partial class GetPurchaseInformationForReportResult
    {
        public System.Nullable<decimal> PurchasedRate
        {
            get
            {
                return Math.Round((this._TotalBDTAmount / this._TotalPurchasedAmount)??0,2);
            }
            set
            { 
             
            }

        }
    }
}
