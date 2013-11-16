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

public partial class PurchaseFromCustomer : System.Web.UI.Page
{
    string sSessionKeyPurchaseCurrencyInformationList = "PurchaseCurrencyInformationList";
    string sSessionKeyPurchaseCurrencyCustomerInformationList = "PurchaseCurrencyCustomerInformationList";

    #region Page Event handlers 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CSessionUtil.RemoveSesstion(sSessionKeyPurchaseCurrencyInformationList);
            LoadCurrency();
            LoadNationality();
            txtPurchaseDate.Text = DateTime.Today.ToString("dd-MM-yyyy");
            
            #region When comes from list page 
            
            if (!string.IsNullOrEmpty(Request.QueryString["PurchaseGroupId"]))
            {
                Guid gPurchaseGroupId = new Guid(Request.QueryString["PurchaseGroupId"]);

                Dictionary<Guid, PurchaseInformation> dicPurchaseInformation = CPurchaseInformationManagment.GetPurchaseInformationByPurchaseGroupId(gPurchaseGroupId);

                if (dicPurchaseInformation.Count > 0)
                {
                    Customer oCustomer = CPurchaseInformationManagment.GetCustomerById((Guid)dicPurchaseInformation.Values.First().Cust_Id);

                    CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, dicPurchaseInformation);
                    CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyCustomerInformationList, oCustomer);

                    hdnCustId.Value = dicPurchaseInformation.Values.First().Cust_Id.ToString();
                    hdnPurchaseGroupId.Value = dicPurchaseInformation.Values.First().PurchaseGroupId.ToString();
                    txtCustomerName.Text = oCustomer.Name;
                    txtCustomerAddress.Text = oCustomer.Address;
                    txtPassportNo.Text = oCustomer.PassportNo;
                    drpNationality.SelectedValue = oCustomer.Nationality.ToString();
                    //txtMobile.Text = dicPurchaseInformation.Values.First().Customer.MobileNumber;
                    txtPurchaseDate.Text = dicPurchaseInformation.Values.First().FormatedPurchaseDateString;

                    gvCurrenyPurchaseInfoList.DataSource = dicPurchaseInformation.Values;
                    gvCurrenyPurchaseInfoList.DataBind();
                }
            }

            #endregion When comes from list page 

            
        }

    }

    private void LoadNationality()
    {
        List<GetAllCountryInformationResult> lstAllCountryInformationList = CCountryInformationManagement.GetAllCountry();
        
        drpNationality.DataTextField = "CountryName";
        drpNationality.DataValueField = "Id";

        drpNationality.DataSource = lstAllCountryInformationList;
        drpNationality.DataBind();
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

    private void SavePurchaseInformation(Operation eOperation, Guid gPurchaseGroupId, Guid gCustomerId)
    {
        Dictionary<Guid, PurchaseInformation> dicIdPurchaseInformation = null;

        Customer oCustomer = null;

        if (eOperation == Operation.Update)
        {
            oCustomer = (Customer)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyCustomerInformationList);
        }
        else
        {
            oCustomer = new Customer();
        }
        oCustomer.Id = gCustomerId;
        oCustomer.Name = txtCustomerName.Text;
        //oCustomer.MobileNumber = txtMobile.Text;
        oCustomer.Address = txtCustomerAddress.Text;
        oCustomer.Nationality =new Guid(drpNationality.SelectedValue);
        oCustomer.PassportNo = txtPassportNo.Text;
        

        if (CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList) != null)
        {
            //lstPurchaseInformation = (List<PurchaseInformation>)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList);
            dicIdPurchaseInformation = (Dictionary<Guid, PurchaseInformation>)CSessionUtil.GetSesstion(sSessionKeyPurchaseCurrencyInformationList);

            DateTime dtPurchasedDateTime =CBusinessUtility.GetValidatedDate(txtPurchaseDate.Text);

            //foreach (PurchaseInformation oPurchaseInformation in lstPurchaseInformation)
            foreach(KeyValuePair<Guid,PurchaseInformation> indivisualPurchaseItem in dicIdPurchaseInformation)
            {
                indivisualPurchaseItem.Value.PurchaseGroupId = gPurchaseGroupId;
                indivisualPurchaseItem.Value.Cust_Id = gCustomerId;
                indivisualPurchaseItem.Value.CreateDateTime = DateTime.Today;
                indivisualPurchaseItem.Value.PurchasedDate = dtPurchasedDateTime;
                
            }

            if (Operation.Create == eOperation)
            {
                CPurchaseInformationManagment.CreatePurchaseInformation(oCustomer, dicIdPurchaseInformation, ECustomerType.Customer);
            }
            else if (Operation.Update == eOperation)
            {
                CPurchaseInformationManagment.DeleteAndCreatePurchaseInformation(oCustomer, dicIdPurchaseInformation, ECustomerType.Customer);
            }

            //Make all Old

            //dicIdPurchaseInformation = dicIdPurchaseInformation.

            //dicIdPurchaseInformation = dicIdPurchaseInformation.Values.Where(PurchaseInfo => !PurchaseInfo.IsDeleted).ToDictionary<PurchaseInformation,Guid>(PurchaseInfo=>PurchaseInfo.Id);//.ToDictionary(PurchaseInfo=>PurchaseInfo.Key);
            ////dicIdPurchaseInformation = (Dictionary<Guid, PurchaseInformation>)dicIdPurchaseInformation.Where(PurchaseKeyValue => !PurchaseKeyValue.Value.IsDeleted);//.ToDictionary(PurchaseInfo=>PurchaseInfo.Key);


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
            CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyCustomerInformationList, oCustomer);

            hdnPurchaseGroupId.Value = gPurchaseGroupId.ToString();
            hdnCustId.Value = gCustomerId.ToString();
        }

    }


    #endregion Developer defined Methods

    #region Page Control Event handlers 

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Dictionary<Guid, PurchaseInformation> dicIdPurchaseInformation = null;
        //List<PurchaseInformation> lstPurchaseInformation = null;

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
        oPurchaseInformation.CustomerType =(int)ECustomerType.Customer;
        oPurchaseInformation.MoneyReceiptNo = txtMoneyReceiptNo.Text;
        oPurchaseInformation.CurrencyId =new Guid(drpCurrency.SelectedValue);
        oPurchaseInformation.CurrencyName = drpCurrency.SelectedItem.Text;
        oPurchaseInformation.Amount = Convert.ToDecimal(txtAmount.Text);
        oPurchaseInformation.Rate = Convert.ToDecimal(txtRate.Text);
        oPurchaseInformation.Total = Convert.ToDecimal(txtTotalAmount.Text);
        oPurchaseInformation.IsNew = true;

        dicIdPurchaseInformation.Add(oPurchaseInformation.Id,oPurchaseInformation);

        CSessionUtil.SetSesstion(sSessionKeyPurchaseCurrencyInformationList, dicIdPurchaseInformation);

        gvCurrenyPurchaseInfoList.DataSource = dicIdPurchaseInformation.Values.Where(PurchaseInfo=> !PurchaseInfo.IsDeleted);
        gvCurrenyPurchaseInfoList.DataBind();

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        CSessionUtil.RemoveSesstion(sSessionKeyPurchaseCurrencyInformationList);

        Response.Redirect("PurchaseFromCustomer.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Guid gPurchaseGroupId = Guid.Empty;
        Guid gCustomerId = Guid.Empty;


        if (string.IsNullOrEmpty(hdnPurchaseGroupId.Value))
        {
            gPurchaseGroupId = Guid.NewGuid();
            gCustomerId = Guid.NewGuid();

            SavePurchaseInformation(Operation.Create, gPurchaseGroupId, gCustomerId);
        }
        else
        {
            gPurchaseGroupId =new Guid(hdnPurchaseGroupId.Value);
            gCustomerId = new Guid(hdnCustId.Value);

            SavePurchaseInformation(Operation.Update, gPurchaseGroupId, gCustomerId);
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {

    }

    #endregion Page Control Event handlers


    protected void gvCurrenyPurchaseInfoList_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow gvRowToDelete = gvCurrenyPurchaseInfoList.Rows[e.RowIndex];

        Guid gPurchaseIdToDelete=new Guid(gvRowToDelete.Cells[1].Text);

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

        gvCurrenyPurchaseInfoList.DataSource = dicIdPurchaseInformation.Values.Where(PurchaseInfo=> !PurchaseInfo.IsDeleted );
        gvCurrenyPurchaseInfoList.DataBind();
    }
}
