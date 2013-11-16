using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DALManagment;
using Utility;
using BusinessManagement;

public partial class PurchaseInformationList : System.Web.UI.Page
{
    #region Page Event handlers 

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #endregion Page Event handlers

    #region Developer defined Methods 


    #endregion Developer defined Methods

    #region Page Control Event handlers 

    protected void btnFind_Click(object sender, EventArgs e)
    {
        LoadDesiredMoneyReceipts();

    }

    private void LoadDesiredMoneyReceipts()
    {
        string sMoneyReceiptNo = txtMoneyReceiptNo.Text;
        DateTime dtFromDate = CBusinessUtility.GetValidatedDate(txtFromDate.Text);
        DateTime dtToDate = CBusinessUtility.GetValidatedDate(txtToDate.Text);

        List<GetPurchaseInformationResult> lstPurchaseInformationResult = CPurchaseInformationManagment.GetPurchaseInformationByDate(dtFromDate, dtToDate, sMoneyReceiptNo, ECustomerType.None);

        gvPurchasedInformationList.DataSource = lstPurchaseInformationResult;
        gvPurchasedInformationList.DataBind();
    }

    protected void gvPurchasedInformationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvPurchasedInformationList.PageIndex = e.NewPageIndex;

        LoadDesiredMoneyReceipts();
    }

    #endregion Page Control Event handlers

}
