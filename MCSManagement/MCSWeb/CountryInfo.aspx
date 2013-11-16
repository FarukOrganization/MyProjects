<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="CountryInfo.aspx.cs" Inherits="CountryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .buttontype
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd">
                <asp:Label ID="lbleditmodeUserList" runat="server" Text="Country Information" SkinID="editmodelabelskin"></asp:Label>
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
                                            <asp:Label runat="server" ID="lblCountryName" Text="Country Name "></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:TextBox runat="server" ID="txtCountryName" SkinID="fullsizedtextbox"></asp:TextBox>
                                            <asp:TextBox runat="server" ID="txtCountryId" Visible="false" SkinID="fullsizedtextbox"></asp:TextBox>
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
                            <asp:Label ID="lblGridHeader" runat="server" Text="Country List" SkinID="gridheaderlableskin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gvCountryInfoList" runat="server" AutoGenerateColumns="False" PageSize="5"
                                Width="100%" AllowPaging="True" 
                                onpageindexchanging="gvCountryInfoList_PageIndexChanging" 
                                AutoGenerateEditButton="True" onrowediting="gvCountryInfoList_RowEditing">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="Country Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CountryName" HeaderText="CountryName"></asp:BoundField>
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
                       <img src="Images/Progress.gif"
                       Please Wait...
                    </div>
                 </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
</asp:Content>

