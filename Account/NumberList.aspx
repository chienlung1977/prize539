<%@ Page Title="開獎號碼" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NumberList.aspx.cs" Inherits="com.oli365.prize.Account.NumberList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div style="text-align:center;display:none">
    查詢期數：
    
    <asp:DropDownList ID="drp_period" runat="server">
        <asp:ListItem Value="10">10天</asp:ListItem>
        <asp:ListItem Value="30">一個月</asp:ListItem>
        <asp:ListItem Value="60">三個月</asp:ListItem>
        <asp:ListItem Value="180">六個月</asp:ListItem>
        <asp:ListItem Value="360">一年</asp:ListItem>
         </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" />
</div>

<div style="text-align:center;font-size:150%">

    最近60期今彩539開獎號碼

</div>

<div style="margin-top:20px;">
    <asp:GridView ID="gv" runat="server" Width="100%" OnRowDataBound="gv_RowDataBound">

    </asp:GridView>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
