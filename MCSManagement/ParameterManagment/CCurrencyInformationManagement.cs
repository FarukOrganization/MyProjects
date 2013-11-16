using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DALManagment;

namespace ParameterManagment
{
    public class CCurrencyInformationManagement
    {
        //public static string sConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region Currency Information Methods

        public static List<GetAllCurrencyInformationResult> GetAllCurrency()
        {
            DALDataContext dbInfo = new DALDataContext();

            ISingleResult<GetAllCurrencyInformationResult> oAllCurrencyInformation = dbInfo.GetAllCurrencyInformation();

            List<GetAllCurrencyInformationResult> lstAllCurrency = new List<GetAllCurrencyInformationResult>(oAllCurrencyInformation);

            dbInfo.Connection.Close();

            return lstAllCurrency;
        }

        public static void CreateNewCurrency(CurrencyInformation oCurrency)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.CreateNewCurrencyInformation(oCurrency.ID, oCurrency.CurrencyName,oCurrency.CountryId, oCurrency.UserId);

            dbInfo.Connection.Close();
        }

        public static void UpdateCurrencyInformation(CurrencyInformation oCurrency)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.UpdateCurrencyInformation(oCurrency.ID, oCurrency.CurrencyName,oCurrency.CountryId);

            dbInfo.Connection.Close();
        }

        public static void DeleteCurrencyInformation(CurrencyInformation oCurrency)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.DeleteCurrencyInformation(oCurrency.ID);

            dbInfo.Connection.Close();
        }

        #endregion Currency Information Methods
    }
}
