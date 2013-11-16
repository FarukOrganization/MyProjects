using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALManagment;
using System.Data.Linq;
using Utility;

namespace BusinessManagement
{
    

    public class CPurchaseInformationManagment
    {

        //public static string sConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region PurchaseInformationManagment Information Methods 

        public static void CreatePurchaseInformation(Customer oCustomer, Dictionary<Guid,PurchaseInformation> dicIdPurchaseInformation, ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            if (eCustomerType == ECustomerType.Customer)
            {
                oDALDataContext.Customers.InsertOnSubmit(oCustomer);
            }

            oDALDataContext.PurchaseInformations.InsertAllOnSubmit(dicIdPurchaseInformation.Values.Where(PurchaseInfo=> PurchaseInfo.IsNew));

            oDALDataContext.SubmitChanges();
            oDALDataContext.Connection.Close();

            //First Create the customet.

        }

        public static void DeleteAndCreatePurchaseInformation(Customer oCustomer, Dictionary<Guid,PurchaseInformation> dicIdPurchaseInformation, ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            if (eCustomerType == ECustomerType.Customer)
            {
                
            }
            
            //foreach (KeyValuePair<Guid,PurchaseInformation> keyvalueIdPurchase in dicIdPurchaseInformation)
            //{
            foreach (KeyValuePair<Guid, PurchaseInformation> indivisualPurchaseItem in dicIdPurchaseInformation)
            {
                PurchaseInformation oDelPurchaseInformation = indivisualPurchaseItem.Value;

                if (!oDelPurchaseInformation.IsNew)
                {
                 // oDelPurchaseInformation.Detach();
                    oDALDataContext.PurchaseInformations.Attach(oDelPurchaseInformation, true);
                }
                if (oDelPurchaseInformation.IsDeleted)
                {
                    oDALDataContext.PurchaseInformations.DeleteOnSubmit(oDelPurchaseInformation);
                }
            }

            oDALDataContext.PurchaseInformations.InsertAllOnSubmit(dicIdPurchaseInformation.Values.Where(PurchaseInfo=>PurchaseInfo.IsNew));

            oDALDataContext.SubmitChanges();

            oDALDataContext.Connection.Close();

        }

        public static List<GetPurchaseInformationResult> GetPurchaseInformationByDate(DateTime dtFromDate, DateTime dtToDate,string sMoneyReceiptNo,ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            List<GetPurchaseInformationResult> lstPurchaseInformationResult=oDALDataContext.GetPurchaseInformation(dtFromDate, dtToDate,sMoneyReceiptNo, eCustomerType.ToString()).ToList<GetPurchaseInformationResult>();

            oDALDataContext.Connection.Close();

            return lstPurchaseInformationResult;

        }

        public static Dictionary<Guid, PurchaseInformation> GetPurchaseInformationByPurchaseGroupId(Guid gPurchaseGroupId)
        {
            Dictionary<Guid, PurchaseInformation> dicPurchaseInformation = new Dictionary<Guid, PurchaseInformation>();

            DALDataContext oDALDataContext = new DALDataContext();

            dicPurchaseInformation = (from oPurchaseinfo in oDALDataContext.GetTable<PurchaseInformation>()
                                      where oPurchaseinfo.PurchaseGroupId == gPurchaseGroupId
                                      select oPurchaseinfo
                                      ).ToDictionary<PurchaseInformation, Guid>(oGetPurchaseInfo => oGetPurchaseInfo.Id);

            if (dicPurchaseInformation.Count > 0)
            {
                //string sCurrencyName=string.Empty;
                //var CurrencyNames =from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                //                        where currinfo.ID == dicPurchaseInformation.Values.First().CurrencyId
                //                        select currinfo.CurrencyName;
                
                //foreach(string scur in CurrencyNames)
                //{
                //    sCurrencyName = scur;
                //    break;
                //}

                //dicPurchaseInformation.Values = dicPurchaseInformation.Values.Select(pur => pur.CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                //                                                                                                where currinfo.ID == dicPurchaseInformation.Values.First().CurrencyId
                //                                                                                                select currinfo.CurrencyName));
                                              

                foreach (KeyValuePair<Guid,PurchaseInformation> keyVlaue in dicPurchaseInformation)
                {
                    keyVlaue.Value.CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                                                  where currinfo.ID == keyVlaue.Value.CurrencyId
                                                  select currinfo.CurrencyName).First();
                }

                //dicPurchaseInformation = dicPurchaseInformation.Values.ToList<PurchaseInformation>().Select(obj => obj.CurrencyName = sCurrencyName);

            }

            //(from oPurchaseinfo in oDALDataContext.GetTable<PurchaseInformation>()
            // where oPurchaseinfo.PurchaseGroupId == gPurchaseGroupId
            // select new PurchaseInformation
            // {
            //     Id = oPurchaseinfo.Id,
            //     CustomerType = oPurchaseinfo.CustomerType,
            //     CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
            //                     where currinfo.ID == oPurchaseinfo.CurrencyId
            //                     select currinfo.CurrencyName).ToString(),
            //     MoneyReceiptNo = oPurchaseinfo.MoneyReceiptNo,
            //     Amount = oPurchaseinfo.Amount,
            //     Rate = oPurchaseinfo.Rate,
            //     PurchaseGroupId = oPurchaseinfo.PurchaseGroupId,
            //     FormatedPurchaseDateString = oPurchaseinfo.FormatedPurchaseDateString,
            //     PurchasedDate = oPurchaseinfo.PurchasedDate,
            //     Total = oPurchaseinfo.Total
            // }
            //                          ).ToDictionary<PurchaseInformation, Guid>(oGetPurchaseInfo => oGetPurchaseInfo.Id);

            oDALDataContext.Connection.Close();

            return dicPurchaseInformation;

        }

        public static List<GetPurchaseInformationForReportResult> GetPurchaseInformationForReport(DateTime dtFromDate, DateTime dtToDate)
        {
            List<GetPurchaseInformationForReportResult> lstPurchaseInfoList = new List<GetPurchaseInformationForReportResult>();
            DALDataContext oDALDataContext = new DALDataContext();

            lstPurchaseInfoList = oDALDataContext.GetPurchaseInformationForReport(dtFromDate, dtToDate).ToList<GetPurchaseInformationForReportResult>();

            return lstPurchaseInfoList;

        }


        #endregion PurchaseInformationManagment Information Methods

        #region Customer Related Methods 

        public static Customer GetCustomerById(Guid gCustomerId)
        {
            Customer oCustomer = null;

            DALDataContext oDalContext = new DALDataContext();

            var varcust = (from cust in oDalContext.GetTable<Customer>()
                           where cust.Id == gCustomerId
                           select cust).First();

                          if(varcust!=null)
                          {
                          oCustomer=varcust;
                          }
            //oCustomer =(Customer) (from cust in oDalContext.GetTable<Customer>()
            //              where cust.Id == gCustomerId
            //              select cust);

            //if(objCust!=null)
            //{
            //  oCustomer=(Customer)objCust;
            //}

            return oCustomer;
        }

        #endregion Customer Related Methods

    }
}
