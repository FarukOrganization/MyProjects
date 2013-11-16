using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using DALManagment;

namespace ParameterManagment
{
   public class CBranchInformationManagement
    {
        //public static string sConnectionString = @"Data Source=.\sqlexpress;AttachDbFilename=C:\Developments\DB\dbMoneyChangerMgt.mdf;Integrated Security=True";

        #region Branch Information Methods 

        public static List<GetAllBranchInformationByBankIdResult> GetAllBranch(Guid gBankId)
        {
            DALDataContext dbInfo = new DALDataContext();

            ISingleResult<GetAllBranchInformationByBankIdResult> oAllBranchInformation = dbInfo.GetAllBranchInformationByBankId(gBankId);

            List<GetAllBranchInformationByBankIdResult> lstAllBranch = new List<GetAllBranchInformationByBankIdResult>(oAllBranchInformation);

            dbInfo.Connection.Close();

            return lstAllBranch;
        }

        public static void CreateNewBranch(BankBranchInformation oBranch)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.CreateNewBranchInformation(oBranch.ID,oBranch.BankId,oBranch.BranchName, oBranch.Detail, oBranch.UserId);

            dbInfo.Connection.Close();
        }

        public static void UpdateBranchInformation(BankBranchInformation oBranch)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.UpdateBranchInformation(oBranch.ID, oBranch.BranchName, oBranch.Detail);

            dbInfo.Connection.Close();
        }

        public static void DeleteBranchInformation(BankBranchInformation oBranch)
        {
            DALDataContext dbInfo = new DALDataContext();

            dbInfo.DeleteBranchInformation(oBranch.ID);

            dbInfo.Connection.Close();
        }

        #endregion Branch Information Methods
    }
}
