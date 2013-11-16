<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="SellReport.aspx.cs" Inherits="Reports_SellReports_SellReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript" language="javascript">

    function ViewReport() {

        var fromdate = document.getElementById("txtFromDate");
        var todate = document.getElementById("txtToDate");

        window.open("../ReportViewer.aspx?report=selllistbydate&fromdate=" + fromdate.value + "&todate=" + todate.value);

        return false;
    }

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">
 <tr> 
   <td  class="editmodetd" style="height: 19px"><asp:Label ID="lbleditmode" runat="server" Text="Sell List" SkinID="editmodelabelskin"></asp:Label></td>
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
                                 <td class="captiontd"><asp:Label runat="server" ID="lblFromDate" Text="From Date : "></asp:Label></td>
                                 <td class="contenttd"><asp:TextBox runat="server" ClientIDMode="Static" ID="txtFromDate"  SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"> 
                                 <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtFromDate"
                                         ErrorMessage="*" MaximumValue="01/01/2099" MinimumValue="01/01/1950" Type="Date"></asp:RangeValidator>--%>
                                         </td>
                             </tr>
                             <tr>
                                 <td class="captiontd"><asp:Label runat="server" ID="lblToDate" Text="To Date : "></asp:Label></td>
                                 <td class="contenttd"><asp:TextBox runat="server" ClientIDMode="Static" ID="txtToDate" SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"><%--<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtToDate"
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

