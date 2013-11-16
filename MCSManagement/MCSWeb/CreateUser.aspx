<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true"
    CodeFile="CreateUser.aspx.cs" Inherits="CreateUser" %>

<%@ Register Assembly="CustomControlSet" Namespace="CustomControlSet" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd" align="center">
                <asp:Label ID="lbleditmode" runat="server" Text="New User" SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
        <tr>
         <td>
         <%--<asp:ScriptManager runat="server" ID="scriptmanager"></asp:ScriptManager>
         <asp:UpdatePanel ID="updatepanel" runat="server">
          <ContentTemplate>
             <cc1:CalculationControl ID="CalculationControl1" runat="server">
            </cc1:CalculationControl>
          </ContentTemplate>
         </asp:UpdatePanel>--%>
          </td>
        </tr>
        <tr>
            <td align="center">
                <table width="40%" align="center">
                    <tbody>
                        <tr>
                            <td class="captiontd">
                                <asp:Label runat="server" ID="lblUserName" Text="Use Name"></asp:Label>
                            </td>
                            <td class="contenttd">
                                <asp:TextBox runat="server" ID="txtUserName" SkinID="fullsizedtextbox"></asp:TextBox>
                            </td>
                            <td class="textmandatory">
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="captiontd">
                                <asp:Label runat="server" ID="lblPassword" Text="Password "></asp:Label>
                            </td>
                            <td class="contenttd">
                                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" SkinID="fullsizedtextbox"></asp:TextBox>
                            </td>
                            <td class="textmandatory">
                                <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td class="captiontd">
                                <asp:Label runat="server" ID="lblConfirmPassword" Text="Confirm Password "></asp:Label>
                            </td>
                            <td class="contenttd">
                                <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                            <td class="textmandatory">
                                <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="comvConfirmPassword" runat="server" ControlToCompare="txtPassword"
                                    ControlToValidate="txtConfirmPassword" ErrorMessage="*"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="captiontd">
                                <asp:Label runat="server" ID="lblRoleCaption" Text="User Role "></asp:Label>
                            </td>
                            <td class="contenttd">
                                <asp:DropDownList Width="182px" runat="server" ID="drplstRole">
                                </asp:DropDownList>
                            </td>
                            <td class="textmandatory">
                            
                               <%-- <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="drplstRole"
                                    ErrorMessage="*" MinimumValue="1" MaximumValue="1500"></asp:RangeValidator>
        --%>                    </td>
                        </tr>
                        <tr>
                            <td class="captiontd">
                            </td>
                            <td class="contenttd">
                                <asp:Button runat="server" CssClass="buttontype" ID="btnSave" Text="Save" />
                            </td>
                            <td class="textmandatory">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
