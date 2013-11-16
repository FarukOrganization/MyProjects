using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DALManagment;

namespace ParameterManagment
{
    public class CMoneyChangerInformationManagement
    {
        //public static string sConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region MoneyChanger Information Methods

        public static List<GetAllMoneyChangerInformationResult> GetAllMoneyChanger()
        {
            DALDataContext dbInfo = new DALDataContext();

            

            ISingleResult<GetAllMoneyChangerInformationResult> oAllMoneyChangerInformation = dbInfo.GetAllMoneyChangerInformation();

            List<GetAllMoneyChangerInformationResult> lstAllMoneyChanger = new List<GetAllMoneyChangerInformationResult>(oAllMoneyChangerInformation);

            dbInfo.Connection.Close();

            return lstAllMoneyChanger;
        }

        public static void CreateNewMoneyChanger(MoneyChangerInformation oMoneyChanger)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.CreateNewMoneyChangerInformation(oMoneyChanger.ID, oMoneyChanger.MoneyChangerName,oMoneyChanger.Owner,oMoneyChanger.Address, oMoneyChanger.UserId);

            dbInfo.Connection.Close();
        }

        public static void UpdateMoneyChangerInformation(MoneyChangerInformation oMoneyChanger)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.UpdateMoneyChangerInformation(oMoneyChanger.ID, oMoneyChanger.MoneyChangerName,oMoneyChanger.Owner,oMoneyChanger.Address);

            dbInfo.Connection.Close();
        }

        public static void DeleteMoneyChangerInformation(MoneyChangerInformation oMoneyChanger)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.DeleteMoneyChangerInformation(oMoneyChanger.ID);

            dbInfo.Connection.Close();
        }

        #endregion MoneyChanger Information Methods

    }
}
