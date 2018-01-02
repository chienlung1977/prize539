<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodTypeList.aspx.cs" Inherits="com.oli365.prize.Admin.FoodTypeList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id="menu_area">
            <input type="button" id="btnShowAdd" value="新增" />
    </div>
    
    <div id="add_area" style="margin-top:10px" >
        
        <table border="1" width="100%">
               <tr>
                    <th>食物類別名稱：</th>
                    <td>
                        <input type="text" runat="server" id="txtfoodtypename" />
                    </td>
               </tr>
            
               <tr>
                    <th>備註：</th>
                    <td>
                        <input type="text" runat=server id="txtmemo"    />
                    </td>
               </tr>
               <tr>
                <td colspan="2" style="text-align:center">
                        <asp:Button ID="btnSave" runat="server" Text="儲存" onclick="btnSave_Click" />
                        
                        <input type="button"  id="btncancel" value="取消" />
                </td>
               </tr>
        </table>

    </div>


    <div id="display_area" style="margin-top:10px" >
    
    <asp:GridView ID="gv" runat="server" DataKeyNames="FOOD_TYPE_UID">
            <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    相關食物
                </HeaderTemplate>
                <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl='<%# "FoodTypeDetail.aspx?ftid=" + Eval("FOOD_TYPE_UID") %>' Text="關連食物" ></asp:HyperLink>
                        
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">


<script>

    $(function () {

        $("#add_area").hide();

        $("#btnShowAdd").click(function () {
            $("#add_area").show();
            $("#display_area").hide();
        });

        $("#btncancel").click(function () {
            $("#add_area").hide();
            $("#display_area").show();
        });

    });
  

</script>
</asp:Content>
