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

public partial class PurchaseFromMoneyChanger : System.Web.UI.Page
{
    string sSessionKeyPurchaseCurrencyInformationList = "PurchaseCurrencyInformationList";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllMoneyChanger();
            LoadAllCurrency();
            txtPurchaseDate.Text = DateTime.Today.ToString("dd-MM-yyyy");

            #region When comes from list page

            if (!string.IsNullOrEmpty(Request.QueryString["PurchaseGroupId"]))
            {
                Guid gPurchaseGroupId = new Guid(Request.QueryString["PurchaseGroupId"]);

                Dictionary<Guid, PurchaseInformation> dicPurchaseInformation = CPurchaseInformationManagment.GetPurchaseInformationByPurchaseGroupId(gPurchaseGroupId);

                if (dicPurchaseInformation.Count > 0)
                {
                    CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, dicPurchaseInformation);

                    hdnPurchaseGroupId.Value = dicPurchaseInformation.Values.First().PurchaseGroupId.ToString();
                    txtPurchaseDate.Text = dicPurchaseInformation.Values.First().FormatedPurchaseDateString;
                    txtRefMoneyReceiptNo.Text = dicPurchaseInformation.Values.First().RefMoneyReceiptNo;

                    drpMoneyChanger.SelectedValue = dicPurchaseInformation.Values.First().Cust_Id.ToString();

                    gvCurrenyPurchaseInfoList.DataSource = dicPurchaseInformation.Values;
                    gvCurrenyPurchaseInfoList.DataBind();
                }
            }

            #endregion When comes from list page 
        }
    }

    #region Developer defined Methods 

    private void LoadAllCurrency()
    {
        List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        drpCurrency.DataTextField = "CurrencyName";
        drpCurrency.DataValueField = "Id";

        drpCurrency.DataSource = lstAllCurrencyInformationList;
        drpCurrency.DataBind();

    }

    protected void LoadAllMoneyChanger()
    {
        List<GetAllMoneyChangerInformationResult> lstAllMoneyChangerInfoamationList = CMoneyChangerInformationManagement.GetAllMoneyChanger();

        drpMoneyChanger.DataTextField = "MoneyChangerName";
        drpMoneyChanger.DataValueField = "Id";

        drpMoneyChanger.DataSource = lstAllMoneyChangerInfoamationList;
        drpMoneyChanger.DataBind();


    }

    private void SavePurchaseInformation(Operation eOperation, Guid gPurchaseGroupId)
    {
        Guid gCustomerId = new Guid(drpMoneyChanger.SelectedValue);
        Dictionary<Guid, PurchaseInformation> dicIdPurchaseInformation = null;

        Customer oCustomer = new Customer();

        oCustomer.Id = gCustomerId;

        if (CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList) != null)
        {
            dicIdPurchaseInformation = (Dictionary<Guid, PurchaseInformation>)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList);

            DateTime dtPurchasedDateTime = CBusinessUtility.GetValidatedDate(txtPurchaseDate.Text);

            foreach (KeyValuePair<Guid, PurchaseInformation> indivisualPurchaseItem in dicIdPurchaseInformation)
            {
                indivisualPurchaseItem.Value.PurchaseGroupId = gPurchaseGroupId;
                indivisualPurchaseItem.Value.Cust_Id = gCustomerId;
                //indivisualPurchaseItem.Value.AccNo = txtAccountNo.Text;
                indivisualPurchaseItem.Value.RefMoneyReceiptNo = txtRefMoneyReceiptNo.Text;
                indivisualPurchaseItem.Value.CreateDateTime = DateTime.Today;
                indivisualPurchaseItem.Value.PurchasedDate = dtPurchasedDateTime;
            }

            if (Operation.Create == eOperation)
            {
                CPurchaseInformationManagment.CreatePurchaseInformation(oCustomer, dicIdPurchaseInformation, ECustomerType.Bank);
            }
            else if (Operation.Update == eOperation)
            {
                CPurchaseInformationManagment.DeleteAndCreatePurchaseInformation(oCustomer, dicIdPurchaseInformation, ECustomerType.Bank);
            }

            Dictionary<Guid, PurchaseInformation> tempdicIdPurchaseInformation = new Dictionary<Guid, PurchaseInformation>();

            foreach (PurchaseInformation oPurchaseInfo in dicIdPurchaseInformation.Values)
            {
                if (!oPurchaseInfo.IsDeleted)
                {
                    oPurchaseInfo.IsNew = false;
                    tempdicIdPurchaseInformation.Add(oPurchaseInfo.Id, oPurchaseInfo);
                }
            }

            CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, tempdicIdPurchaseInformation);

            hdnPurchaseGroupId.Value = gPurchaseGroupId.ToString();
        }

    }

    #endregion Developer defined Methods

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Dictionary<Guid, PurchaseInformation> dicIdPurchaseInformation = null;

        if (CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList) != null)
        {
            dicIdPurchaseInformation = (Dictionary<Guid, PurchaseInformation>)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList);
        }
        else
        {
            dicIdPurchaseInformation = new Dictionary<Guid, PurchaseInformation>();
        }

        PurchaseInformation oPurchaseInformation = new PurchaseInformation();

        oPurchaseInformation.Id = Guid.NewGuid();
        oPurchaseInformation.CustomerType = (int)ECustomerType.MoneyChanger;
        oPurchaseInformation.MoneyReceiptNo = txtMoneyReceiptNo.Text;
        oPurchaseInformation.CurrencyId = new Guid(drpCurrency.SelectedValue);
        oPurchaseInformation.CurrencyName = drpCurrency.SelectedItem.Text;
        oPurchaseInformation.Amount = Convert.ToDecimal(txtAmount.Text);
        oPurchaseInformation.Rate = Convert.ToDecimal(txtRate.Text);
        oPurchaseInformation.Total = Convert.ToDecimal(txtTotalAmount.Text);
        oPurchaseInformation.IsNew = true;

        dicIdPurchaseInformation.Add(oPurchaseInformation.Id, oPurchaseInformation);

        CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, dicIdPurchaseInformation);

        gvCurrenyPurchaseInfoList.DataSource = dicIdPurchaseInformation.Values;
        gvCurrenyPurchaseInfoList.DataBind();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Guid gPurchaseGroupId = Guid.Empty;

        if (string.IsNullOrEmpty(hdnPurchaseGroupId.Value))
        {
            gPurchaseGroupId = Guid.NewGuid();
            SavePurchaseInformation(Operation.Create, gPurchaseGroupId);
        }
        else
        {
            gPurchaseGroupId = new Guid(hdnPurchaseGroupId.Value);
            SavePurchaseInformation(Operation.Update, gPurchaseGroupId);
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }
    protected void gvCurrenyPurchaseInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvRowToDelete = gvCurrenyPurchaseInfoList.Rows[e.RowIndex];

        Guid gPurchaseIdToDelete = new Guid(gvRowToDelete.Cells[1].Text);

        Dictionary<Guid, PurchaseInformation> dicIdPurchaseInformation = (Dictionary<Guid, PurchaseInformation>)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList);

        if (dicIdPurchaseInformation[gPurchaseIdToDelete].IsNew)
        {
            dicIdPurchaseInformation.Remove(gPurchaseIdToDelete);
        }
        else
        {
            dicIdPurchaseInformation[gPurchaseIdToDelete].IsDeleted = true;
        }

        CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, dicIdPurchaseInformation);

        gvCurrenyPurchaseInfoList.DataSource = dicIdPurchaseInformation.Values.Where(PurchaseInfo => !PurchaseInfo.IsDeleted);
        gvCurrenyPurchaseInfoList.DataBind();
    }
}
