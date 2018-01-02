<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUser_Add.aspx.cs" Inherits="com.oli365.prize.Admin.AdminUser_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<style>
    th,td{padding:5px;}
</style>

<body>
    <form id="form1" runat="server">
    <div>
    
    <div>
        <table border="1" width="60%">
            <tr>
                <th>Email帳號</th>
                <td>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <th>密碼</th>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                 </td>
            </tr>
            
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="送出" />
                </td>
            </tr>
        </table>
        </div>

        <div style="margin-top:10px">
                
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
                
        </div>
    </div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
