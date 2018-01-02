<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorLog.aspx.cs" Inherits="com.oli365.prize.Admin.ErrorLog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:GridView ID="gv" runat="server" AutoGenerateColumns=false Width="100%">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="日期" DataField="CREATE_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}"  />
            <asp:BoundField HeaderText="類型" DataField="INFO_TYPE" />
            <asp:BoundField HeaderText="內容" DataField="MEMO" />
          
        </Columns>
    </asp:GridView>
</asp:Content>
