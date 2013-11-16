using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALManagment;
using System.Data.Linq;
using Utility;

namespace BusinessManagement
{
    public class CBusinessManagement
    {

       public static List<GetPurchaseSellBalanceByDateResult> GetPurchaseSellBalanceByDate(DateTime date)
        {
            DALDataContext oDALDataContext = new DALDataContext();
            List<GetPurchaseSellBalanceByDateResult> lstPurchaseSellBalance = new List<GetPurchaseSellBalanceByDateResult>();

            lstPurchaseSellBalance = oDALDataContext.GetPurchaseSellBalanceByDate(date).ToList();

            return lstPurchaseSellBalance;
        }
    }
}
