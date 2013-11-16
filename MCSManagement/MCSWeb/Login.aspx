<%@ Page Language="C#" AutoEventWireup="false" MasterPageFile="~/MCSMainMaster.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">--%>
    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Label runat="server" ID="lblError"></asp:Label>

<asp:Login runat="server" ID="ctrlLogin" VisibleWhenLoggedIn="False">
                                <LayoutTemplate>
                                   <%-- <table width="400px" style="background-color: Silver;">
                                        <tr>
                                            <td align="center">--%>
                                                <table style="margin-top:50px">
                                                    <tr>
                                                        <td class="textb">
                                                            <asp:Label runat="server" ID="lblUserName" Text="UserName"></asp:Label>
                                                        </td>
                                                        <td width="5px">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                                        </td>
                                                        <td width="5px">
                                                            <asp:RequiredFieldValidator runat="server" ID="rfvValidateUserName" ErrorMessage="*"
                                                                ControlToValidate="UserName"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textb">
                                                            <asp:Label runat="server" ID="lblPassword" Text="Password"></asp:Label>
                                                        </td>
                                                        <td width="5px">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="Password"></asp:TextBox>
                                                        </td>
                                                        <td width="5px">
                                                            <asp:RequiredFieldValidator runat="server" ID="rfvValidatePassword" ErrorMessage="*"
                                                                ControlToValidate="Password"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                                                 <tr>
                            <td colspan="4" align="center">
                                <asp:Literal id="FailureText" runat="server"></asp:Literal></td>
                        </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <asp:Button runat="server" ID="Login" CommandName="Login" Text="Login" />
                                                       </td>
                                                    </tr>
                       

                                                </table>
                                           <%-- </td>
                                        </tr>
                                    </table>--%>
                                </LayoutTemplate>
                            </asp:Login>
    <%--<table width="100%">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" width="100%">
                <table width="400px" style="background-color: Silver;">
                    <tr>
                        <td align="center" class="editmodetd">
                            Login Form
                        </td>
                    </tr>
                    <tr>
                        <td class="tdError" runat="server" id="tdError" align="center"> 
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Login runat="server" ID="ctrlLogin" VisibleWhenLoggedIn="False">
                                <LayoutTemplate>
                                    <table width="400px" style="background-color: Silver;">
                                        <tr>
                                            <td align="center">
                                                <table>
                                                    <tr>
                                                        <td class="textb">
                                                            <asp:Label runat="server" ID="lblUserName" Text="UserName"></asp:Label>
                                                        </td>
                                                        <td width="5px">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                                        </td>
                                                        <td width="5px">
                                                            <asp:RequiredFieldValidator runat="server" ID="rfvValidateUserName" ErrorMessage="*"
                                                                ControlToValidate="UserName"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="textb">
                                                            <asp:Label runat="server" ID="lblPassword" Text="Password"></asp:Label>
                                                        </td>
                                                        <td width="5px">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                            <asp:TextBox runat="server" ID="Password"></asp:TextBox>
                                                        </td>
                                                        <td width="5px">
                                                            <asp:RequiredFieldValidator runat="server" ID="rfvValidatePassword" ErrorMessage="*"
                                                                ControlToValidate="Password"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                                                 <tr>
                            <td colspan="4" align="center">
                                <asp:Literal id="FailureText" runat="server"></asp:Literal></td>
                        </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            &nbsp;
                                                        </td>
                                                        <td colspan="2" align="left">
                                                            <asp:Button runat="server" ID="Login" CommandName="Login" Text="Login" />
                                                       </td>
                                                    </tr>
                       

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </LayoutTemplate>
                            </asp:Login>
                        </td>
                    </tr>
                </table>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>--%>
    </asp:Content>
  <%--  </form>
</body>
</html>--%>
