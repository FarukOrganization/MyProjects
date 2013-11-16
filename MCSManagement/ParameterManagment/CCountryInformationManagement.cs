using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DALManagment;

namespace ParameterManagment
{
    public class CCountryInformationManagement
    {
        //public static string sConnectionString=@"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region Country Information Methods 

        public static List<GetAllCountryInformationResult> GetAllCountry()
        {
            DALDataContext dbInfo = new DALDataContext();

            ISingleResult<GetAllCountryInformationResult> oAllCountryInformation = dbInfo.GetAllCountryInformation();

            List<GetAllCountryInformationResult> lstAllCountry = new List<GetAllCountryInformationResult>(oAllCountryInformation);

            dbInfo.Connection.Close();

            return lstAllCountry;
        }

        public static void CreateNewCountry(CountryInformation oCountry)
        {
            DALDataContext dbInfo = new DALDataContext();
            
            dbInfo.CreateNewCountryInformation(oCountry.ID, oCountry.CountryName, oCountry.UserId);

            dbInfo.Connection.Close();
        }

        public static void UpdateCountryInformation(CountryInformation oCountry)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.UpdateCountryInformation(oCountry.ID,oCountry.CountryName);

            dbInfo.Connection.Close();
        }

        #endregion Country Information Methods

        

    }
}
