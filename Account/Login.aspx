  <%@ Page  Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"    CodeBehind="Login.aspx.cs" Inherits="com.oli365.prize.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">



</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   

   <div style="margin-top:20px;">
   <table style="margin-top:200px;" align=center border="1">
        <tr>
            <th>帳號：</th>
            <td><asp:TextBox runat="server" ID="txtAccount" ></asp:TextBox></td>
        </tr>
        <tr>
            <th>密碼：</th>
            <td><asp:TextBox runat="server" ID="txtPwd" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Account/Register_Member.aspx">註冊</asp:HyperLink>              
            &nbsp;<asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
   </table>

       <div style="text-align:center;margin-top:10px;">
             <asp:Button ID="btnSubmit" runat="server" Text="送出" OnClientClick="return check()" onclick="btnSubmit_Click" />

       </div>


   </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>

        function check() {

            if ($("#ctl00_MainContent_txtAccount").val() == "") {
                alert('請輸入登入帳號');
                $("#ctl00_MainContent_txtAccount").focus();
                return false;
            }

            if ($("#ctl00_MainContent_txtPwd").val() == "") {
                alert('請輸入登入密碼');
                $("#ctl00_MainContent_txtPwd").focus();
                return false;
            }

            return true;

        }

    </script>

    </asp:Content>