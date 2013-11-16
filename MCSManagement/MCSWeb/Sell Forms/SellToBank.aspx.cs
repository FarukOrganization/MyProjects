using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParameterManagment;
using DALManagment;
using Utility;
using BusinessManagement;

public partial class SellToBank : System.Web.UI.Page
{
    string sSessionKeySellCurrencyInformationList = "SellCurrencyInformationList";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CSessionUtil.RemoveSesstion(sSessionKeySellCurrencyInformationList);
            List<GetAllBankInformationResult> lstAllBankInfoamationList = LoadAllBank();
            LoadCurrency();
            txtSellDate.Text = DateTime.Today.ToString("dd-MM-yyyy");

            #region When comes from list page 

            if (!string.IsNullOrEmpty(Request.QueryString["SellGroupId"]))
            {
                Guid gSellGroupId = new Guid(Request.QueryString["SellGroupId"]);

                Dictionary<Guid, SellInformation> dicSellInformation = CSellInformationManagment.GetSellInformationBySellGroupId(gSellGroupId);

                if (dicSellInformation.Count > 0)
                {
                    CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, dicSellInformation);

                    hdnSellGroupId.Value = dicSellInformation.Values.First().SellGroupId.ToString();
                    txtSellDate.Text = dicSellInformation.Values.First().FormatedSoldDateString;
                    txtAccountNo.Text = dicSellInformation.Values.First().AccNo;
                    txtRefMoneyReceiptNo.Text = dicSellInformation.Values.First().RefMoneyReceiptNo;

                    drpBank.SelectedValue = dicSellInformation.Values.First().Cust_Id.ToString();

                    gvCurrenySellInfoList.DataSource = dicSellInformation.Values;
                    gvCurrenySellInfoList.DataBind();
                }
            }

            #endregion When comes from list page 

            LoadBranch();
        }
    }

    #region Developer defined Methods 

    protected List<GetAllBankInformationResult> LoadAllBank()
    {
        List<GetAllBankInformationResult> lstAllBankInfoamationList = CBankInformationManagement.GetAllBank();

        drpBank.DataTextField = "BankName";
        drpBank.DataValueField = "Id";

        drpBank.DataSource = lstAllBankInfoamationList;
        drpBank.DataBind();

        return lstAllBankInfoamationList;
    }

    private void LoadBranch()
    {
        Guid gBankId = new Guid(drpBank.SelectedValue);
        List<GetAllBranchInformationByBankIdResult> lstBranchList = CBranchInformationManagement.GetAllBranch(gBankId);

        drpBranch.DataTextField = "BranchName";
        drpBranch.DataValueField = "BankId";

        drpBranch.DataSource = lstBranchList;
        drpBranch.DataBind();

    }

    private void LoadCurrency()
    {
        List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        drpCurrency.DataTextField = "CurrencyName";
        drpCurrency.DataValueField = "Id";

        drpCurrency.DataSource = lstAllCurrencyInformationList;
        drpCurrency.DataBind();

    }

    private void SaveSellInformation(Operation eOperation, Guid gSellGroupId)
    {
        Guid gCustomerId =new Guid(drpBranch.SelectedValue);
        Dictionary<Guid, SellInformation> dicIdSellInformation = null;
        
        Customer oCustomer = new Customer();

        oCustomer.Id = gCustomerId;

        if (CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList) != null)
        {
            dicIdSellInformation = (Dictionary<Guid, SellInformation>)CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList);

            DateTime dtSoldDateTime = CBusinessUtility.GetValidatedDate(txtSellDate.Text);

            foreach (KeyValuePair<Guid, SellInformation> indivisualSellItem in dicIdSellInformation)
            {
                indivisualSellItem.Value.SellGroupId = gSellGroupId;
                indivisualSellItem.Value.Cust_Id = gCustomerId;
                indivisualSellItem.Value.AccNo = txtAccountNo.Text;
                indivisualSellItem.Value.RefMoneyReceiptNo = txtRefMoneyReceiptNo.Text;
                indivisualSellItem.Value.CreateDateTime = DateTime.Today;
                indivisualSellItem.Value.SoldDate = dtSoldDateTime;
            }

            if (Operation.Create == eOperation)
            {
                CSellInformationManagment.CreateSellInformation(oCustomer, dicIdSellInformation, ECustomerType.Bank);
            }
            else if (Operation.Update == eOperation)
            {
                CSellInformationManagment.DeleteAndCreateSellInformation(oCustomer, dicIdSellInformation, ECustomerType.Bank);
            }

            Dictionary<Guid, SellInformation> tempdicIdSellInformation = new Dictionary<Guid, SellInformation>();

            foreach (SellInformation oSellInfo in dicIdSellInformation.Values)
            {
                if (!oSellInfo.IsDeleted)
                {
                    oSellInfo.IsNew = false;
                    tempdicIdSellInformation.Add(oSellInfo.Id, oSellInfo);
                }
            }

            CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, tempdicIdSellInformation);

            hdnSellGroupId.Value = gSellGroupId.ToString();
        }

    }

    #endregion Developer defined Methods

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        Dictionary<Guid, SellInformation> dicIdSellInformation = null;

        if (CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList) != null)
        {
            dicIdSellInformation = (Dictionary<Guid, SellInformation>)CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList);
        }
        else
        {
            dicIdSellInformation = new Dictionary<Guid, SellInformation>();
        }

        SellInformation oSellInformation = new SellInformation();

        oSellInformation.Id = Guid.NewGuid();
        oSellInformation.CustomerType = (int)ECustomerType.Bank;
        oSellInformation.MoneyReceiptNo = txtMoneyReceiptNo.Text;
        oSellInformation.CurrencyId = new Guid(drpCurrency.SelectedValue);
        oSellInformation.CurrencyName = drpCurrency.SelectedItem.Text;
        oSellInformation.Amount = Convert.ToDecimal(txtAmount.Text);
        oSellInformation.Rate = Convert.ToDecimal(txtRate.Text);
        oSellInformation.Total = Convert.ToDecimal(txtTotalAmount.Text);
        oSellInformation.IsNew = true;

        dicIdSellInformation.Add(oSellInformation.Id, oSellInformation);

        CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, dicIdSellInformation);

        gvCurrenySellInfoList.DataSource = dicIdSellInformation.Values;
        gvCurrenySellInfoList.DataBind();

    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Guid gSellGroupId = Guid.Empty;

        if (string.IsNullOrEmpty(hdnSellGroupId.Value))
        {
            gSellGroupId = Guid.NewGuid();
            SaveSellInformation(Operation.Create, gSellGroupId);
        }
        else
        {
            gSellGroupId = new Guid(hdnSellGroupId.Value);
            SaveSellInformation(Operation.Update, gSellGroupId);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void drpBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBranch();
    }
    protected void gvCurrenySellInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvRowToDelete = gvCurrenySellInfoList.Rows[e.RowIndex];

        Guid gSellIdToDelete = new Guid(gvRowToDelete.Cells[1].Text);

        Dictionary<Guid, SellInformation> dicIdSellInformation = (Dictionary<Guid, SellInformation>)CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList);

        if (dicIdSellInformation[gSellIdToDelete].IsNew)
        {
            dicIdSellInformation.Remove(gSellIdToDelete);
        }
        else
        {
            dicIdSellInformation[gSellIdToDelete].IsDeleted = true;
        }

        CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, dicIdSellInformation);

        gvCurrenySellInfoList.DataSource = dicIdSellInformation.Values.Where(SellInfo => !SellInfo.IsDeleted);
        gvCurrenySellInfoList.DataBind();
    }
}
