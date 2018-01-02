<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NextForecastAnalysis.aspx.cs" Inherits="com.oli365.prize.Member.NextForecastAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
     td {
         text-align:center;
     }
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>

    </div>

    <div>
          <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField HeaderText="期數" DataField="PERIOD" />
                <asp:BoundField HeaderText="最小範圍率" DataField="SCOPE_MIN" DataFormatString="{0}%" />
                <asp:BoundField HeaderText="最大範圍率" DataField="SCOPE_MAX" DataFormatString="{0}%" />
                <asp:BoundField HeaderText="號碼1" DataField="NUM1" />
                <asp:BoundField HeaderText="號碼1出現率" DataField="NUM1P" DataFormatString="{0}%" />
                 <asp:BoundField HeaderText="號碼2" DataField="NUM2" />
                <asp:BoundField HeaderText="號碼2出現率" DataField="NUM2P" DataFormatString="{0}%" />
                 <asp:BoundField HeaderText="號碼3" DataField="NUM3" />
                <asp:BoundField HeaderText="號碼3出現率" DataField="NUM3P" DataFormatString="{0}%" />
                 <asp:BoundField HeaderText="號碼4" DataField="NUM4" />
                <asp:BoundField HeaderText="號碼4出現率" DataField="NUM4P" DataFormatString="{0}%" />
                 <asp:BoundField HeaderText="號碼5" DataField="NUM5" />
                <asp:BoundField HeaderText="號碼5出現率" DataField="NUM5P" DataFormatString="{0}%" />
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">
</asp:Content>
