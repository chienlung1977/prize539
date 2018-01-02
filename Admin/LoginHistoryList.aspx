<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LoginHistoryList.aspx.cs" Inherits="com.oli365.prize.Admin.LoginHistoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div style="margin:20px">
        <asp:GridView ID="gv" runat="server" DataKeyNames="LOGIN_UID" AutoGenerateColumns="false" Width="100%">
            <Columns>
                    
                    <asp:BoundField HeaderText="建立日期" DataField="CREATE_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                    <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" />
                     <asp:BoundField HeaderText="IP位置" DataField="LOGIN_IP" />
            </Columns>
        </asp:GridView>
</div>
 
</asp:Content>
