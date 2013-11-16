<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true"
    CodeFile="ViewUser.aspx.cs" Inherits="ViewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd">
                <asp:Label ID="lbleditmodeUserList" runat="server" Text="View User" SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" class="tblStyleborderless" cellspacing="0" align="center">
                    <tr>
                        <td width="40%">
                            <table width="100%">
                                <tbody>
                                    <tr>
                                        <td class="captiontd">
                                            <asp:Label runat="server" ID="lblUseName" Text="Use Name "></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:TextBox runat="server" ID="txtUserNameToFind" SkinID="fullsizedtextbox"></asp:TextBox>
                                        </td>
                                        <td class="textmandatory">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="captiontd">
                                            <asp:Label runat="server" ID="lblRoleList" Text="Role"></asp:Label>
                                        </td>
                                        <td class="contenttd">
                                            <asp:DropDownList Width="182px" runat="server" ID="drplstRoleList">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="textmandatory">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="captiontd">
                                        </td>
                                        <td class="contenttd">
                                            &nbsp;<asp:Button runat="server" CssClass="buttontype" ID="btnViewAll" Text="ViewAll"
                                                CausesValidation="False" />
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
                            <asp:Label ID="lblGridHeader" runat="server" Text="User  List" SkinID="gridheaderlableskin"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="False" PageSize="5"
                                Width="100%" AllowPaging="True">
                                <Columns>
                                    <asp:BoundField DataField="CounterCode" HeaderText="COUNTER ID">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COUNTER" HeaderText="COUNTER"></asp:BoundField>
                                    <asp:BoundField DataField="UserName" HeaderText="User Name"></asp:BoundField>
                                    <asp:BoundField DataField="RoleName" HeaderText="Role"></asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="UserName" DataNavigateUrlFormatString="ChangePassword.aspx?UserName={0}"
                                        Text="Change Password" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
