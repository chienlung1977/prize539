<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReSendCode.aspx.cs" Inherits="com.oli365.prize.Account.ReSendCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="margin-top:5%;text-align:center">

        <table border="1">
            <tr>
                <td colspan="2" style="text-align:center">
                    重送Email驗證碼
                </td>
            </tr>
            <tr>
                <th>帳號：</th>
                <td>
                    <asp:TextBox ID="tbx_email" runat="server"></asp:TextBox></td>
            </tr>
        </table>

        <div style="margin-top:10px;text-align:center">

            <asp:Button ID="btn_submit" runat="server" OnClientClick="return check()" Text="送出Email驗證" OnClick="btn_submit_Click" />

        </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>

        function check() {

            if ($("#MainContent_tbx_email").val() == "") {
                alert('請輸入email');
                $("#MainContent_tbx_email").focus();
                return false;
            }

            if (isMail($("#MainContent_tbx_email").val()) == false) {
                alert('email不正確');
                $("#MainContent_tbx_email").focus();
                return false;
            }

            return true;
        }

    </script>
</asp:Content>
