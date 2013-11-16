using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Threading;
using ParameterManagment;
using DALManagment;

public partial class CountryInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadAllCountry();
        }
    }

    protected void LoadAllCountry()
    {
        List<GetAllCountryInformationResult> lstAllCountryInfoamationList = CCountryInformationManagement.GetAllCountry();

        gvCountryInfoList.DataSource = lstAllCountryInfoamationList;
        gvCountryInfoList.DataBind();

    
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CountryInformation oCountryInformation = new CountryInformation();

        oCountryInformation.CountryName = txtCountryName.Text;
        oCountryInformation.UserId = Guid.Empty;

        if (txtCountryId.Text == null || txtCountryId.Text == string.Empty)
        {
            oCountryInformation.ID = Guid.NewGuid();
            CCountryInformationManagement.CreateNewCountry(oCountryInformation);
        }
        else
        {
            oCountryInformation.ID = new Guid(txtCountryId.Text);

            CCountryInformationManagement.UpdateCountryInformation(oCountryInformation);
        }

        LoadAllCountry();

        txtCountryName.Text = string.Empty;
        txtCountryId.Text = string.Empty;

        //Thread.Sleep(5000);
        
    }

    protected void gvCountryInfoList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCountryInfoList.PageIndex = e.NewPageIndex;
        LoadAllCountry();
    }

    protected void gvCountryInfoList_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int iEditedRowIndex = e.NewEditIndex;

        txtCountryId.Text = gvCountryInfoList.Rows[iEditedRowIndex].Cells[1].Text;
        txtCountryName.Text = gvCountryInfoList.Rows[iEditedRowIndex].Cells[2].Text;
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        txtCountryId.Text = string.Empty;
        txtCountryName.Text = string.Empty;
    }
}
