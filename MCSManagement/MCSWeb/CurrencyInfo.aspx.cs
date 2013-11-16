using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ParameterManagment;
using DALManagment;

public partial class CurrencyInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllCountry();
            LoadAllCurrency();
        }
    }

    protected void LoadAllCountry()
    {
        List<GetAllCountryInformationResult> lstAllCountryInfoamationList = CCountryInformationManagement.GetAllCountry();

        drplstCountryList.DataTextField = "CountryName";
        drplstCountryList.DataValueField = "Id";

        drplstCountryList.DataSource = lstAllCountryInfoamationList;
        drplstCountryList.DataBind();
    }

    protected void LoadAllCurrency()
    {
        List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        gvCurrencyInfoList.DataSource = lstAllCurrencyInformationList;
        gvCurrencyInfoList.DataBind();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtCurrencyId.Text = string.Empty;
        txtCurrencyName.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CurrencyInformation oCurrencyInformation = new CurrencyInformation();

        oCurrencyInformation.CurrencyName = txtCurrencyName.Text;
        oCurrencyInformation.UserId = Guid.Empty;
        oCurrencyInformation.CountryId = new Guid(drplstCountryList.SelectedValue);

        if (txtCurrencyId.Text == null || txtCurrencyId.Text == string.Empty)
        {
            oCurrencyInformation.ID = Guid.NewGuid();
            CCurrencyInformationManagement.CreateNewCurrency(oCurrencyInformation);
        }
        else
        {
            oCurrencyInformation.ID = new Guid(txtCurrencyId.Text);

            CCurrencyInformationManagement.UpdateCurrencyInformation(oCurrencyInformation);
        }

        LoadAllCurrency();

        txtCurrencyName.Text = string.Empty;
        txtCurrencyId.Text = string.Empty;
    }

    protected void gvCurrencyInfoList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iEditedRowIndex = e.NewEditIndex;

        txtCurrencyId.Text = gvCurrencyInfoList.Rows[iEditedRowIndex].Cells[1].Text;
        txtCurrencyName.Text = gvCurrencyInfoList.Rows[iEditedRowIndex].Cells[2].Text;

        //txtCurrencyId.Text = gvCurrencyInfoList.Rows[iEditedRowIndex].Cells[3].Text;
        //txtCurrencyName.Text = gvCurrencyInfoList.Rows[iEditedRowIndex].Cells[2].Text;

        drplstCountryList.SelectedValue=gvCurrencyInfoList.Rows[iEditedRowIndex].Cells[3].Text;

        //drplstCountryList.SelectedIndex
    }
    protected void gvCurrencyInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCurrencyInfoList.PageIndex = e.NewPageIndex;

        LoadAllCurrency();
    }
    protected void gvCurrencyInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        CurrencyInformation oCurrencyInformation = new CurrencyInformation();
        oCurrencyInformation.ID =new Guid(gvCurrencyInfoList.Rows[e.RowIndex].Cells[1].Text);

        CCurrencyInformationManagement.DeleteCurrencyInformation(oCurrencyInformation);

        LoadAllCurrency();
    }
}
