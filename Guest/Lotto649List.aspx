<%@ Page Title="大樂透開獎號碼" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lotto649List.aspx.cs" Inherits="com.oli365.prize.Member.Lotto649List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        td {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div style="text-align:center;">
    查詢期間：
    
    <asp:DropDownList ID="drp_period" runat="server">
        <asp:ListItem Value="10">10期</asp:ListItem>
        <asp:ListItem Value="30" Selected="True" >30期</asp:ListItem>
        <asp:ListItem Value="60">60期</asp:ListItem>
     
         </asp:DropDownList>&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="查詢" OnClick="Button1_Click" />
</div>

<div style="margin-top:20px;"  >
    <asp:GridView ID="gv" runat="server" Width="100%" OnRowDataBound="gv_RowDataBound" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText ="開獎日期" DataField="LOTTERY_DATE" />
            <asp:BoundField HeaderText ="期數" DataField="PERIOD" />
            <asp:BoundField HeaderText ="號碼1" DataField="NUM1" />
            <asp:BoundField HeaderText ="號碼2" DataField="NUM2" />
            <asp:BoundField HeaderText ="號碼3" DataField="NUM3" />
            <asp:BoundField HeaderText ="號碼4" DataField="NUM4" />
            <asp:BoundField HeaderText ="號碼5" DataField="NUM5" />
            <asp:BoundField HeaderText ="號碼6" DataField="NUM6" />
            <asp:BoundField HeaderText ="特別號" DataField="ESP_NUM" />
            <asp:TemplateField HeaderText="期數分析" Visible="false">
                <ItemTemplate >
                    <input type="button" value="分析" onclick="location.href ='<%#DataBinder.Eval(Container.DataItem, "PERIOD", "NextNumberList.aspx?pid={0}")%>'" />
                </ItemTemplate>
            </asp:TemplateField>
         
            
        </Columns>
    </asp:GridView>
</div>

<div style="margin-top:20px;">
    連莊號碼以藍色表示<div style="width:20px;height:20px;background-color:#77DDFF;float:left"></div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
