<%@ Page Title="猜獎539-操作說明" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FunctionList.aspx.cs" Inherits="com.oli365.prize.Account.FunctionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .auto-style1 {
        width: 1865px;
        height: 787px;
    }
    .auto-style2 {
        width: 1885px;
        height: 856px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
       
        <strong>會員選單&gt;&gt;歷史開獎機率</strong></p>
<p>
       
    可以依照期間進行查詢</p>
    <p>
        <img alt="" class="auto-style1" src="../Img/p1.png" style="max-width:100%" /></p>
    <p>
        藍色框框顯示的是該期開獎號碼</p>
    <p>
        <img alt="" class="auto-style1" src="../Img/p2.png" style="max-width:100%" /></p>
    <p>
        統計號碼在查詢期間出現多少次</p>
<p>
    <img alt="" class="auto-style1" src="../Img/p3.png" style="max-width:100%" /></p>
<p>
    根據出現次數除於總號碼次數的百分比</p>
<p>
    <img alt="" class="auto-style1" src="../Img/p4.png" style="max-width:1200px" /></p>
<p>
    依照出現率進行排序顯示</p>
<p>
    <img alt="" class="auto-style1" src="../Img/p5.png" style="max-width:100%" /></p>
<p>
    <strong>會員選單&gt;&gt;下期號碼機率</strong></p>
<p>
    橘色框框代表查詢期數的下期開出號碼</p>
<p>
    <img alt="" class="auto-style2" src="../Img/p6.png" style="max-width:100%" /></p>
<p>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
