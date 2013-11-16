using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public enum Operation {Create=1,Read=2,Update=3,Delete=4};
    public enum ECustomerType { None = 0, Customer = 1, Bank = 2, MoneyChanger = 3 };

    public class CBusinessUtility
    {

        public static DateTime GetValidatedDate(string sDateToValidate)
        {
            DateTime dtPurchasedDate = DateTime.MinValue;

            string[] arrsplitedPurchaseDate = sDateToValidate.Split('-');

            dtPurchasedDate = new DateTime(Convert.ToInt32(arrsplitedPurchaseDate[2]), Convert.ToInt32(arrsplitedPurchaseDate[1]), Convert.ToInt32(arrsplitedPurchaseDate[0]));

            return dtPurchasedDate;
        }

        //public static string GetFromatedDate(string sDateToValidate)
        //{
        //    DateTime dtPurchasedDate = DateTime.MinValue;

        //    string[] arrsplitedPurchaseDate = sDateToValidate.Split('-');

        //    dtPurchasedDate = new DateTime(Convert.ToInt32(arrsplitedPurchaseDate[2]), Convert.ToInt32(arrsplitedPurchaseDate[1]), Convert.ToInt32(arrsplitedPurchaseDate[0]));

        //    return dtPurchasedDate;
        //} 
    }
}
