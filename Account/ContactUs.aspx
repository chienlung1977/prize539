<%@ Page Title="猜獎539-連絡我們" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="com.oli365.prize.Account.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel ID="pan_main" runat="server">
    <div style="margin:0 auto;width:800px">

        <table width="100%" border="1">
           <thead align="center">
               <tr>
                   <td colspan="2" style="font-size:150%">連絡我們</td>
               </tr>
               
           </thead>
            <tr>
                <th>䁥稱：</th>
                <td>
                    <asp:TextBox ID="tbx_name" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <th>Email：</th>
                <td>
                    <asp:TextBox ID="tbx_email" runat="server"></asp:TextBox>

                    <asp:HiddenField ID="hid_useruid" runat="server" />
                </td>
            </tr>
            <tr>
                <th>
                    詢問類型：
                </th>
                <td>
                    <asp:DropDownList ID="drp_feedType" runat="server">
                        <asp:ListItem Value="1">功能建議</asp:ListItem>
                        <asp:ListItem Value="2">問題詢問</asp:ListItem>
                        <asp:ListItem Value="3">合作洽詢</asp:ListItem>
                        <asp:ListItem Value="9">其他事項</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    主旨：
                </th>
                <td>
                    <asp:TextBox ID="txt_subject" runat="server" MaxLength="100" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    內容：
                </th>
                <td><asp:TextBox ID="tbx_content" runat="server" Width="600px" Height="300px" TextMode="MultiLine" MaxLength="4000"></asp:TextBox>
                </td>
            </tr>
        </table>
         <div style="margin-top:20px;text-align:center">
        <asp:Button ID="btn_submit" runat="server" Text="送出" OnClick="btn_submit_Click" />
    </div>
    </div>
   </asp:Panel>

    <asp:Panel ID="pan_result" Visible="false" runat="server">
       <div style="text-align:center;font-size:150%"> 留言已送出！</div>
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>
        $(function(){
            $("#ctl00_MainContent_btn_submit").click(function () {
                if ($("#ctl00_MainContent_tbx_name").val() == "") {
                    alert('請輸入䁥稱');
                    $("#ctl00_MainContent_tbx_name").focus();
                    return false;
                }
                if ($("#ctl00_MainContent_tbx_email").val() == "") {
                    alert('請輸入電子郵件');
                    $("#ctl00_MainContent_tbx_email").focus();
                    return false;
                }
                if ($("#ctl00_MainContent_tbx_content").val() == "") {
                    alert('請輸入內容');
                    $("#ctl00_MainContent_tbx_content").focus();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
