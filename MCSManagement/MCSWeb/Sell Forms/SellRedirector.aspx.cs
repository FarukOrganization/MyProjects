using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessManagement;
using DALManagment;
using Utility;

public partial class SellRedirector : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["SellGroupId"]))
        {
            Guid gSellGroupId = new Guid(Request.QueryString["SellGroupId"]);

            Dictionary<Guid, SellInformation> dicSellInformation = CSellInformationManagment.GetSellInformationBySellGroupId(gSellGroupId);

            if (dicSellInformation.Count > 0)
            {
                if (dicSellInformation.Values.First().CustomerType == (int)ECustomerType.Customer)
                {
                    Response.Redirect("SellToCustomer.aspx?SellGroupId="+gSellGroupId.ToString());
                }
                else if (dicSellInformation.Values.First().CustomerType == (int)ECustomerType.Bank)
                {
                    Response.Redirect("SellToBank.aspx?SellGroupId=" + gSellGroupId.ToString());
                }
                else if (dicSellInformation.Values.First().CustomerType == (int)ECustomerType.MoneyChanger)
                {
                    Response.Redirect("SellToMoneyChanger.aspx?SellGroupId=" + gSellGroupId.ToString());
                }
            
            }

        }
    }
}
