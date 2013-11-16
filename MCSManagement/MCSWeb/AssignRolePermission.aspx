<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="AssignRolePermission.aspx.cs" Inherits="AssignRolePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd" align="center">
                <asp:Label ID="lbleditmode" runat="server" Text="Assign Permission To Role" SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
       <tr>
       <td>
        <table width="40%">
         <tr>
          <td class="captiontd">
                <asp:Label runat="server" ID="lblRole" Text="Role"></asp:Label>
            </td>
            <td class="contenttd">
                <asp:DropDownList Width="182px" runat="server" ID="drpRoleList">
                </asp:DropDownList>
            </td>
            <td class="textmandatory">

            </td>
         </tr>
        </table>
       </td>
        </tr>
        <tr>
         <td>
          &nbsp;
         </td>
        </tr>
        <tr>
         <td>
          <asp:GridView ID="grdForm" width="99%" runat="server" AutoGenerateColumns="False" meta:resourcekey="grdFormResource1">
           <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" /> 
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="sFormName" HeaderText="Form Name">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="sRoleName" HeaderText="Role Name">
                <ItemStyle CssClass="hide" />
                <HeaderStyle CssClass="hide" />
            </asp:BoundField>
           </Columns>
        </asp:GridView>
         </td>
        </tr>
        </table>
</asp:Content>

