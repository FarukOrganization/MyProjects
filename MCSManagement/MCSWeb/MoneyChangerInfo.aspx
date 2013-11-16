<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="MoneyChangerInfo.aspx.cs" Inherits="MoneyChangerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd">
                <asp:Label ID="lbleditmodeUserList" runat="server" Text="MoneyChanger Information" SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                  <table width="100%" class="tblStyleborderless" cellspacing="0" align="center">
                    <tr>
                        <td width="40%">
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td class="captiontd">
                                            <asp:Label runat="server" ID="lblMoneyChangerName" Text="MoneyChanger Name "></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:TextBox runat="server" ID="txtMoneyChangerName" SkinID="fullsizedtextbox"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtMoneyChangerId" Visible="false" 
                                                SkinID="fullsizedtextbox"></asp:TextBox>
                                        </td>
                                        <td class="textmandatory">
                                        </td>
                                    </tr>
                                        <tr>
                                        <td class="captiontd">
                                            <asp:Label runat="server" ID="lblOwner" Text="Owner Name "></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:TextBox runat="server" ID="txtOwner" SkinID="fullsizedtextbox"></asp:TextBox>
                                        </td>
                                        <td class="textmandatory">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="captiontd">
                                            <asp:Label runat="server" ID="lblAddress" Text="Address"></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtAddress" SkinID="multilinelargetextbox"></asp:TextBox>
                                        </td>
                                        <td class="textmandatory">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="captiontd">
                                        </td>
                                        <td class="contenttd">
                                           <asp:Button runat="server" CssClass="buttontype" ID="btnSave" Text="Save"
                                                CausesValidation="False" onclick="btnSave_Click" />
                                            <asp:Button runat="server" CssClass="buttontype" ID="btnNew" Text="New.."
                                            CausesValidation="False" onclick="btnNew_Click" />
                                        </td>
                                        <td class="textmandatory">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td style="text-align: left">
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="gridheadertd" colspan="2">
                            <asp:Label ID="lblGridHeader" runat="server" Text="MoneyChanger List" SkinID="gridheaderlableskin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gvMoneyChangerInfoList" runat="server" 
                                AutoGenerateColumns="False" PageSize="5"
                                Width="100%" AllowPaging="True" 
                                onpageindexchanging="gvMoneyChangerInfoList_PageIndexChanging" 
                                AutoGenerateEditButton="True" onrowediting="gvMoneyChangerInfoList_RowEditing" 
                                AutoGenerateDeleteButton="True" 
                                onrowdeleting="gvMoneyChangerInfoList_RowDeleting">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="MoneyChanger Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MoneyChangerName" HeaderText="MoneyChangerName"></asp:BoundField>
                                    <asp:BoundField DataField="Owner" HeaderText="Owner"></asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                 <ProgressTemplate>
                   <div>
                       <img src="Images/Progress.gif" />
                       Please Wait...
                    </div>
                 </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>

