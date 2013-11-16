<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="PurchaseSellBalanceReport.aspx.cs" Inherits="Reports_PurchaseSellBalanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">

    function ViewReport() {

        var date = document.getElementById("txtDate");

        window.open("ReportViewer.aspx?report=purchasesellbalance&date=" + date.value);

        return false;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">
 <tr> 
   <td  class="editmodetd" style="height: 19px"><asp:Label ID="lbleditmode" runat="server" Text="Purchase Sell Balance" SkinID="editmodelabelskin"></asp:Label></td>
 </tr>
 <tr> 
    <td  class="findbytd"><asp:Label ID="lblfindby" runat="server" SkinID="gridheaderlableskin" meta:resourcekey="lblfindbyResource1"></asp:Label></td>
 </tr>
 
 <tr>
    <td>
        <table width="100%"  class="tblStyleborderless" cellspacing="0" align="center">
            <tr>
                <td width="40%">
                    <table width="100%">
                        <tbody>
                             <tr>
                                 <td class="captiontd"><asp:Label runat="server" ID="lblDate" Text="Date : "></asp:Label></td>
                                 <td class="contenttd"><asp:TextBox runat="server" ClientIDMode="Static" ID="txtDate"  SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"> 
                                 <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtFromDate"
                                         ErrorMessage="*" MaximumValue="01/01/2099" MinimumValue="01/01/1950" Type="Date"></asp:RangeValidator>--%>
                                         </td>
                             </tr>
                             <tr>
                                 <td class="captiontd"></td>
                                 <td class="contenttd"><asp:Button runat="server" CssClass="buttontype" ID="btnShowReport" Text="ShowReport" OnClientClick="return ViewReport();" />
                                   </td>
                                 <td class="textmandatory"></td>
                             </tr>
                          </tbody>
                     </table>
                 </td>
            </tr>
          </table>
        
       </td>
    </tr>
 </table>
</asp:Content>


