using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DALManagment;
using System.Data.Linq;
using Utility;

namespace BusinessManagement
{
   public class CSellInformationManagment
    {
        //public static string sConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region SellInformationManagment Information Methods

        public static void CreateSellInformation(Customer oCustomer, Dictionary<Guid, SellInformation> dicIdSellInformation, ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            if (eCustomerType == ECustomerType.Customer)
            {
                oDALDataContext.Customers.InsertOnSubmit(oCustomer);
            }

            oDALDataContext.SellInformations.InsertAllOnSubmit(dicIdSellInformation.Values.Where(SellInfo => SellInfo.IsNew));

            oDALDataContext.SubmitChanges();
            oDALDataContext.Connection.Close();

            //First Create the customet.

        }

        public static void DeleteAndCreateSellInformation(Customer oCustomer, Dictionary<Guid, SellInformation> dicIdSellInformation, ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            //if (eCustomerType == ECustomerType.Customer)
            //{
            //    var otempcustomer = from a in oDALDataContext.GetTable<Customer>()
            //                             where a.Id==oCustomer.Id 
            //                             select a ;

            //    foreach (Customer obj in otempcustomer)
            //    {
            //        oCustomer.Detach();
            //        oDALDataContext.Customers.Attach(oCustomer, obj);
            //    }

            //    //oCustomer.Detach();
            //    //oDALDataContext.Customers.Attach(oCustomer,(Customer)otempcustomer);
            //}

            //foreach (KeyValuePair<Guid,SellInformation> keyvalueIdSell in dicIdSellInformation)
            //{
            foreach (KeyValuePair<Guid, SellInformation> indivisualSellItem in dicIdSellInformation)
            {
                SellInformation oDelSellInformation = indivisualSellItem.Value;

                if (!oDelSellInformation.IsNew)
                {
                    //oDelSellInformation.Detach();
                    oDALDataContext.SellInformations.Attach(oDelSellInformation, true);
                }
                if (oDelSellInformation.IsDeleted)
                {
                    oDALDataContext.SellInformations.DeleteOnSubmit(oDelSellInformation);
                }
            }

            oDALDataContext.SellInformations.InsertAllOnSubmit(dicIdSellInformation.Values.Where(SellInfo => SellInfo.IsNew));

            oDALDataContext.SubmitChanges();

            oDALDataContext.Connection.Close();

        }

        public static List<GetSellInformationResult> GetSellInformationByDate(DateTime dtFromDate, DateTime dtToDate, string sMoneyReceiptNo, ECustomerType eCustomerType)
        {
            DALDataContext oDALDataContext = new DALDataContext();

            List<GetSellInformationResult> lstSellInformationResult = oDALDataContext.GetSellInformation(dtFromDate, dtToDate, sMoneyReceiptNo, eCustomerType.ToString()).ToList<GetSellInformationResult>();

            oDALDataContext.Connection.Close();

            return lstSellInformationResult;

        }

        public static Dictionary<Guid, SellInformation> GetSellInformationBySellGroupId(Guid gSellGroupId)
        {
            Dictionary<Guid, SellInformation> dicSellInformation = new Dictionary<Guid, SellInformation>();

            DALDataContext oDALDataContext = new DALDataContext();

            dicSellInformation = (from oSellinfo in oDALDataContext.GetTable<SellInformation>()
                                      where oSellinfo.SellGroupId == gSellGroupId
                                      select oSellinfo
                                      ).ToDictionary<SellInformation, Guid>(oGetSellInfo => oGetSellInfo.Id);

            if (dicSellInformation.Count > 0)
            {
                //string sCurrencyName=string.Empty;
                //var CurrencyNames =from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                //                        where currinfo.ID == dicSellInformation.Values.First().CurrencyId
                //                        select currinfo.CurrencyName;

                //foreach(string scur in CurrencyNames)
                //{
                //    sCurrencyName = scur;
                //    break;
                //}

                //dicSellInformation.Values = dicSellInformation.Values.Select(pur => pur.CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                //                                                                                                where currinfo.ID == dicSellInformation.Values.First().CurrencyId
                //                                                                                                select currinfo.CurrencyName));


                foreach (KeyValuePair<Guid, SellInformation> keyVlaue in dicSellInformation)
                {
                    keyVlaue.Value.CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
                                                   where currinfo.ID == keyVlaue.Value.CurrencyId
                                                   select currinfo.CurrencyName).First();
                }

                //dicSellInformation = dicSellInformation.Values.ToList<SellInformation>().Select(obj => obj.CurrencyName = sCurrencyName);

            }

            //(from oSellinfo in oDALDataContext.GetTable<SellInformation>()
            // where oSellinfo.SellGroupId == gSellGroupId
            // select new SellInformation
            // {
            //     Id = oSellinfo.Id,
            //     CustomerType = oSellinfo.CustomerType,
            //     CurrencyName = (from currinfo in oDALDataContext.GetTable<CurrencyInformation>()
            //                     where currinfo.ID == oSellinfo.CurrencyId
            //                     select currinfo.CurrencyName).ToString(),
            //     MoneyReceiptNo = oSellinfo.MoneyReceiptNo,
            //     Amount = oSellinfo.Amount,
            //     Rate = oSellinfo.Rate,
            //     SellGroupId = oSellinfo.SellGroupId,
            //     FormatedSellDateString = oSellinfo.FormatedSellDateString,
            //     SelldDate = oSellinfo.SelldDate,
            //     Total = oSellinfo.Total
            // }
            //                          ).ToDictionary<SellInformation, Guid>(oGetSellInfo => oGetSellInfo.Id);

            oDALDataContext.Connection.Close();

            return dicSellInformation;

        }

        public static List<GetSellInformationForReportResult> GetSellInformationForReport(DateTime dtFromDate, DateTime dtToDate)
        {
            List<GetSellInformationForReportResult> lstSellInfoList = new List<GetSellInformationForReportResult>();
            DALDataContext oDALDataContext = new DALDataContext();

            lstSellInfoList = oDALDataContext.GetSellInformationForReport(dtFromDate, dtToDate).ToList<GetSellInformationForReportResult>();

            return lstSellInfoList;

        }


        #endregion SellInformationManagment Information Methods
    }
}
