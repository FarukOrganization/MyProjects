using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParameterManagment;
using DALManagment;

public partial class MoneyChangerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllMoneyChanger();
        }
    }

    protected void LoadAllMoneyChanger()
    {
        List<GetAllMoneyChangerInformationResult> lstAllMoneyChangerInfoamationList = CMoneyChangerInformationManagement.GetAllMoneyChanger();

        gvMoneyChangerInfoList.DataSource = lstAllMoneyChangerInfoamationList;
        gvMoneyChangerInfoList.DataBind();


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        MoneyChangerInformation oMoneyChangerInformation = new MoneyChangerInformation();

        oMoneyChangerInformation.MoneyChangerName = txtMoneyChangerName.Text;
        oMoneyChangerInformation.Owner = txtOwner.Text;
        oMoneyChangerInformation.Address = txtAddress.Text;
        oMoneyChangerInformation.UserId = Guid.Empty;

        if (txtMoneyChangerId.Text == null || txtMoneyChangerId.Text == string.Empty)
        {
            oMoneyChangerInformation.ID = Guid.NewGuid();
            CMoneyChangerInformationManagement.CreateNewMoneyChanger(oMoneyChangerInformation);
        }
        else
        {
            oMoneyChangerInformation.ID = new Guid(txtMoneyChangerId.Text);

            CMoneyChangerInformationManagement.UpdateMoneyChangerInformation(oMoneyChangerInformation);
        }

        LoadAllMoneyChanger();

        txtMoneyChangerName.Text = string.Empty;
        txtMoneyChangerId.Text = string.Empty;
        txtOwner.Text = string.Empty;
        txtAddress.Text = string.Empty;

        //Thread.Sleep(5000);

    }

    protected void gvMoneyChangerInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvMoneyChangerInfoList.PageIndex = e.NewPageIndex;
        LoadAllMoneyChanger();
    }

    protected void gvMoneyChangerInfoList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iEditedRowIndex = e.NewEditIndex;

        txtMoneyChangerId.Text = gvMoneyChangerInfoList.Rows[iEditedRowIndex].Cells[1].Text;
        txtMoneyChangerName.Text = gvMoneyChangerInfoList.Rows[iEditedRowIndex].Cells[2].Text;
        txtOwner.Text = gvMoneyChangerInfoList.Rows[iEditedRowIndex].Cells[3].Text;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtMoneyChangerId.Text = string.Empty;
        txtMoneyChangerName.Text = string.Empty;
        txtOwner.Text = string.Empty;
        txtAddress.Text = string.Empty;
    }

    protected void gvMoneyChangerInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        MoneyChangerInformation oMoneyChangerInformation = new MoneyChangerInformation();
        oMoneyChangerInformation.ID = new Guid(gvMoneyChangerInfoList.Rows[e.RowIndex].Cells[1].Text);

        CMoneyChangerInformationManagement.DeleteMoneyChangerInformation(oMoneyChangerInformation);

        LoadAllMoneyChanger();
    }
}
