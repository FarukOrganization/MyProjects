<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="SellToMoneyChanger.aspx.cs" Inherits="SellToMoneyChanger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
 <table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd">
                <asp:Label ID="lbleditmode" runat="server" Text="Sell To Money Changer" 
                    SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" class="tblStyleborderless" align="center">
                    <tr>
                        <td width="30%" valign="top">
                            <table width="100%">
                                <tr>
                                    <td class="captiontd">
                                       <asp:HiddenField ID="hdnSellGroupId" runat="server" />
                                        <asp:Label runat="server" ID="lblMoneyChanger" Text="MoneyChanger"></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:DropDownList runat="server" ID="drpMoneyChanger" SkinID="largesizeddropdownlist">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblRefMoneyReceiptNo" Text="Ref MoneyReceiptNo "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:TextBox runat="server" ID="txtRefMoneyReceiptNo" SkinID="fullsizedtextbox"></asp:TextBox>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="captiontd">
                                    <asp:Label runat="server" ID="lblSellDate" Text="Sell Date "></asp:Label>
                                    </td>
                                 <td class="contenttd">
                                 <asp:TextBox runat="server" ID="txtSellDate"  SkinID="fullsizedtextbox"></asp:TextBox>
                                 </td>
                                 <td class="textmandatory"> 
                                 <%--<asp:RangeValidator ID="rvSellDate" runat="server" ControlToValidate="txtSellDate"
                                         ErrorMessage="*" MaximumValue="01/01/2099" MinimumValue="01/01/1950" 
                                         Type="Date"></asp:RangeValidator>--%>
                                         </td>
                                </tr>
                                <tr id="tdCancelMR" runat="server">
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblCancelMR" Text="Cancel Money Receipt "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:CheckBox runat="server" AutoPostBack="true" ID="chkCancelMR" Text="" />
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr id="trCancelRemarks" runat="server" visible="false">
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblCancelRemarks" Text="Cancel Remarks "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:DropDownList runat="server" ID="drplstCancelRemarks">
                                            <asp:ListItem Text="Wrong Value"></asp:ListItem>
                                            <asp:ListItem Text="Nothing"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="25%" valign="top" align="left">
                            <table width="100%">
                                  <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblMoneyReceiptNo" Text="MoneyReceiptNo "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:TextBox runat="server" ID="txtMoneyReceiptNo" SkinID="mediumsizedtextbox"></asp:TextBox>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblCurrency" Text="Currency "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:DropDownList runat="server" ID="drpCurrency" SkinID="mediumsizeddropdownlist">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblAmount" Text="Amount "></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:TextBox runat="server" ID="txtAmount" SkinID="mediumsizedtextbox"></asp:TextBox>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblRate" Text="Rate(in TK)"></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:TextBox runat="server" ID="txtRate" SkinID="mediumsizedtextbox"></asp:TextBox>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="captiontd">
                                        <asp:Label runat="server" ID="lblTotalAmount" Text="Total Amount"></asp:Label>
                                    </td>
                                    <td class="contenttd">
                                        <asp:TextBox runat="server" ID="txtTotalAmount" SkinID="mediumsizedtextbox"></asp:TextBox>
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" CssClass="buttontype" Width="70px" ID="btnAdd" Text="Add"
                                            OnClick="btnAdd_Click" />
                                    </td>
                                    <td class="textmandatory">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td class="gridheadertd" colspan="3">
                            <asp:Label ID="lblGridHeader" runat="server" Text="List" SkinID="gridheaderlableskin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" align="left" width="60%">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <asp:GridView ID="gvCurrenySellInfoList" runat="server" PageSize="5" Width="80%"
                                AutoGenerateColumns="False" AutoGenerateDeleteButton="True" 
                                    onrowdeleting="gvCurrenySellInfoList_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="SellId">
                                                <HeaderStyle CssClass="hide" />
                                                <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MoneyReceiptNo" HeaderText="MoneyReceiptNo" />
                                    <asp:BoundField DataField="CurrencyName" HeaderText="CurrencyName" />
                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                    <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                    <asp:BoundField DataField="Total" HeaderText="Total" />
                                </Columns>
                            </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                            </Triggers>
                            </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" class="hp-link1" width="30%">
                <asp:LinkButton ID="lnkBtnLIst" runat="server" PostBackUrl="~/Sell Forms/SellInformationList.aspx" CausesValidation="False">Money&nbsp;Receipt&nbsp;List</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <table align="left" width="100%">
                    <tr>
                        <td>
                            <table align="center" width="280px">
                                <tr>
                                    <td>
                                        <asp:Button runat="server" CssClass="buttontype" Width="70px" ID="btnNew" Text="New"
                                            CausesValidation="False" OnClick="btnNew_Click" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" CssClass="buttontype" Width="70px" ID="btnSave" Text="Save"
                                            OnClick="btnSave_Click" ValidationGroup="ChequeValidation" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" CssClass="buttontype" Width="70px" ID="btnPrint" Text="Print"
                                            CausesValidation="False" OnClick="btnPrint_Click" />
                                    </td>
                                    <td>
                                        <asp:Button runat="server" CssClass="buttontype" Width="70px" ID="btnClose" Text="Close"
                                            CausesValidation="False" OnClick="btnClose_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

