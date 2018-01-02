<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DownloadApp.aspx.cs" Inherits="com.oli365.prize.Account.DownloadApp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="main">

        <div style="text-align:center;font-size:150%">Android手機，掃瞄QRCODE下載【減重365】App</div>

        <div style="text-align:center;margin-top:30px;">

            <asp:Image ID="Image1" runat="server" ImageUrl="~/Img/qrcode.png" />

        </div>

        <div style="text-align:center;margin-top:30px;">

            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://play.google.com/store/apps/details?id=com.oli365.nc">https://play.google.com/store/apps/details?id=com.oli365.nc</asp:HyperLink>
        </div>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
