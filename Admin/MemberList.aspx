<%@ Page Title="LIST" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="com.oli365.prize.Admin.MemberList" %>
<asp:Content  ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content  ContentPlaceHolderID="MainContent" runat="server">
    
    <div style="margin:20px;">
    
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" DataKeyNames="USER_UID"
            onrowcommand="gv_RowCommand" OnRowDataBound="gv_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="加入日期" DataField="CREATE_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                <asp:BoundField HeaderText="使用者代號" DataField="USER_UID" />
                <asp:BoundField HeaderText="EMAIL" DataField="EMAIL" />
                <asp:BoundField HeaderText="䁥稱" DataField="NICK_NAME" />
               
                <asp:BoundField HeaderText="帳號狀態" DataField="STATUS" />
                <asp:BoundField HeaderText="EMAIL驗證" DataField="EMAIL_CONFIRM"  />
                 <asp:BoundField HeaderText="最後登入IP" DataField="LAST_LOGIN_IP" />
                <asp:BoundField HeaderText="最後登入日期" DataField="LAST_LOGIN_DATE" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                
                
                <asp:TemplateField HeaderText="檢視">
                    <ItemTemplate>
                       
                        <asp:Button ID="btnLoginHistory" runat="server" Text="登入記錄" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="LOGIN_HISTORY"  />
                        <asp:Button ID="btnSettings" runat="server" Text="參數設定" Enabled="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' CommandName="SETTINGS"  />
                         
                    </ItemTemplate>

                </asp:TemplateField>
               
            </Columns>
        </asp:GridView>
   
   </div>

</asp:Content>
