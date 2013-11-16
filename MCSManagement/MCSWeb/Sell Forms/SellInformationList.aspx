<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="SellInformationList.aspx.cs" Inherits="SellInformationList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">

 <tr> 
   <td  class="editmodetd" style="height: 19px"><asp:Label ID="lbleditmode" runat="server" Text="Sell List" SkinID="editmodelabelskin"></asp:Label></td>
 </tr>
<%-- <tr> 
    <td align="center">
        <asp:Button ID="btnNewSell" runat="server" Text="New Sell" />&nbsp;</td>
 </tr>--%>
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
                                 <td class="captiontd"><asp:Label runat="server" ID="lblMoneyReceiptNo" 
                                         Text="Money Receipt No : " ></asp:Label></td>
                                 <td class="contenttd"><asp:TextBox runat="server" ID="txtMoneyReceiptNo" SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"></td>
                             </tr>
                             <tr>
                                 <td class="captiontd" style="height: 25px"><asp:Label runat="server" ID="lblFromDate" Text="From Date : "></asp:Label></td>
                                 <td class="contenttd" style="height: 25px"><asp:TextBox runat="server" ID="txtFromDate"  SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"> 
                                 <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtFromDate"
                                         ErrorMessage="*" MaximumValue="01/01/2099" MinimumValue="01/01/1950" Type="Date"></asp:RangeValidator>--%>
                                         </td>
                             </tr>
                             <tr>
                                 <td class="captiontd"><asp:Label runat="server" ID="lblToDate" Text="To Date : "></asp:Label></td>
                                 <td class="contenttd"><asp:TextBox runat="server" ID="txtToDate" SkinID="fullsizedtextbox"></asp:TextBox></td>
                                 <td class="textmandatory"><%--<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtToDate"
                                         ErrorMessage="*" MaximumValue="01/01/2099" MinimumValue="01/01/1950" Type="Date"></asp:RangeValidator>--%>
                                         </td>
                             </tr>
                             <tr>
                                 <td class="captiontd"></td>
                                 <td class="contenttd"><asp:Button runat="server" CssClass="buttontype" ID="btnFind" Text="Find" OnClick="btnFind_Click"/>
                                   </td>
                                 <td class="textmandatory"></td>
                             </tr>
                          </tbody>
                     </table>
                 </td>
                 <td>
            </tr>
            <tr> 
                <td  class="gridheadertd" colspan="2"><asp:Label ID="lblGridHeader" runat="server" Text="Sell Infromation  List" SkinID="gridheaderlableskin"></asp:Label></td>
            </tr>
            <tr><td colspan="2"></td></tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="gvSelldInformationList" runat="server" 
                        AutoGenerateColumns="False" PageSize="5" Width="100%" AllowPaging="True" 
                        onpageindexchanging="gvSelldInformationList_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="MoneyReceiptId">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SellGroupId" HeaderText="SellGroupId">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CustomerName" HeaderText="Pur. From">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MoneyReceiptNo" HeaderText="MR. No" />
                            <asp:BoundField DataField="CurrencyName" HeaderText="Currency" />
                            <asp:BoundField DataField="Amount" HeaderText="Amount" />
                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:BoundField DataField="FormatedSoldDateString" HeaderText="Selld Date" />
                            <asp:BoundField DataField="TypeOfCustomer" HeaderText="Customer Type" />
                            <asp:HyperLinkField DataNavigateUrlFields="Sellgroupid" 
                                DataNavigateUrlFormatString="~/Sell Forms/SellRedirector.aspx?Sellgroupid={0}" 
                                NavigateUrl="~/Sell Forms/SellRedirector.aspx" Text="details" />
                        </Columns>
                    </asp:GridView>
                </td>
             </tr>
          </table>
        
       </td>
    </tr>
 </table>
</asp:Content>

