<%@ Page Title="猜獎539-下期號碼機率" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dark539NextList.aspx.cs" Inherits="com.oli365.prize.Member.Dark539NextList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        td {
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div style="text-align:center">
        分析期數：
    <asp:DropDownList ID="drp_period" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drp_period_SelectedIndexChanged">

         </asp:DropDownList>&nbsp;&nbsp;

    </div>



    <div><h3><b>開獎號碼</b></h3></div>
    <div >

        <asp:GridView ID="nv" runat="server" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField HeaderText="開獎日期" DataField="LOTTERY_DAY" />
                <asp:BoundField HeaderText="期數" DataField="PERIOD" />
                <asp:BoundField HeaderText="號碼1" DataField="NUM1" />
                <asp:BoundField HeaderText="號碼2" DataField="NUM2" />
                <asp:BoundField HeaderText="號碼3" DataField="NUM3" />
                <asp:BoundField HeaderText="號碼4" DataField="NUM4" />
                <asp:BoundField HeaderText="號碼5" DataField="NUM5" />
            </Columns>
        </asp:GridView>
    </div>

<div><h3><b>預測號碼</b></h3></div>
<div>
    <asp:GridView ID="gv" runat="server" Width="100%"  AutoGenerateColumns="false" OnRowDataBound="gv_RowDataBound" >
        
        <Columns>
            <asp:BoundField HeaderText="分析方式" DataField="CAL_NAME" />
            <asp:BoundField HeaderText="期數" DataField="NEXT_PERIOD" />
             <asp:BoundField HeaderText="筆數" DataField="SORT_NUM" />
            <asp:BoundField HeaderText="2星立柱1" DataField="2_STAR_1" />
            <asp:BoundField HeaderText="2星立柱2" DataField="2_STAR_2" />
            <asp:BoundField HeaderText="2星是否中獎" DataField="S2_IS_WINNING" />
            <asp:BoundField HeaderText="2星對中號碼數" DataField="S2_MATCH_NUM" />
            <asp:BoundField HeaderText="3星立柱1" DataField="3_STAR_1" />
            <asp:BoundField HeaderText="3星立柱2" DataField="3_STAR_2" />
            <asp:BoundField HeaderText="3星立柱3" DataField="3_STAR_3" />
             <asp:BoundField HeaderText="3星是否中獎" DataField="S3_IS_WINNING" />
            <asp:BoundField HeaderText="3星對中號碼數" DataField="S3_MATCH_NUM" />
             <asp:BoundField HeaderText="4星立柱1" DataField="4_STAR_1" />
            <asp:BoundField HeaderText="4星立柱2" DataField="4_STAR_2" />
            <asp:BoundField HeaderText="4星立柱3" DataField="4_STAR_3" />
            <asp:BoundField HeaderText="4星立柱4" DataField="4_STAR_4" />
             <asp:BoundField HeaderText="4星是否中獎" DataField="S4_IS_WINNING" />
            <asp:BoundField HeaderText="4星對中號碼數" DataField="S4_MATCH_NUM" />
        </Columns>
    </asp:GridView>
    
</div>

    <div><h3><b>號碼出現率百分比</b></h3></div>

    <div>
        <asp:GridView ID="agv" runat="server" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField HeaderText ="分析方式" DataField="CAL_NAME" />
                <asp:BoundField HeaderText ="號碼1" DataField="NUM1" />
                <asp:BoundField HeaderText ="號碼1出現率" DataField="NUM1P"  DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼2" DataField="NUM2" />
                <asp:BoundField HeaderText ="號碼2出現率" DataField="NUM2P"  DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼3" DataField="NUM3" />
                <asp:BoundField HeaderText ="號碼3出現率" DataField="NUM3P"  DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼4" DataField="NUM4" />
                <asp:BoundField HeaderText ="號碼4出現率" DataField="NUM4P"  DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="號碼5" DataField="NUM5" />
                <asp:BoundField HeaderText ="號碼5出現率" DataField="NUM5P"  DataFormatString="{0}%" />
                
                <asp:BoundField HeaderText ="最大範圍率" DataField="SCOPE_MAX"  DataFormatString="{0}%" />
                <asp:BoundField HeaderText ="最小範圍率" DataField="SCOPE_MIN"  DataFormatString="{0}%" />
            </Columns>
        </asp:GridView>
    </div>

    <asp:HiddenField ID="hid_numbers" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="JQuery" runat="server">

    <script>
        $(function () {

          //  $("#ctl00_MainContent_Button1").prop("disabled", false);

            $("#ctl00_MainContent_Button1").click(function () {
              //  $(this).prop("disabled", true);
            });
        });
    </script>

</asp:Content>
