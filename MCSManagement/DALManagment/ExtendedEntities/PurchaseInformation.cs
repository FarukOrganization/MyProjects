using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Utility;

namespace DALManagment
{
   public partial class PurchaseInformation
   {
       public string CurrencyName
       {
           get;
           set;
       }

       public bool IsDeleted
       {
           get;
           set;
       }

       public bool IsNew
       {
           get;
           set;
       }

       public string FormatedPurchaseDateString
       {
           get
           {
               if (PurchasedDate.HasValue)
               {
                   return PurchasedDate.Value.ToString("dd-MM-yyyy");
               }
               else
               {
                   return DateTime.MinValue.ToShortDateString();
               }
           }
           set
           {
               ;
           }

       }


       //public void Detach()
       //{
       //    //this._Customer = default(EntityRef<Customer>);
       //}
   }

   public partial class GetPurchaseInformationResult
   {
       public string FormatedPurchaseDateString
       {
           get
           {
               if (PurchasedDate.HasValue)
               {
                   return PurchasedDate.Value.ToString("dd-MM-yyyy");
               }
               else
               {
                   return DateTime.MinValue.ToShortDateString();
               }
           }
           set
           {
               ;
           }
           
       }

       public string TypeOfCustomer
       {
           get
           {
               if (CustomerType == (int)ECustomerType.Bank)
               {
                   return ECustomerType.Bank.ToString();
               }
               else if (CustomerType == (int)ECustomerType.Customer)
               {
                   return ECustomerType.Customer.ToString();
               }
               else if (CustomerType == (int)ECustomerType.MoneyChanger)
               {
                   return ECustomerType.MoneyChanger.ToString();
               }

               return ECustomerType.None.ToString();
           }

           set
           {
               ;
           }
       
       
       }

   }

  
}
