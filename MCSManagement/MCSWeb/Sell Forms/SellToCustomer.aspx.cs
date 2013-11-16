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

public partial class SellToCustomer : System.Web.UI.Page
{
    string sSessionKeySellCurrencyInformationList = "SellCurrencyInformationList";
    string sSessionKeySellCurrencyCustomerInformationList = "SellCurrencyCustomerInformationList";

    #region Page Event handlers 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CSessionUtil.RemoveSesstion(sSessionKeySellCurrencyInformationList);
            LoadCurrency();
            txtSellDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            
            #region When comes from list page 
            
            if (!string.IsNullOrEmpty(Request.QueryString["SellGroupId"]))
            {
                Guid gSellGroupId = new Guid(Request.QueryString["SellGroupId"]);

                Dictionary<Guid, SellInformation> dicSellInformation = CSellInformationManagment.GetSellInformationBySellGroupId(gSellGroupId);

                if (dicSellInformation.Count > 0)
                {
                    Customer oCustomer = CPurchaseInformationManagment.GetCustomerById((Guid)dicSellInformation.Values.First().Cust_Id);

                    CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, dicSellInformation);
                    //CSessionUtil.SetSesstion(sSessionKeySellCurrencyCustomerInformationList, dicSellInformation.Values.First().Customer);

                    hdnCustId.Value = dicSellInformation.Values.First().Cust_Id.ToString();
                    hdnSellGroupId.Value = dicSellInformation.Values.First().SellGroupId.ToString();
                    txtCustomerName.Text = oCustomer.Name;
                    txtCustomerAddress.Text = oCustomer.Address;
                    txtMobile.Text = oCustomer.MobileNumber;
                    txtSellDate.Text = dicSellInformation.Values.First().FormatedSoldDateString;

                    gvCurrenySellInfoList.DataSource = dicSellInformation.Values;
                    gvCurrenySellInfoList.DataBind();
                }
            }

            #endregion When comes from list page 

            
        }

    }

    #endregion Page Event handlers

    #region Developer defined Methods 

    private void LoadCurrency()
    {
        List<GetAllCurrencyInformationResult> lstAllCurrencyInformationList = CCurrencyInformationManagement.GetAllCurrency();

        drpCurrency.DataTextField = "CurrencyName";
        drpCurrency.DataValueField = "Id";

        drpCurrency.DataSource = lstAllCurrencyInformationList;
        drpCurrency.DataBind();

    }

    private void SaveSellInformation(Operation eOperation, Guid gSellGroupId, Guid gCustomerId)
    {
        Dictionary<Guid, SellInformation> dicIdSellInformation = null;

        Customer oCustomer = null;

        if (eOperation == Operation.Update)
        {
            oCustomer = (Customer)CSessionUtil.GetSesstion(sSessionKeySellCurrencyCustomerInformationList);
        }
        else
        {
            oCustomer = new Customer();
        }
        oCustomer.Id = gCustomerId;
        oCustomer.Name = txtCustomerName.Text;
        oCustomer.MobileNumber = txtMobile.Text;
        oCustomer.Address = txtCustomerAddress.Text;
        

        if (CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList) != null)
        {
            //lstSellInformation = (List<SellInformation>)CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList);
            dicIdSellInformation = (Dictionary<Guid, SellInformation>)CSessionUtil.GetSesstion(sSessionKeySellCurrencyInformationList);

            DateTime dtSoldDateTime =CBusinessUtility.GetValidatedDate(txtSellDate.Text);

            //foreach (SellInformation oSellInformation in lstSellInformation)
            foreach(KeyValuePair<Guid,SellInformation> indivisualSellItem in dicIdSellInformation)
            {
                indivisualSellItem.Value.SellGroupId = gSellGroupId;
                indivisualSellItem.Value.Cust_Id = gCustomerId;
                indivisualSellItem.Value.CreateDateTime = DateTime.Today;
                indivisualSellItem.Value.SoldDate = dtSoldDateTime;
                
            }

            if (Operation.Create == eOperation)
            {
                CSellInformationManagment.CreateSellInformation(oCustomer, dicIdSellInformation, ECustomerType.Customer);
            }
            else if (Operation.Update == eOperation)
            {
                CSellInformationManagment.DeleteAndCreateSellInformation(oCustomer, dicIdSellInformation, ECustomerType.Customer);
            }

            //Make all Old

            //dicIdSellInformation = dicIdSellInformation.

            //dicIdSellInformation = dicIdSellInformation.Values.Where(SellInfo => !SellInfo.IsDeleted).ToDictionary<SellInformation,Guid>(SellInfo=>SellInfo.Id);//.ToDictionary(SellInfo=>SellInfo.Key);
            ////dicIdSellInformation = (Dictionary<Guid, SellInformation>)dicIdSellInformation.Where(SellKeyValue => !SellKeyValue.Value.IsDeleted);//.ToDictionary(SellInfo=>SellInfo.Key);


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
            CSessionUtil.SetSesstion(sSessionKeySellCurrencyCustomerInformationList, oCustomer);

            hdnSellGroupId.Value = gSellGroupId.ToString();
            hdnCustId.Value = gCustomerId.ToString();
        }

    }


    #endregion Developer defined Methods

    #region Page Control Event handlers 

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Dictionary<Guid, SellInformation> dicIdSellInformation = null;
        //List<SellInformation> lstSellInformation = null;

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
        oSellInformation.CustomerType =(int)ECustomerType.Customer;
        oSellInformation.MoneyReceiptNo = txtMoneyReceiptNo.Text;
        oSellInformation.CurrencyId =new Guid(drpCurrency.SelectedValue);
        oSellInformation.CurrencyName = drpCurrency.SelectedItem.Text;
        oSellInformation.Amount = Convert.ToDecimal(txtAmount.Text);
        oSellInformation.Rate = Convert.ToDecimal(txtRate.Text);
        oSellInformation.Total = Convert.ToDecimal(txtTotalAmount.Text);
        oSellInformation.IsNew = true;

        dicIdSellInformation.Add(oSellInformation.Id,oSellInformation);

        CSessionUtil.SetSesstion(sSessionKeySellCurrencyInformationList, dicIdSellInformation);

        gvCurrenySellInfoList.DataSource = dicIdSellInformation.Values.Where(SellInfo=> !SellInfo.IsDeleted);
        gvCurrenySellInfoList.DataBind();

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        CSessionUtil.RemoveSesstion(sSessionKeySellCurrencyInformationList);

        Response.Redirect("SellFromCustomer.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Guid gSellGroupId = Guid.Empty;
        Guid gCustomerId = Guid.Empty;


        if (string.IsNullOrEmpty(hdnSellGroupId.Value))
        {
            gSellGroupId = Guid.NewGuid();
            gCustomerId = Guid.NewGuid();

            SaveSellInformation(Operation.Create, gSellGroupId, gCustomerId);
        }
        else
        {
            gSellGroupId =new Guid(hdnSellGroupId.Value);
            gCustomerId = new Guid(hdnCustId.Value);

            SaveSellInformation(Operation.Update, gSellGroupId, gCustomerId);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {

    }

    #endregion Page Control Event handlers


    protected void gvCurrenySellInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvRowToDelete = gvCurrenySellInfoList.Rows[e.RowIndex];

        Guid gSellIdToDelete=new Guid(gvRowToDelete.Cells[1].Text);

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

        gvCurrenySellInfoList.DataSource = dicIdSellInformation.Values.Where(SellInfo=> !SellInfo.IsDeleted );
        gvCurrenySellInfoList.DataBind();
    }
}
