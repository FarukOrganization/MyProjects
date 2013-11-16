using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALManagment
{
   public partial class GetSellInformationForReportResult
    {
       public System.Nullable<decimal> SoldRate
       {
           get
           {
               return Math.Round((this._TotalBDTAmount / this._TotalSoldAmount)??0,2);
           }
           set { }
           
       }
    }
}
