using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DALManagment;

namespace ParameterManagment
{
    public class CBankInformationManagement
    {
        public static string sConnectionString = "";
//@"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region Bank Information Methods 

        public static List<GetAllBankInformationResult> GetAllBank()
        {
            DALDataContext dbInfo = new DALDataContext();

            ISingleResult<GetAllBankInformationResult> oAllBankInformation = dbInfo.GetAllBankInformation();

            List<GetAllBankInformationResult> lstAllBank = new List<GetAllBankInformationResult>(oAllBankInformation);

            dbInfo.Connection.Close();

            return lstAllBank;
        }

        public static void CreateNewBank(BankInformation oBank)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.CreateNewBankInformation(oBank.ID, oBank.BankName,oBank.Detail, oBank.UserId);

            dbInfo.Connection.Close();
        }

        public static void UpdateBankInformation(BankInformation oBank)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.UpdateBankInformation(oBank.ID, oBank.BankName,oBank.Detail);

            dbInfo.Connection.Close();
        }

        public static void DeleteBankInformation(BankInformation oBank)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.DeleteBankInformation(oBank.ID);

            dbInfo.Connection.Close();
        }

        #endregion Bank Information Methods

        
    }
}
