using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParameterManagment;
using DALManagment;

public partial class BranchInformation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllBank();
        }

    }

    #region Developer Defined Methods 

    protected void LoadAllBank()
    {
        List<GetAllBankInformationResult> lstAllBankInfoamationList = CBankInformationManagement.GetAllBank();

        drpBank.DataSource = lstAllBankInfoamationList;
        drpBank.DataBind();
    }

    private void LoadBranch()
    {
        Guid gBankId = new Guid(drpBank.SelectedValue);
        List<GetAllBranchInformationByBankIdResult> lstBranchList = CBranchInformationManagement.GetAllBranch(gBankId);

        gvBranchInfoList.DataSource = lstBranchList;
        gvBranchInfoList.DataBind();

    }

    #endregion Developer Defined Methods


    protected void btnSave_Click(object sender, EventArgs e)
    {
        BankBranchInformation oBankBranchInformation = new BankBranchInformation();

        oBankBranchInformation.BankId = new Guid(drpBank.SelectedValue);
        oBankBranchInformation.BranchName = txtBranchName.Text;
        oBankBranchInformation.Detail = txtDetail.Text;
        oBankBranchInformation.UserId = Guid.Empty;

        if (txtBranchId.Text == null || txtBranchId.Text == string.Empty)
        {
            oBankBranchInformation.ID = Guid.NewGuid();
            CBranchInformationManagement.CreateNewBranch(oBankBranchInformation);
        }
        else
        {
            oBankBranchInformation.ID = new Guid(txtBranchId.Text);

            CBranchInformationManagement.UpdateBranchInformation(oBankBranchInformation);
        }

        LoadBranch();

        txtBranchName.Text = string.Empty;
        txtBranchId.Text = string.Empty;
        txtDetail.Text = string.Empty;
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtBranchName.Text = string.Empty;
        txtBranchId.Text = string.Empty;
        txtDetail.Text = string.Empty;

    }
    protected void gvBranchInfoList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iEditedRowIndex = e.NewEditIndex;

        txtBranchId.Text = gvBranchInfoList.Rows[iEditedRowIndex].Cells[1].Text;
        txtBranchName.Text = gvBranchInfoList.Rows[iEditedRowIndex].Cells[3].Text;
        txtDetail.Text = gvBranchInfoList.Rows[iEditedRowIndex].Cells[4].Text;
    }
    protected void gvBranchInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BankBranchInformation oBankBranchInformation = new BankBranchInformation();
        oBankBranchInformation.ID = new Guid(gvBranchInfoList.Rows[e.RowIndex].Cells[1].Text);

        CBranchInformationManagement.DeleteBranchInformation(oBankBranchInformation);

        LoadBranch();

    }
    protected void gvBranchInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBranchInfoList.PageIndex = e.NewPageIndex;
        LoadBranch();
    }
    protected void drpBank_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadBranch();
    }

   
}
