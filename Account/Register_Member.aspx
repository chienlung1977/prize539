<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Account/Register_Member.aspx.cs" Inherits="com.oli365.prize.Account.Register_Member" %>





<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel ID="pan_main" runat="server">

    <div style="width:500px;margin:0 auto;">

        <table border="1" width="100%" >
            <tr>
                <th align="right" width="30%">
                    EMAIL帳號：
                </th>
                <td width="70%">
                    <asp:TextBox ID="tbx_email" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th align="right">
                    䁥稱：
                </th>
                <td>
                    <asp:TextBox ID="tbx_nickname" runat="server" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <th align="right">
                    密碼：
                </th>
                <td>
                    <asp:TextBox ID="tbx_password" runat="server" TextMode="Password"  MaxLength="30"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <th align="right">
                    確認密碼：
                </th>
                <td>
                    <asp:TextBox ID="tbx_cpassword" runat="server" TextMode="Password" MaxLength="30"></asp:TextBox>
                </td>
            </tr>
        </table>

        <div style="margin-top:20px;text-align:center">
            <asp:Button ID="btnsubmit" runat="server" Text="送出" OnClick="btnsubmit_Click"   />
        </div>


    </div>
    </asp:Panel>

    <asp:Panel ID="pan_result" runat="server" Visible="false">

        <div style="text-align:center;font-size:150%">
            註冊成功，已發送帳號啟用確認信，請至您的Email信箱啟用帳號！
        </div>

    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
   
    <script>
        
        $(function () {
            $("#ctl00_MainContent_btnsubmit").click(function () {
                if ($("#ctl00_MainContent_tbx_email").val() == "") {
                    alert('請輸入登入EMAIL');
                    $("#ctl00_MainContent_tbx_email").focus();
                    return false;
                }
                if ($("#ctl00_MainContent_tbx_nickname").val() == "") {
                    alert('請輸入䁥稱');
                    $("#ctl00_MainContent_tbx_nickname").focus();
                    return false;
                }
                if ($("#ctl00_MainContent_tbx_password").val() == "") {
                    alert('請輸入密碼');
                    $("#ctl00_MainContent_tbx_password").focus();
                    return false;
                }
                if ($("#ctl00_MainContent_tbx_password").val() != $("#ctl00_MainContent_tbx_cpassword").val()) {
                    alert('密碼不一致');
                    $("#ctl00_MainContent_tbx_cpassword").focus();
                    return false;
                }


                return true;
            });
        });


    </script>


</asp:Content>
