<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FoodList.aspx.cs" Inherits="com.oli365.prize.Admin.FoodList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="menu_area">
            <input type="button" id="btnShowAdd" value="新增" />
            <input type="button" id="btnImport"  value="CSV檔案匯入" />
    </div>
    
    <div id="add_area" style="margin-top:10px" >
        
        <table border="1" width="100%">
               <tr>
                    <th>食物名稱：</th>
                    <td>
                        <input type="text" runat="server" id="txtfoodname" />
                    </td>
               </tr>
                <tr>
                    <th>每份克數</th>
                    <td>
                       <input type="text" runat="server" id="txtperunit" />
                       </td>
               </tr>
                <tr>
                    <th>卡路里：</th>
                    <td>
                        <input type="text" size="10" runat=server id="txtcalory" />
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

    <div id="import_area" style="margin-top:10px">
    
        <table border="1" width="100%">
            <tr>
                <th>範本檔：</th>
                <td>
                    <asp:HyperLink runat="server" NavigateUrl="/Files/FOOD.csv">下載(請按右鍵另存新檔)</asp:HyperLink>
                </td>
            </tr>
            <tr>
                
                <th>檔案：</th>
                <td>
                        <asp:FileUpload runat="server" ID="fudUpload" />
                        <asp:Button runat="server" ID="btnLoadFile" Text="載入檔案" 
                            onclick="btnLoadFile_Click" />
                </td>
            </tr>
             <tr>
              
                <td colspan="2">
                    <asp:DataGrid runat="server" ID="igv" AutoGenerateColumns="false" >
                        <Columns>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    新增
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk"  />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <HeaderTemplate>
                                    更新
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chkReplace"  />
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:BoundColumn HeaderText ="編號" DataField="NUM" />
                             <asp:BoundColumn HeaderText ="食物名稱" DataField="FOOD_NAME" />
                              <asp:BoundColumn HeaderText ="每一單位" DataField="PER_UNIT" />
                              <asp:BoundColumn HeaderText ="卡路里" DataField="CALORY" />
                              <asp:BoundColumn HeaderText ="備註" DataField="MEMO" />
                              <asp:BoundColumn HeaderText ="匯入狀態" DataField="STATUS" />
                              <asp:BoundColumn Visible=false   DataField="IS_ADD" />
                              <asp:BoundColumn Visible=false   DataField="IS_REPLACE" />
                        </Columns>
                    </asp:DataGrid>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Blue" Visible="False"></asp:Label>
                        <asp:HyperLink ID="lnkBack" runat="server" NavigateUrl="~/Admin/FoodList.aspx" 
                            Visible="False">返回檢視</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                        <asp:Button runat="server" ID="btnConfirmImport" Text="確定匯入" 
                            onclick="btnConfirmImport_Click" Visible="False" />
                </td>
            </tr>
        </table>

        
        
    </div>


    <div id="display_area" style="margin-top:10px" >
    
    <asp:GridView ID="gv" runat="server" DataKeyNames="FOOD_UID">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    所屬分類
                </HeaderTemplate>
                <ItemTemplate>
                        <asp:HyperLink runat="server"  NavigateUrl='<%# "FoodDetail.aspx?fid=" + Eval("FOOD_UID") %>' Text="分類" ></asp:HyperLink>
                        
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>


    <input type="hidden"  id="mode" runat="server" value="V" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

<script>

    $(function () {

        check_mode();


        $("#btnShowAdd").click(function () {
            $("#ctl00_MainContent_mode").val("A");
            check_mode();
        });

        $("#btncancel").click(function () {
            $("#ctl00_MainContent_mode").val("V");
            check_mode();
        });

        $("#btnImport").click(function () {
            $("#ctl00_MainContent_mode").val("I");
            check_mode();
        });

    });

    //控制顯示狀態
    function check_mode() {
        var mode = $("#ctl00_MainContent_mode").val();
        if (mode == "V") {
            $("#add_area").hide();
            $("#import_area").hide();
            $("#display_area").show();
        }
        else if (mode == "A") {
            $("#add_area").show();
            $("#display_area").hide();
            $("#import_area").hide();
        }
        else if (mode == "I") {
            $("#add_area").hide();
            $("#display_area").hide();
            $("#import_area").show();
        }
    }

</script>


</asp:Content>
