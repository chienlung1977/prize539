<%@ Page Title="SSSS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="com.oli365.prize.Admin.AdminLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
  <br /><br />

    <div style="margin:20px">
        
        <div style="margin:20px;">
            <table border="1" align="center">
                <tr>
                    <th>帳號:</th>
                    <td>
                        <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>密碼:</th>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                     <div>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="送出" />
</div>
                    </td>
                </tr>
            </table>
            <br />
            <br />
        </div>
       
    </div>


</asp:Content>
