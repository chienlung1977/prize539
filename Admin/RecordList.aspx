<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordList.aspx.cs" Inherits="com.oli365.prize.Admin.RecordList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <!--    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
   <link rel="stylesheet" href="/resources/demos/style.css">
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
      <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
       -->
	  <script src="/Scripts/datepicker-zh-TW.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div style="margin:5px">
        查詢開始日：<input type="text" id="sdate" name="sdate" size="10" runat=server >
        結束日：<input type="text" id="edate" name="edate" size="10" runat=server >
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查詢" />
    </div>


    <div style="margin-top :20px">
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false"  Width="100%">
           <Columns>
            <asp:TemplateField>
            <ItemStyle HorizontalAlign="Center" />
           
                <HeaderTemplate>
                    圖片
                </HeaderTemplate>
                <ItemTemplate>

                   <a href="/Images/<%#Eval("USER_UID") %>/<%#Eval("PHOTO") %>" target="_blank"> <image src="/Images/<%#Eval("USER_UID") %>/<%#Eval("PHOTO") %>" style="max-width:300px;max-height:200px"></image></a>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField  DataField="PHOTO" Visible=false HeaderText="圖片" />
            <asp:BoundField DataField="CREATE_DATE" HeaderText ="建立日期" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
            <asp:BoundField DataField="WEIGHT" HeaderText="體重" />
            <asp:BoundField DataField="FAT_RATE" HeaderText="體脂肪" />
            <asp:BoundField DataField="BONE_WEIGHT" HeaderText="骨量" />
            <asp:BoundField DataField="BODY_AGE" HeaderText="身體年齡" />
            <asp:BoundField DataField="INSIDE_FAT" HeaderText="內臟脂肪" />
            <asp:BoundField DataField="MUSCLE_WEIGHT" HeaderText="肌肉量" />
            <asp:BoundField DataField="BODY_WATER" HeaderText="含水量" />
            <asp:BoundField DataField="METABOLISM" HeaderText="新陳代謝率" />
            
            
           </Columns>
        </asp:GridView>
</asp:Content>
