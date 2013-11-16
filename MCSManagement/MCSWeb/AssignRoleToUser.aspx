<%@ Page Title="" Language="C#" MasterPageFile="~/MCSMainMaster.master" AutoEventWireup="true" CodeFile="AssignRoleToUser.aspx.cs" Inherits="AssignRoleToUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table width="98%" cellpadding="0" align="center" class="tblStyle">
        <tr>
            <td class="editmodetd" align="center">
                <asp:Label ID="lbleditmode" runat="server" Text="Assign Role To User" SkinID="editmodelabelskin"></asp:Label>
            </td>
        </tr>
       <tr>
       <td>
        <table width="40%">
         <tr>
          <td class="captiontd">
                <asp:Label runat="server" ID="Label1" Text="Role"></asp:Label>
            </td>
            <td class="contenttd">
                <asp:DropDownList Width="182px" runat="server" ID="DropDownList1">
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
          <table>
          <tr>
           <td class="captiontdSimple">
            Available System users not in Role
           </td>
            <td width="60px">
             &nbsp;
            </td>
             <td class="captiontdSimple">
             System users in Role
            </td>
          </tr>
           <tr>
            <td>
             <asp:ListBox runat="server" ID="lstUsersNotInRole" Width="310px" Height="350px"></asp:ListBox>
            </td>
            <td width="60px" align="center">
             <table>
               <tr>
                <td>
                 <asp:Button runat="server" ID="btnSingleRightShift" Text=">" Width="50px" />
                </td>
               </tr>
               <tr>
                <td>
                 <asp:Button runat="server" ID="btnAllRightShift" Text=">>" Width="50px" />
                </td>
               </tr>
               <tr>
                <td>
                 <asp:Button runat="server" ID="btnAllLeftShift" Text="<<" Width="50px" />
                </td>
               </tr>
               <tr>
                <td>
                <asp:Button runat="server" ID="btnSingleLeftShift" Text="<" Width="50px" />
                </td>
               </tr>
             </table>
            </td>
            <td>
             <asp:ListBox runat="server" ID="lstUsersInRole" Width="310px" Height="350px"></asp:ListBox>
            </td>
           </tr>
          </table>
         </td>
        </tr>
        </table>
</asp:Content>

