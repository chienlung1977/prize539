<%@ Page Title="猜獎539-下期號碼機率(加計)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NextNumberRList.aspx.cs" Inherits="com.oli365.prize.Member.NextNumberRList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center">
    查詢期間：
    
    <asp:DropDownList ID="drp_period" runat="server">
        <asp:ListItem Value="10">10天</asp:ListItem>
        <asp:ListItem Value="30">一個月</asp:ListItem>
        <asp:ListItem Value="60">二個月</asp:ListItem>
        <asp:ListItem Value="90">三個月</asp:ListItem>
        <asp:ListItem Value="120">四個月</asp:ListItem>
        <asp:ListItem Value="150">五個月</asp:ListItem>
        <asp:ListItem Value="180">六個月</asp:ListItem>
        <asp:ListItem Value="360">一年</asp:ListItem>
       
         </asp:DropDownList>&nbsp;&nbsp;
    
    分析期數：
    <asp:DropDownList ID="drp_analysis" runat="server">

         </asp:DropDownList>&nbsp;&nbsp;

    <asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" />
</div>

<div style="margin-top:20px;">
    <asp:Label ID="lbl_lottery_num" runat="server" Font-Bold="True" Font-Size="Large" ></asp:Label>
    <asp:GridView ID="gv" runat="server" Width="100%"  OnRowDataBound="gv_RowDataBound">

    </asp:GridView>
    <asp:Label ID="lbl_next_lottery_num" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" ></asp:Label>
    <input type="hidden" runat="server" id="hid_next_lottery_num" />
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>
        $(function () {

          //  $("#ctl00_MainContent_Button1").prop("disabled", false);

            $("#ctl00_MainContent_Button1").click(function () {
              //  $(this).prop("disabled", true);
            });
        });
    </script>

</asp:Content>
