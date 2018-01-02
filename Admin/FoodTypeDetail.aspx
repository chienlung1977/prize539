<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodTypeDetail.aspx.cs" Inherits="com.oli365.prize.Admin.FoodTypeDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div id="display_area" style="margin-top:10px">
    
        <asp:DataGrid runat="server" ID="gv" DataKeyField="FOOD_UID">
                <Columns>
                    <asp:TemplateColumn>
                            <HeaderTemplate>
                                    食物
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk" />
                            </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
        </asp:DataGrid>
    
    </div>

    <div style="margin-top:10px">
        <asp:Button runat="server" ID="btnSave" Text="儲存" onclick="btnSave_Click" />
        &nbsp;
        <input type="button" value="返回" onclick="window.location.href='FoodTypeList.aspx'" />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
