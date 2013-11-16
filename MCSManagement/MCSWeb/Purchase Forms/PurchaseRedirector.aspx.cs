using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessManagement;
using DALManagment;
using Utility;

public partial class PurchaseRedirector : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["PurchaseGroupId"]))
        {
            Guid gPurchaseGroupId = new Guid(Request.QueryString["PurchaseGroupId"]);

            Dictionary<Guid, PurchaseInformation> dicPurchaseInformation = CPurchaseInformationManagment.GetPurchaseInformationByPurchaseGroupId(gPurchaseGroupId);

            if (dicPurchaseInformation.Count > 0)
            {
                if (dicPurchaseInformation.Values.First().CustomerType == (int)ECustomerType.Customer)
                {
                    Response.Redirect("PurchaseFromCustomer.aspx?PurchaseGroupId="+gPurchaseGroupId.ToString());
                }
                else if (dicPurchaseInformation.Values.First().CustomerType == (int)ECustomerType.Bank)
                {
                    Response.Redirect("PurchaseFromBank.aspx?PurchaseGroupId=" + gPurchaseGroupId.ToString());
                }
                else if (dicPurchaseInformation.Values.First().CustomerType == (int)ECustomerType.MoneyChanger)
                {
                    Response.Redirect("PurchaseFromMoneyChanger.aspx?PurchaseGroupId=" + gPurchaseGroupId.ToString());
                }
            
            }

        }
    }
}
