using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using ParameterManagment;
using DALManagment;

public partial class BankInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllBank();
        }
    }

    protected void LoadAllBank()
    {
        List<GetAllBankInformationResult> lstAllBankInfoamationList = CBankInformationManagement.GetAllBank();

        gvBankInfoList.DataSource = lstAllBankInfoamationList;
        gvBankInfoList.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        BankInformation oBankInformation = new BankInformation();

        oBankInformation.BankName = txtBankName.Text;
        oBankInformation.Detail = txtDetail.Text;
        oBankInformation.UserId = Guid.Empty;

        if (txtBankId.Text == null || txtBankId.Text == string.Empty)
        {
            oBankInformation.ID = Guid.NewGuid();
            CBankInformationManagement.CreateNewBank(oBankInformation);
        }
        else
        {
            oBankInformation.ID = new Guid(txtBankId.Text);

            CBankInformationManagement.UpdateBankInformation(oBankInformation);
        }

        LoadAllBank();

        txtBankName.Text = string.Empty;
        txtBankId.Text = string.Empty;
        txtDetail.Text = string.Empty;

        //Thread.Sleep(5000);

    }

    protected void gvBankInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Thread.Sleep(5000);
        gvBankInfoList.PageIndex = e.NewPageIndex;
        LoadAllBank();
    }

    protected void gvBankInfoList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iEditedRowIndex = e.NewEditIndex;

        txtBankId.Text = gvBankInfoList.Rows[iEditedRowIndex].Cells[1].Text;
        txtBankName.Text = gvBankInfoList.Rows[iEditedRowIndex].Cells[2].Text;
        txtDetail.Text = gvBankInfoList.Rows[iEditedRowIndex].Cells[3].Text;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtBankId.Text = string.Empty;
        txtBankName.Text = string.Empty;
        txtDetail.Text = string.Empty;
    }

    protected void gvBankInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        BankInformation oBankInformation = new BankInformation();
        oBankInformation.ID = new Guid(gvBankInfoList.Rows[e.RowIndex].Cells[1].Text);

        CBankInformationManagement.DeleteBankInformation(oBankInformation);

        LoadAllBank();
    }

}
