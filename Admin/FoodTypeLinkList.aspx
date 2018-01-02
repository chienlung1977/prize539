<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodTypeLinkList.aspx.cs" Inherits="com.oli365.prize.Admin.FoodTypeLinkList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <div id="display_area" style="margin-top:10px" >
    
    <asp:GridView ID="gv" runat="server">
    </asp:GridView>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

<script>

    $(function () {

      
    });
  

</script>

</asp:Content>
